using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace SpeechHelper
{
    public partial class DeleteRecordsForm : Form
    {
        private DateTime firstDate;
        private DateTime secondDate;
        public DeleteRecordsForm()
        {
            InitializeComponent();
            firstDate = DateTime.Now;
            secondDate = DateTime.Now; 
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            firstDate = dateTimePicker1.Value;
        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {
            secondDate = dateTimePicker2.Value;
        }

        public void Delete()
        { //доделать чтобы все удалялись
            XmlDocument doc = new XmlDocument();
            doc.Load("D:\\Projects\\SpeechHelper\\SpeechHelper\\EntitiesStorage.xml");
            XmlElement xRoot = doc.DocumentElement;
            foreach (XmlNode record in xRoot)
            {
                XmlNode timeAttr = record.Attributes.GetNamedItem("time");
                if (DateTime.Compare(DateTime.Parse(timeAttr.InnerText), firstDate)>=0&&DateTime.Compare(DateTime.Parse(timeAttr.InnerText), secondDate)<0)
                {
                    xRoot.RemoveChild(record);
                }
            }
            doc.Save("D:\\Projects\\SpeechHelper\\SpeechHelper\\EntitiesStorage.xml");
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            Delete();
            this.Close();
        }
    }
}
