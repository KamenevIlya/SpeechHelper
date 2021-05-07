using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml;




namespace SpeechHelper
{
    class XMLWriter
    {
        private string[] Entities { get; set; }
        private string[] Types { get; set; }
        private string Data { get; set; }

        public XMLWriter(string[]entities,string[]dataTypes, string dataToWrite)
        {
            for (int i = 0; i < entities.Length; i++)
            {
                Entities[i] = entities[i];
            }
            for (int i = 0; i < dataTypes.Length; i++)
            {
                Types[i] = dataTypes[i];
            }
            Data = dataToWrite;
        }

        public void Write()
        {
            uint counter = 1;
            XmlDocument doc = new XmlDocument();
            doc.Load("D:\\Projects\\SpeechHelper\\SpeechHelper\\EntitiesStorage.xml");
            XmlElement xRoot = doc.DocumentElement;
            XmlElement newRecordElem = doc.CreateElement("record");
            XmlAttribute timeAttr = doc.CreateAttribute("time");

            XmlElement entitiesElem = doc.CreateElement("entities");
            XmlElement textElem = doc.CreateElement("text");
            XmlText timeText = doc.CreateTextNode(DateTime.Now.ToString());
            XmlText recordText = doc.CreateTextNode(Data);




            for (int i = 0; i < Entities.Length; i++)
            {
                XmlElement entityElem = doc.CreateElement("entity");
                XmlText entityText = doc.CreateTextNode(Entities[i]);

                XmlAttribute numberAttr = doc.CreateAttribute("number");
                XmlText numberText = doc.CreateTextNode(counter.ToString());

                XmlAttribute typeAttr = doc.CreateAttribute("type");
                XmlText typeText = doc.CreateTextNode(Types[i]);

                numberAttr.AppendChild(numberText);
                typeAttr.AppendChild(typeText);
                entityElem.Attributes.Append(numberAttr);
                entityElem.Attributes.Append(typeAttr);
                entityElem.AppendChild(entityText);
                entitiesElem.AppendChild(entityElem);
                counter++;

            }

            timeAttr.AppendChild(timeText);
            textElem.AppendChild(recordText);
            newRecordElem.Attributes.Append(timeAttr);
            newRecordElem.AppendChild(entitiesElem);
            newRecordElem.AppendChild(textElem);
            xRoot.AppendChild(newRecordElem);

            doc.Save("D:\\Projects\\SpeechHelper\\SpeechHelper\\EntitiesStorage.xml");
        }

    }
}
