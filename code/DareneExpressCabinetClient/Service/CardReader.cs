using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DareneExpressCabinetClient.Service
{
    delegate string ListenDeviceHandle();
    interface CardReader
    {
        event ListenDeviceHandle DeviceEvent;
    }
}
