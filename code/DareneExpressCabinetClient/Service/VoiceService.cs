using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DareneExpressCabinetClient.Service
{
    public interface VoiceService
    {
        void BroadcastOnce(string key);

        void BroadcastLooping(string key);

        void StopBroadcast();
    }
}
