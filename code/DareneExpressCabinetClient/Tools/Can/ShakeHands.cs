using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DareneExpressCabinetClient.Tools
{
    class ShakeHands:IFilter
    {
        public bool Filter(object obj)
        {
            bool ret = false;
            VCI_CAN_OBJ pdu = (VCI_CAN_OBJ)obj;

            return ret;
        }
    }
}
