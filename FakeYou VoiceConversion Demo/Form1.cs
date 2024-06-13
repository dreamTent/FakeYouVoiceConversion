using System.Diagnostics;
using FakeYouVoiceConversion;

namespace FakeYou_VoiceConversion_Demo
{
    public partial class Form1 : Form
    {
        List<Model> allModels = new List<Model>();
        List<Model> searchedModesl = new List<Model>();
        public Form1()
        {
            InitializeComponent();

            //string[] listViewItem = new string[] { "Downloading...", "", "" };
            //Voices_listView.Items.Add(new ListViewItem(listViewItem));

            searchedModesl.Add(new Model() { Title = "Loading...", Creator = new Creator() { DisplayName = "" }, Token = "" });

            Voices_listView.VirtualMode = true;
            Voices_listView.RetrieveVirtualItem += Voices_listView_GetVirtualItem;

            Voices_listView.VirtualListSize = searchedModesl.Count();
            Voices_listView.Invalidate();


            DownloadModelList();
        }

        private void Start_button_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
            Task.Run(async () =>
            {
                //read file
                byte[] fileBytes = File.ReadAllBytes("output.wav");


                //do stuff
                Client client = new Client();
                var result = await client.GetVoiceList();
                byte[] resultBytes = await client.MakeVoiceConversion("weight_4c230zwawr3dm0jqcce16xtvf", fileBytes);


                File.WriteAllBytes("result.wav", resultBytes);
                Debug.WriteLineIf(true, result);
            });
        }
        private void LoadVoices()
        {
            Task.Run(async () =>
            {
                //read file
                byte[] fileBytes = File.ReadAllBytes("output.wav");


                //do stuff
                Client client = new Client();
                var result = await client.GetVoiceList();
                byte[] resultBytes = await client.MakeVoiceConversion("weight_4c230zwawr3dm0jqcce16xtvf", fileBytes);


                File.WriteAllBytes("result.wav", resultBytes);
                Debug.WriteLineIf(true, result);
            });
        }
        private void DownloadModelList()
        {
            Task.Run(async () =>
            {
                //get model list and push them to the list
                Client client = new Client();
                List<Model> result = await client.GetVoiceList();
                SetAvailableModels(result);
            });
        }
        private void SetAvailableModels(List<Model> newModelsList)
        {
            lock (allModels) lock (Search_textBox)
                {

                    allModels = newModelsList;
                    SetSearchedModels(Search_textBox.Text);
                }
        }
        private void SetSearchedModels(string searchText)
        {
            if (searchText == null || searchText == "")
            {
                searchedModesl = allModels;
            }
            else
            {
                searchText = searchText.ToLower();
                searchedModesl = allModels.FindAll(obj => (obj.Title.ToLower().Contains(searchText) || obj.Creator.DisplayName.ToLower().Contains(searchText)));
            }
            lock (Voices_listView)
            {
                Voices_listView.Invoke((MethodInvoker)delegate
                {
                    //Voices_listView.Items.Clear();

                    Voices_listView.VirtualListSize = searchedModesl.Count();
                    Voices_listView.Invalidate();
                    //Voices_listView.RetrieveVirtualItem += Voices_listView_GetVirtualItem;
                    foreach (var item in searchedModesl)
                    {
                        //string[] listViewItem = new string[] { item.Title, item.Creator.DisplayName, item.Token };
                        //Voices_listView.Items.Add(new ListViewItem(listViewItem));
                    }
                });

            }
        }
        private void Voices_listView_GetVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = new ListViewItem(new string[]
            {
                searchedModesl[e.ItemIndex].Title,
                searchedModesl[e.ItemIndex].Creator.DisplayName,
                searchedModesl[e.ItemIndex].Token,

            });
        }

        private void Search_textBox_TextChanged(object sender, EventArgs e)
        {
            SetSearchedModels(Search_textBox.Text);
        }

        private void Voices_listView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                ListViewItem item = Voices_listView.HitTest(e.Location).Item;
                SelectedVoiceToken_textBox.Text = searchedModesl[item.Index].Token;
            }
            catch (Exception)
            {
            }
        }








    }
}
