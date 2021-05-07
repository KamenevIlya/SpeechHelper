using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace SpeechHelper
{
    class XMLSearcher
    {
        public List<string> timesList=new List<string>();
        private int currentCoedOfSimilarity=Form1.currentCoefOfSimilarity;
        public XMLSearcher(string[]newEntities)
        {
            XmlDocument doc = new XmlDocument();
            doc.Load("D:\\Projects\\SpeechHelper\\SpeechHelper\\EntitiesStorage.xml");
            XmlElement xRoot = doc.DocumentElement;
            foreach (XmlElement record in xRoot)
            {
                bool IsEntityFound = false;
                uint counter = 0;
                XmlNode timeAttr = record.Attributes.GetNamedItem("time");
                XmlNode entitiesElem = record.ChildNodes.Item(0);
                foreach (XmlNode entity in entitiesElem)
                {
                    for (int i = 0; i < newEntities.Length; i++)
                    {
                        if (entity.InnerText == newEntities[i])
                        {
                            counter++;
                            IsEntityFound = true;
                        }
                    }
                }
                
                if (IsEntityFound&&(counter/entitiesElem.ChildNodes.Count)>=(currentCoedOfSimilarity/10)) ///проверить
                {
                    timesList.Add(timeAttr.InnerText);
                }
            }
        }
    }
}
