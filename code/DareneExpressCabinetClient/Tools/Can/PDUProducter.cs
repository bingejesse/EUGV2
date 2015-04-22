using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DareneExpressCabinetClient.Tools
{
    class PDUProducter
    {
        /// <summary>
        /// 开门命令，带延时关闭
        /// </summary>
        /// <param name="address"></param>
        /// <param name="password"></param>
        /// <param name="boxCode"></param>
        /// <param name="delayTime">延时时间,单位100ms</param>
        /// <returns></returns>
        public static VCI_CAN_OBJ CreateOpenCmd(uint address, uint password,int boxCode,byte delayTime)
        {
            VCI_CAN_OBJ obj = new VCI_CAN_OBJ();
            obj.Address = address;
            obj.Password = password;
            obj.SendType = 0;
            obj.RemoteFlag = 0;
            obj.ExternFlag = 1;
            obj.Reserved = new byte[3];
            obj.Data = new byte[8];
            obj.DataLen = 8;

            obj.IsRequest = true;
            obj.Data[0] = Convert.ToByte(boxCode);
            obj.Data[1] = delayTime;
            obj.Data[2] = 0xff;
            obj.Data[3] = 0x04;

            return obj;
        }

        /// <summary>
        /// 查询状态
        /// </summary>
        /// <param name="url"></param>
        /// <param name="password"></param>
        /// <param name="boxCode"></param>
        /// <returns></returns>
        public static VCI_CAN_OBJ CreateGetInfoCmd(uint address, uint password, int boxCode)
        {
            VCI_CAN_OBJ obj = new VCI_CAN_OBJ();
            obj.Address = address;
            obj.Password = password;
            obj.SendType = 0;
            obj.RemoteFlag = 0;
            obj.ExternFlag = 1;
            obj.Reserved = new byte[3];
            obj.Data = new byte[8];
            obj.DataLen = 8;

            obj.IsRequest = true;
            obj.Data[0] = Convert.ToByte(boxCode);
            obj.Data[1] = 0xff;
            obj.Data[3] = 0xff;
            obj.Data[4] = 0x12;

            return obj;
        }
    }
}
