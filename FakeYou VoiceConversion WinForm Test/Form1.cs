using FakeYouVoiceConversion;
using System.Diagnostics;

namespace FakeYou_VoiceConversion_WinForm_Test
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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
    }
}
