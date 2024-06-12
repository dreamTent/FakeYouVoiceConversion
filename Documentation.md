## Get list
GET model list: https://api.fakeyou.com/v1/voice_conversion/model_list

Upload Audio: https://api.fakeyou.com/v1/media_uploads/upload_audio

Resquest:
- Form data:
  - uuid_idempotency_token: [random UUID]
  - file: (binary)
  - source: file
  
Response:
```json
{"success": true, "upload_token": "<upload token>"}
```

## Start Inference
Start inference: https://api.fakeyou.com/v1/voice_conversion/inference

Request:
```json
{
"uuid_idempotency_token":"<another random UUID>",
"voice_conversion_model_token":"<model token>",
"source_media_upload_token":"<upload token>",
"override_f0_method":"rmvpe"
}
```
Response:
```json
{"success":true,"inference_job_token":"<id>"}
```

## Get Status
GET Status (check every 2 seconds or so): https://api.fakeyou.com/v1/model_inference/job_status/[id]

Response: (shortened) when not ready yet
```json
{
    "state": {
        "status": {
            "status": "pending"
        },
        "maybe_result": null
    }
}
```

Response: (shortened) when complete
```json
{
    "state": {
        "status": {
            "status": "complete_success"
        },
        "maybe_result": {
            "maybe_public_bucket_media_path": "<path>",
        }
    }
}
```

## Get Audio File
Afterwards you can request the resulting audio file here:
"https://storage.googleapis.com/vocodes-public"+[path]