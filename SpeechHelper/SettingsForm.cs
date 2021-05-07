using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpeechHelper
{
    public partial class SettingsForm : Form
    {
        public bool IsEarlyFirst { get; private set; }
        public uint MaxValuesInEntitiesList { get; private set; }
        public int CurrentCoefOfSimilarity { get; private set; }
        public bool RememberNewEntities { get; private set; }

        public SettingsForm()
        {
            InitializeComponent();
            radioButton1.Checked = Form1.earlyRecordsFirst;
            radioButton2.Checked = !Form1.earlyRecordsFirst;
            numericUpDown1.Value = Form1.maxValuesInEntitiesCombobox;
            trackBar1.Value = Form1.currentCoefOfSimilarity;
            rememberCheckBox.Checked = Form1.rememberNewEntities;
            percentageValueLabel.Text = (trackBar1.Value*10).ToString() + "%";
            CurrentCoefOfSimilarity = trackBar1.Value;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            MaxValuesInEntitiesList = (uint)numericUpDown1.Value;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (Form1.earlyRecordsFirst)
            {
                IsEarlyFirst = false;
            }
            else
            {
                IsEarlyFirst = true;
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            percentageValueLabel.Text = (trackBar1.Value*10).ToString()+"%";
            CurrentCoefOfSimilarity = trackBar1.Value;
        }

        private void rememberCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            RememberNewEntities = rememberCheckBox.Checked;
        }
    }
}
