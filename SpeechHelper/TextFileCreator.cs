using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Google.Cloud.Language.V1;
using static Google.Cloud.Language.V1.AnnotateTextRequest.Types;

namespace SpeechHelper
{
    class TextFileCreator:IDisposable
    {
        public static string FilePath { get; set; }
        private bool rememberNewEntities;
       
        public TextFileCreator(string filePath)
        {
            FilePath = filePath;
            rememberNewEntities = Form1.rememberNewEntities;
        }

        public void WriteToFile(string dataToWrite)
        {
            using (StreamWriter streamWriter = new StreamWriter(FilePath, true))
            {
                streamWriter.WriteLine(dataToWrite);
                DataStorage dataStorage = new DataStorage(dataToWrite, XmlWriting:rememberNewEntities);
                streamWriter.WriteLine(dataStorage.DataToParse);
                streamWriter.Close();
            }
        }


        public void Dispose()
        {
        }
    }
}
