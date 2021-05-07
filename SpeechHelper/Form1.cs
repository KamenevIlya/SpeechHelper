using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Auth.OAuth2;
using Google.Cloud.Speech.V1;
using NAudio.Wave;
using Grpc.Auth;
using Google.Cloud.Language.V1;
using System.Xml;



namespace SpeechHelper
{
    public partial class Form1 : Form
    {
        SpeechConverter speechConverter = new SpeechConverter();
        DateTime date1 = new DateTime(0, 0);
        private string currentLanguage="ru";
        static public bool earlyRecordsFirst = false;
        static public uint maxValuesInEntitiesCombobox=8;
        static public int currentCoefOfSimilarity = 5;
        static public bool rememberNewEntities = true;


        public Form1()
        {
            InitializeComponent();
            if (File.Exists("key.json"))
            {
                Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", "key.json");
            }
            else
            {
                MessageBox.Show("Проверьте наличие ключа");
                throw new FileNotFoundException();
            }
            
            speechConverter.Initializate();
            btnRecordVoice.Enabled = true;
            btnSave.Enabled = false;
            btnSpeechInfo.Enabled = false;
            btnFindRelated.Enabled = false;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            StopCurrentRecording();
        }

        private void btnRecordVoice_Click(object sender, EventArgs e)
        {
            menuStrip1.Enabled = false;
            speechConverter.IsRecording = true;
            speechConverter.StartNewRecording();
            comboBox1.Items.Clear();
            comboBox1.Visible = false;
            entitiesRecordsListLabel.Visible = false;
            timer1.Enabled = true;
            btnRecordVoice.Enabled = false;
            btnSave.Enabled = true;
            btnSpeechInfo.Enabled = false;
            btnFindRelated.Enabled = false;
        }
        
        private  void btnSpeechInfo_Click(object sender, EventArgs e)
        {
            if (File.Exists("audio.raw"))
            {
                var speech = SpeechClient.Create();
                bool currentAutoPunctuation=currentLanguage=="en"?true:false;
                var response = speech.Recognize(new RecognitionConfig()
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                    SampleRateHertz = 8000,
                    LanguageCode = currentLanguage,
                    EnableAutomaticPunctuation=currentAutoPunctuation
                }, RecognitionAudio.FromFile("audio.raw"));
                textBox1.Text = "";
                foreach (var result in response.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        speechConverter.OutputData= textBox1.Text + " " + alternative.Transcript;
                    }
                }
                textBox1.Text = speechConverter.OutputData;
                if (textBox1.Text.Length == 0)
                    textBox1.Text = "No data";
                speechConverter.OutputData = textBox1.Text;
            }
            else
            {
                textBox1.Text = "Audio File Missing";
                return;
            }
            if (textBox1.Text!="No data"&&SaveFileDialog.FileName!="")
            {
                TextFileCreator textFileCreator = new TextFileCreator(SaveFileDialog.FileName);
                textFileCreator.WriteToFile(textBox1.Text);
            }
            if (openFileDialog1.FileName!="")
            {
                TextFileCreator textFileCreator = new TextFileCreator(openFileDialog1.FileName);
                textFileCreator.WriteToFile(textBox1.Text);
            }
            menuStrip1.Enabled = true;
            btnRecordVoice.Enabled = true;
            btnSave.Enabled = false;
            btnSpeechInfo.Enabled = false;
            btnFindRelated.Enabled = false;
        }

        private void btnFindRelated_Click(object sender, EventArgs e)
        {
            speechConverter.IsRecording = false;
            entitiesRecordsListLabel.Visible = true;
            comboBox1.Visible = true;
            if (File.Exists("audio.raw"))
            {
                var speech = SpeechClient.Create();
                bool currentAutoPunctuation = currentLanguage == "en" ? true : false;
                var response = speech.Recognize(new RecognitionConfig()
                {
                    Encoding = RecognitionConfig.Types.AudioEncoding.Linear16,
                    SampleRateHertz = 8000,
                    LanguageCode = currentLanguage,
                    EnableAutomaticPunctuation = currentAutoPunctuation
                }, RecognitionAudio.FromFile("audio.raw"));
                textBox1.Text = "";
                foreach (var result in response.Results)
                {
                    foreach (var alternative in result.Alternatives)
                    {
                        speechConverter.OutputData = textBox1.Text + " " + alternative.Transcript;
                    }
                }

                textBox1.Text = speechConverter.OutputData;
            }
            else
            {
                textBox1.Text = "Audio File Missing";
                return;
            }
            PushInEntitiesCombobox();

            menuStrip1.Enabled = true;
            btnRecordVoice.Enabled = true;
            btnSave.Enabled = false;
            btnSpeechInfo.Enabled = false;
            btnFindRelated.Enabled = false;
        }

        private void PushInEntitiesCombobox()
        {
            DataStorage dataStorage = new DataStorage(speechConverter.OutputData, XmlWriting: false);
            XMLSearcher xMLSearcher = new XMLSearcher(dataStorage.ParsedData);
            uint maxRecordsLeft = maxValuesInEntitiesCombobox;
            if (earlyRecordsFirst)
            {
                foreach (var item in xMLSearcher.timesList)
                {
                    if (maxRecordsLeft==0)
                    {
                        return;
                    }
                    comboBox1.Items.Add(item);
                    maxRecordsLeft--;
                }
            }
            else
            {
                for (int i = xMLSearcher.timesList.Count-1; i >= 0; i--)
                {
                    if (maxRecordsLeft == 0)
                    {
                        return;
                    }
                    comboBox1.Items.Add(xMLSearcher.timesList[i]);
                    maxRecordsLeft--;
                }
            }
        }

        private void createToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                speechConverter.IsFileNew = true;
                speechConverter.FilePath = SaveFileDialog.FileName;
            }
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog()==DialogResult.OK)
            {
                speechConverter.IsFileNew = false;
                speechConverter.FilePath = openFileDialog1.FileName;
                using (StreamReader streamReader = new StreamReader(openFileDialog1.FileName))
                {
                    DataStorage dataStorage = new DataStorage(streamReader.ReadToEnd(), XmlWriting:false);
                    dataStorage.DataToParse = streamReader.ReadToEnd();
                }
            }
        }

        private void ResetTimer()
        {
            timer1.Enabled = false;
            label1.Text = "00";
            date1 = new DateTime(0, 0);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            date1 = date1.AddSeconds(1);
            label1.Text = date1.ToString("ss");
            if (label1.Text=="59")
            {
                StopCurrentRecording();
            }
        }

        private void StopCurrentRecording()
        {
            speechConverter.IsRecording = false;
            ResetTimer();
            speechConverter.SaveNewAudio();
            btnRecordVoice.Enabled = true;
            btnSave.Enabled = false;
            btnSpeechInfo.Enabled = true;
            btnFindRelated.Enabled = true;
        }

        private void chooseLanguageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LanguageForm languageForm = new LanguageForm();
            languageForm.ShowDialog();
            if (languageForm.CurrentLanguage=="русский")
            {
                currentLanguage = "ru";
            }
            if (languageForm.CurrentLanguage=="english")
            {
                currentLanguage = "en";
            }
        }

      
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("D:\\Projects\\SpeechHelper\\SpeechHelper\\EntitiesStorage.xml");
            XmlElement xRoot = doc.DocumentElement;
            foreach (XmlElement record in xRoot)
            {
                XmlNode timeAttr = record.Attributes.GetNamedItem("time");
                XmlNode textElem = record.ChildNodes.Item(1);
                if (timeAttr.InnerText == comboBox1.SelectedItem.ToString())
                {
                    textBox1.Text = textElem.InnerText;
                }
            }
        }


        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void deleteRecordsToolStripMenu_Click(object sender, EventArgs e)
        {
            DeleteRecordsForm deleteRecordsForm = new DeleteRecordsForm();
            deleteRecordsForm.ShowDialog();
        }

        private void settingsToolStripMenu_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.ShowDialog();
            earlyRecordsFirst = settingsForm.IsEarlyFirst;
            maxValuesInEntitiesCombobox = settingsForm.MaxValuesInEntitiesList;
            currentCoefOfSimilarity = settingsForm.CurrentCoefOfSimilarity;
            rememberNewEntities = settingsForm.RememberNewEntities;
        }

    }
}
