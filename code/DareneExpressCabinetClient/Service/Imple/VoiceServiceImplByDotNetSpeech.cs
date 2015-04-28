using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetSpeech;
using Domain;

namespace DareneExpressCabinetClient.Service.Imple
{
    /**
     * 使用COM组件技术，不管是C++，C#,Delphi都能玩的转，开发出来的东西在XP和WIN7都能跑。
     * 引用DotNetSpeech.dll，嵌入互操作类型改成false，复制到本地改成true
     * */
    class VoiceServiceImplByDotNetSpeech : VoiceService
    {
        public void BroadcastOnce(string key)
        {
            Read(key);
        }

        public void BroadcastLooping(string key)
        {
            Read(key);
        }

        public void StopBroadcast()
        {
            Stop();
        }

        private static SpVoice voice;
        private static SpeechVoiceSpeakFlags sFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;

        public VoiceServiceImplByDotNetSpeech()
        {
            try
            {
                if (voice == null)
                {
                    voice = new SpVoice();
                    sFlags = SpeechVoiceSpeakFlags.SVSFlagsAsync;
                    setDescription("VW Lily");
                }
            }
            catch (Exception e)
            {
                CLog4net.LogError("语音初始化错误" + e);
            }
        }

        private void Read(string text)
        {
            try
            {
                if (voice != null && string.IsNullOrEmpty(text) == false)
                {
                    if (voice.Status.RunningState == SpeechRunState.SRSEIsSpeaking)
                    {
                        voice.Speak(string.Empty, SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
                    }
                    voice.Speak(text, sFlags);
                }
            }
            catch (Exception e)
            {
                CLog4net.LogError("语音播报错误" + e);
            }
        }

        private void Stop()
        {
            try
            {
                if (voice != null)
                {
                    voice.Speak(string.Empty, SpeechVoiceSpeakFlags.SVSFPurgeBeforeSpeak);
                }
            }
            catch (Exception e)
            {
                CLog4net.LogError("语音播报停止错误" + e);
            }
        }

        /// <summary>
        /// 设置当前使用语音库
        /// </summary>
        /// <returns>bool</returns>
        private bool setDescription(string name)
        {
            List<string> list = new List<string>();
            DotNetSpeech.ISpeechObjectTokens obj = voice.GetVoices();
            int count = obj.Count;//获取语音库总数
            for (int i = 0; i < count; i++)
            {
                string desc = obj.Item(i).GetDescription(); //遍历语音库
                if (desc.Equals(name))
                {
                    voice.Voice = obj.Item(i);
                    return true;
                }
            }
            return false;
        }
    }
}
