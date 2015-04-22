using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading;
using Domain;

namespace DareneExpressCabinetClient.Tools
{
    //*********************************************************************************************************
    // 定义初始化CAN的数据类型
    //*********************************************************************************************************
    [StructLayout(LayoutKind.Sequential)]
    public struct VCI_INIT_CONFIG
    {
        public int AccCode;
        public int AccMask;
        public int Reserved;
        public byte Filter;
        public byte Timing0;
        public byte Timing1;
        public byte Mode;
    }

    //*********************************************************************************************************
    // 定义CAN信息帧的数据类型
    //*********************************************************************************************************

    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    public struct VCI_CAN_OBJ
    {
        public uint ID;
        public uint TimeStamp;
        public byte TimeFlag;
        public byte SendType;   //0正常发送，1单次发送，2自发自收，3单次自发自收
        public byte RemoteFlag;
        public byte ExternFlag;
        public byte DataLen;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public Byte[] Data;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] Reserved;

        /// <summary>
        /// 控制板序列号
        /// </summary>
        public uint Address
        {
            get
            {
                uint data = (ID >> 20) & 0xff;
                return data;
            }
            set
            {
                uint tempUrl = (value << 20) & 0xff00000;
                uint tempId = ID & 0x300fffff;
                ID = tempUrl | tempId;
            }
        }

        /// <summary>
        /// 密码
        /// </summary>
        public uint Password
        {
            get
            {
                uint data = ID & 0xfffff;
                return data;
            }
            set
            {
                uint tempPass = value & 0xfffff;
                uint tempId = ID & 0x3ff00000;
                ID = tempId | tempPass;
            }
        }

        //public bool IsShakeHand
        //{
        //    get
        //    {
        //        uint data = ID >> 28 & 0x01;
        //        return data == 1 ? true : false;
        //    }
        //    set
        //    {
        //        uint data = Convert.ToUInt32(value) << 28;
        //        uint tempId = ID & 0x0fffffff;
        //        ID = data | tempId;
        //    }
        //}

        
        /// <summary>
        /// 是否为回应帧
        /// </summary>
        public bool IsResponse
        {
            get
            {
                uint data = ID >> 28 & 0x01;
                return data == 0 ? true : false;
            }
            set
            {
                uint data = Convert.ToUInt32(value) << 28;
                uint tempId = ID & 0x0fffffff;
                ID = data | tempId;
            }
        }

        /// <summary>
        /// 是否为请求帧
        /// </summary>
        public bool IsRequest
        {
            get
            {
                uint data = ID >> 28 & 0x01;
                return data == 1 ? true : false;
            }
            set
            {
                uint data = Convert.ToUInt32(value) << 28;
                uint tempId = ID & 0x0fffffff;
                ID = data | tempId;
            }
        }
        
    }
    //*********************************************************************************************************
    // 定义错误信息的数据类型 :
    //*********************************************************************************************************
    [StructLayout(LayoutKind.Sequential)]
    public struct VCI_ERR_INFO
    {
        public int ErrCode;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public byte[] passive_ErrData;
        public byte ArLost_ErrData;
    }

    public delegate void CANOBJHANDLE(VCI_CAN_OBJ obj);
    public class UsbCanCom
    {
        #region Can数据结构
        //*********************************************************************************************************
        // 定义的全局变量
        //*********************************************************************************************************
        int m_devtype = 4;
        int m_devind = 0;
        int m_canind = 0;

        bool m_connect = false;
        public static event CANOBJHANDLE CANEvnet;
        System.Threading.Thread RecThread;
        //public static UsbCanCom Instance = new UsbCanCom();

        //*********************************************************************************************************
        // 声明DLL的导出函数
        //*********************************************************************************************************
        [System.Runtime.InteropServices.DllImport("ECanVci", SetLastError = true)]
        extern static int VCI_OpenDevice(int DeviceType, int DeviceInd, int Reserved);

        [System.Runtime.InteropServices.DllImport("ECanVci", SetLastError = true)]
        extern static int VCI_InitCAN(int DeviceType, int DeviceInd, int CANInd, ref VCI_INIT_CONFIG pInitConfig);

        [System.Runtime.InteropServices.DllImport("ECanVci", SetLastError = true)]
        extern static int VCI_StartCAN(int DeviceType, int DeviceInd, int CANInd);

        [System.Runtime.InteropServices.DllImport("ECanVci", SetLastError = true)]
        extern static int VCI_Transmit(int DeviceType, int DeviceInd, int CANInd, ref VCI_CAN_OBJ pSend, int Len);

        [System.Runtime.InteropServices.DllImport("ECanVci", SetLastError = true)]
        extern static int VCI_ResetCAN(int DeviceType, int DeviceInd, int CANInd);

        [System.Runtime.InteropServices.DllImport("ECanVci", SetLastError = true)]
        extern static int VCI_CloseDevice(int DeviceType, int DeviceInd);

        [System.Runtime.InteropServices.DllImport("ECanVci", SetLastError = true)]
        extern static int VCI_Receive(int DeviceType, int DeviceInd, int CANInd, ref VCI_CAN_OBJ pReceive, int Len, int WaitTime);

        [System.Runtime.InteropServices.DllImport("ECanVci", SetLastError = true)]
        extern static int VCI_ReadErrInfo(int DeviceType, int DeviceInd, int CANInd, ref VCI_ERR_INFO pErrInfo);
        #endregion

        public int OpenDevice()
        {
            return VCI_OpenDevice(m_devtype, m_devind, m_canind);
        }

        public int StartCAN(byte time1, byte time2)
        {
            VCI_INIT_CONFIG config = new VCI_INIT_CONFIG();
            config.AccCode = 0;
            config.AccMask = -1;
            config.Filter = 0;
            config.Mode = 0;
            config.Timing0 = time1;
            config.Timing1 = time2;

            int rel = VCI_InitCAN(m_devtype, m_devind, m_canind, ref config);

            rel = VCI_StartCAN(m_devtype, m_devind, m_canind);
            return rel;

        }

        public int SendFrame(VCI_CAN_OBJ obj, int canIndex, int len)
        {
            try
            {
                //TimeTest time = new TimeTest();
                //time.BeginTest();

                System.Threading.Thread.Sleep(1);
                int result = VCI_Transmit(m_devtype, m_devind, canIndex, ref obj, len);
                //double span = time.SpanTime();

                //CLog4net.LogInfo("SendFrame：" + obj.ID + " SpendTime:"+span);
                return result;
            }
            catch (Exception e)
            {
                CLog4net.LogInfo("SendFrame：" + e.ToString());
                return -1;
            }
        }

        public int SendFrames(VCI_CAN_OBJ[] obj, int canIndex)
        {
            System.Threading.Thread.Sleep(1);
            return VCI_Transmit(m_devtype, m_devind, canIndex, ref obj[0], obj.Length);
        }
        public int CloseDevice()
        {
            m_connect = false;
            Thread.Sleep(1);
            return VCI_CloseDevice(m_devtype, m_devind);
        }
        public void StartRecv()
        {
            RecThread = new Thread(new ThreadStart(RecvFrame));
            RecThread.Start();
        }
        public void StopRecv()
        {
            if (RecThread != null)
            {
                RecThread.Abort();
                RecThread = null;
            }
        }
        private void RecvFrame()
        {
            m_connect = true;
            VCI_CAN_OBJ obj1 = new VCI_CAN_OBJ();

            while (m_connect)
            {
                Thread.Sleep(1);
                int rel1 = VCI_Receive(m_devtype, m_devind, m_canind, ref obj1, 1, 20);
                //int rel2 = VCI_Receive(m_devtype, m_devind, 1,  obj2, 1, 10);
                if (rel1 > 0 && CANEvnet != null)
                {
                    for (int i = 0; i < rel1; i++)
                    {
                        CANEvnet(obj1);
                    }
                }
            }
        }
    }
}
