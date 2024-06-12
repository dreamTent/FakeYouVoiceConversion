using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;

namespace FakeYouVoiceConversion
{
    public class Client
    {
        private HttpClient httpClient;
        private string sessionToken = "";
        //------------------------- Initialisation ------------------------- 
        /// <summary>
        /// Creates a Client and initiates the socket with ipv4
        /// </summary>
        /// <returns></returns>
        public Client()
        {
            createHttpClient(true);
        }


        /// <summary>
        /// Creates a Client and initiates the socket, specify if it should force ipv4 (this is needed sometimes)
        /// </summary>
        /// <returns></returns>
        public Client(bool forceIPv4)
        {
            createHttpClient(forceIPv4);
        }


        private void createHttpClient(bool forceIPv4)
        {
            if (forceIPv4)
            {
                var handler = new SocketsHttpHandler
                {
                    ConnectCallback = async (context, cancellationToken) =>
                    {
                        var addresses = await Dns.GetHostAddressesAsync(context.DnsEndPoint.Host);
                        var ipv4Address = addresses.First(ip => ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                        var endpoint = new IPEndPoint(ipv4Address, context.DnsEndPoint.Port);

                        var socket = new Socket(ipv4Address.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
                        await socket.ConnectAsync(endpoint, cancellationToken).ConfigureAwait(false);

                        return new NetworkStream(socket, ownsSocket: true);
                    },
                    MaxConnectionsPerServer = 10,
                };

                httpClient = new HttpClient(handler);
            }
            else
            {
                httpClient = new HttpClient();
            }
        }


        //------------------------- Public functions ------------------------- 
        /// <summary>
        /// Loggs the user in, if the user is logged in the session token is automatically used for all api requests.
        /// </summary>
        /// <returns>If successfull returns true, else returns false</returns>
        public async Task<bool> Login(string usernameOrEmail, string password)
        {
            if (sessionToken != "") return true;
            string requestUri = $"https://api.fakeyou.com/login";

            //build messages
            using StringContent jsonContent = new StringContent(
                JsonSerializer.Serialize(new
                {
                    username_or_email = usernameOrEmail,
                    password = password
                }),
                Encoding.UTF8,
                "application/json"
            );

            //clear header
            httpClient.DefaultRequestHeaders.Clear();

            MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");
            contentType.Parameters.Add(new NameValueHeaderValue("charset", "utf-8"));

            var response = await httpClient.PostAsync(requestUri, jsonContent);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                Debug.WriteLine(responseContent);

                IEnumerable<string> cookies;
                if (response.Headers.TryGetValues("Set-Cookie", out cookies))
                {

                }
                else
                {
                    return false;
                }
                using JsonDocument document = JsonDocument.Parse(responseContent);

                sessionToken = document.RootElement.GetProperty("signed_session").GetString();
                return true;
            }

            return false;
        }

        /// <summary>
        /// Loggs the user out
        /// </summary>
        /// <returns>If the user is currently logged in and login was successfull returns true, else returns false</returns>
        public async Task<bool> Logout()
        {
            //Logout
            string apiUrl = "https://api.fakeyou.com/v1/logout";

            //clear header
            httpClient.DefaultRequestHeaders.Clear();
            //set api key (session token)
            if (sessionToken != "")
            {
                httpClient.DefaultRequestHeaders.Add("credentials", "include");
                httpClient.DefaultRequestHeaders.Add("cookie", $"session={sessionToken}");
            }
            else
            {
                return false;
            }

            MediaTypeHeaderValue contentType = new MediaTypeHeaderValue("application/json");
            contentType.Parameters.Add(new NameValueHeaderValue("charset", "utf-8"));

            var response = await httpClient.PostAsync(apiUrl, null);

            if (response.IsSuccessStatusCode)
            {
                sessionToken = "";
                return true;
            }
            return false;
        }


        /// <summary>
        /// uses HTTP GET to get the list of all available voice conversion models
        /// </summary>
        /// <returns>List of Models</returns>
        public async Task<List<Model>> GetVoiceList()
        {
            //clear header
            httpClient.DefaultRequestHeaders.Clear();
            //set api key (session token)
            if (sessionToken != "")
            {
                httpClient.DefaultRequestHeaders.Add("credentials", "include");
                httpClient.DefaultRequestHeaders.Add("cookie", $"session={sessionToken}");
            }
            string requestUri = $"https://api.fakeyou.com/v1/voice_conversion/model_list";
            using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, requestUri))
            {
                using (HttpResponseMessage response = await httpClient.SendAsync(request))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        string voiceList = await response.Content.ReadAsStringAsync();
                        try
                        {
                            ApiResponse apiResponse = JsonSerializer.Deserialize<ApiResponse>(voiceList);
                            if(apiResponse.Models != null)
                            {
                                return apiResponse.Models;
                            }
                        }
                        catch (NullReferenceException ex)
                        {

                        }
                        catch (Exception ex)
                        {

                        }
                    }
                    else
                    {
                        return null;
                    }
                }
            }
            return null;
        }




        /// <summary>
        /// uses HTTP GET to get the list of all available voice conversion models
        /// </summary>
        /// <returns>Returns an empty byte array or null if an error happens</returns>
        public async Task<byte[]> MakeVoiceConversion(string modelToken, byte[] audio)
        {
            //upload audio
            string uploadToken = await upload(audio);
            if (uploadToken == null || uploadToken == "") return null;

            //start inference
            string jobId = await startInference(modelToken, uploadToken);
            if (jobId == null || jobId == "") return null;

            //wait for inference to be done
            string resultPath = await getInferenceStatus(jobId);

            //get audio file
            return await getCompletedAudio(resultPath);

        }


        private async Task<string> upload(byte[] audio)
        {
            string uploadId = Guid.NewGuid().ToString();
            string uploadPath = $"https://api.fakeyou.com/v1/media_uploads/upload_audio";
            try
            {
                //clear header
                httpClient.DefaultRequestHeaders.Clear();
                //set api key (session token)
                if (sessionToken != "")
                {
                    httpClient.DefaultRequestHeaders.Add("credentials", "include");
                    httpClient.DefaultRequestHeaders.Add("cookie", $"session={sessionToken}");
                }

                var formData = new MultipartFormDataContent("----WebKitFormBoundaryZnPeC94a6RwzzDnk");

                formData.Add(new StringContent(uploadId), "uuid_idempotency_token");

                //MemoryStream audioStream = new MemoryStream(audio);
                //formData.Add(new StreamContent(audioStream), "file", "file.wav");
                formData.Add(new ByteArrayContent(audio), "file", "file.wav");

                formData.Add(new StringContent("file"), "source");

                formData.Headers.ContentType.MediaType = "multipart/form-data";
                //formData.Headers.Add("Content-Type", "multipart/form-data");


                // Send the POST request
                var response = await httpClient.PostAsync(uploadPath, formData);

                if (response.IsSuccessStatusCode)
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    Debug.WriteLineIf(true, responseContent);
                    using JsonDocument document = JsonDocument.Parse(responseContent);

                    JsonElement root = document.RootElement;

                    if (root.GetProperty("success").GetBoolean())
                    {
                        return root.GetProperty("upload_token").GetString();
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return "";
        }


        private async Task<string> startInference(string modelToken, string uploadToken)
        {
            //clear header
            httpClient.DefaultRequestHeaders.Clear();
            //set api key (session token)
            if (sessionToken != "")
            {
                httpClient.DefaultRequestHeaders.Add("credentials", "include");
                httpClient.DefaultRequestHeaders.Add("cookie", $"session={sessionToken}");
            }

            var requestData = new
            {
                uuid_idempotency_token = Guid.NewGuid().ToString(),
                voice_conversion_model_token = modelToken,
                source_media_upload_token = uploadToken,
                override_f0_method = "rmvpe"
            };
            string jsonPayload = JsonSerializer.Serialize(requestData);
            try
            {
                StringContent content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                // Make the HTTP POST request
                HttpResponseMessage response = await httpClient.PostAsync("https://api.fakeyou.com/v1/voice_conversion/inference", content);

                // Check if the request was successful
                if (response.IsSuccessStatusCode)
                {
                    // Read the response content
                    string responseData = await response.Content.ReadAsStringAsync();

                    // Parse JSON response
                    using (JsonDocument document = JsonDocument.Parse(responseData))
                    {
                        JsonElement root = document.RootElement;
                        if (root.TryGetProperty("success", out JsonElement successElement) && successElement.GetBoolean())
                        {
                            if (root.TryGetProperty("inference_job_token", out JsonElement tokenElement))
                            {
                                return tokenElement.GetString();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return "";
        }

        private async Task<string> getInferenceStatus(string jobId)
        {
            string url = $"https://api.fakeyou.com/v1/model_inference/job_status/{jobId}";
            int maxRetries = 60;
            int retries = 0;

            while (retries < maxRetries)
            {
                retries++;
                //clear header
                httpClient.DefaultRequestHeaders.Clear();
                //set api key (session token)
                if (sessionToken != "")
                {
                    httpClient.DefaultRequestHeaders.Add("credentials", "include");
                    httpClient.DefaultRequestHeaders.Add("cookie", $"session={sessionToken}");
                }

                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string jsonResponse = await response.Content.ReadAsStringAsync();
                    using (JsonDocument doc = JsonDocument.Parse(jsonResponse))
                    {
                        var root = doc.RootElement;

                        if (root.TryGetProperty("state", out JsonElement stateElement) &&
                            stateElement.TryGetProperty("status", out JsonElement statusElement) &&
                            statusElement.TryGetProperty("status", out JsonElement statusValue) &&
                            statusValue.GetString() == "complete_success" &&
                            stateElement.TryGetProperty("maybe_result", out JsonElement maybeResultElement) &&
                            maybeResultElement.TryGetProperty("maybe_public_bucket_media_path", out JsonElement mediaPathElement))
                        {
                            return mediaPathElement.GetString();
                        }
                    }
                }
                await Task.Delay(2000);
            }

            throw new TimeoutException("The request timed out after 60 tries.");
        }



        private async Task<byte[]> getCompletedAudio(string mediaPath)
        {
            string path = "https://storage.googleapis.com/vocodes-public" + mediaPath;

            httpClient.DefaultRequestHeaders.Clear();
            var finishedResult = await httpClient.GetAsync(path);
            //add to cache
            return await finishedResult.Content.ReadAsByteArrayAsync();
        }














    }
}
