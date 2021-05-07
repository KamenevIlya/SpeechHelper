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
using Google.Cloud.Language.V1;
using NAudio.Wave;
using Grpc.Auth;
using System.Threading;

namespace SpeechHelper
{
    
    class SpeechConverter
    {
        private BufferedWaveProvider bwp;
        private WaveIn waveIn;
        private WaveFileWriter writer;
        private readonly string output = "audio.raw";

        public string OutputData { get; set; }
        public string FilePath { get;  set; }
        public bool IsRecording { get;set; }
        public bool IsFileNew { get; set; }


        public void Initializate()
        {
            waveIn = new WaveIn();

            waveIn.DataAvailable += new EventHandler<WaveInEventArgs>(waveIn_DataAvailable);
            waveIn.WaveFormat = new NAudio.Wave.WaveFormat(16000, 1);
            bwp = new BufferedWaveProvider(waveIn.WaveFormat);
            bwp.DiscardOnBufferOverflow = true;
        }
        void waveIn_DataAvailable(object sender, WaveInEventArgs e)
        {
            writer.Write(e.Buffer, 0, e.BytesRecorded);
        }
       
        public void SaveNewAudio()
        {
            waveIn.StopRecording();
            waveIn.Dispose();
            waveIn = null;
        }


        private void waveIn_RecordingStopped(object sender, EventArgs e)
        {
            writer.Close();
            writer = null;
        }

        public void StartNewRecording()
        {
            if (NAudio.Wave.WaveIn.DeviceCount < 1)
            {
                Console.WriteLine("No microphone!");
                return;
            }
            waveIn = new WaveIn();
            waveIn.DataAvailable += waveIn_DataAvailable;
            waveIn.RecordingStopped += new EventHandler<StoppedEventArgs>(waveIn_RecordingStopped);
            writer = new WaveFileWriter(output, waveIn.WaveFormat);
            waveIn.StartRecording();

        }
    }
}
