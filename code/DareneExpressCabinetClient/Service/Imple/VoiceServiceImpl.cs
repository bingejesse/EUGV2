using System;
using DareneExpressCabinetClient.Tools;

namespace DareneExpressCabinetClient.Service.Imple
{
    /**
     * 使用WIN7的windows api，其实最终还是调用了SAPI，所以开发出来的东西就只能在WIN7上面跑。 
     * 
     * */
    class VoiceServiceImpl:VoiceService
    {
        private CSoundPlayer player = new CSoundPlayer();

        #region VoiceService 成员

        public void BroadcastOnce(string key)
        {
            //player.StartPlaying(key);
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
