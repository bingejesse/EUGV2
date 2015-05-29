using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Media;
using System.IO;
using System.Speech.Synthesis;

namespace DareneExpressCabinetClient.Tools
{
    public class CSoundPlayer
    {

        private static SpeechSynthesizer synth = new SpeechSynthesizer();

        public CSoundPlayer()
        {
            //InitResources();
        }

        private void InitResources()
        {
            synth.Rate = 1;
            synth.Volume = 100;
        }

        public void PlayLooping(String key)
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.Write(ex.Message, "Error playing sound");
            }
        }

        public void StartPlaying(string key)
        {
            try
            {
                synth.SpeakAsyncCancelAll();
                synth.SpeakAsync(key);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message, "Error playing sound");
            }
        }

        public void StopPlaying()
        {
            synth.SpeakAsyncCancelAll();
        }
    }
}

