using System;
using DareneExpressCabinetClient.Tools;

namespace DareneExpressCabinetClient.Service.Imple
{
    class VoiceServiceImpl:VoiceService
    {
        private CSoundPlayer player = new CSoundPlayer();

        #region VoiceService 成员

        public void BroadcastOnce(string key)
        {
            player.StartPlaying(key);
        }

        public void BroadcastLooping(string key)
        {
            player.PlayLooping(key);
        }

        public void StopBroadcast()
        {
            player.StopPlaying();
        }

        #endregion
    }
}
