using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Google.Cloud.Language.V1;
using System.IO;
using System.Xml;
using Google.Apis.CloudNaturalLanguage;
using static Google.Cloud.Language.V1.AnnotateTextRequest.Types;


namespace SpeechHelper
{
    class DataStorage
    {
        public string DataToParse { get; set; }
        private static uint counter = 0;
        public string[] ParsedData;
        private string[] ParsedDataTypes;

        

        public DataStorage(string dataForParsing,bool XmlWriting)
        {
            NaturalLanguageProcess(dataForParsing);
            if (XmlWriting==true)
            {
                XMLWriter xMLWriter = new XMLWriter(ParsedData, ParsedDataTypes, dataForParsing);
                xMLWriter.Write();
            }
        }
        private void NaturalLanguageProcess(string dataForParsing)
        {
            var client = LanguageServiceClient.Create();
            var response = client.AnalyzeEntities(Document.FromPlainText(dataForParsing));
            int localcounter = 0;
            foreach (var entity in response.Entities)
            {
                localcounter++;
            }
            ParsedData = new string[localcounter]; 
            ParsedDataTypes = new string[localcounter];

            foreach (var entity in response.Entities)
            {
                ParsedData[counter]= entity.Name;
                ParsedDataTypes[counter] = entity.Type.ToString();
                counter++;
            }
            counter = 0;
        }
    }
}
