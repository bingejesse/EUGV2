using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;
using System;
using DareneExpressCabinetClient.Resource;
using Domain;

namespace DareneExpressCabinetClient.Tools
{
    class CanManager : IDisposable
    {
        private UsbCanCom usbCanCom;
        private DataFilter dataFilter;
        //默认信号为不发送状态
        private static ManualResetEvent mre = new ManualResetEvent(false);

        /// <summary>
        /// 等待帧回复时间，单位ms
        /// </summary>
        private const int responseTime =100;

        private static CanManager instance;

        public static CanManager GetInsatnce()
        {
            if (instance == null)
            {
                instance = new CanManager();
            }

            return instance;
        }

        /// <summary>
        /// can是否打开
        /// </summary>
        private bool isOpen = false;

        public bool Load()
        {
            if (isOpen)
            {
                return true;
            }

            try
            {
                this.usbCanCom = new UsbCanCom();
                int rel = this.usbCanCom.OpenDevice();
                byte time1 = 0x01;
                byte time2 = 0x1c;
                this.usbCanCom.StartCAN(time1, time2);
                this.usbCanCom.StartRecv();
                if (rel == 0)
                {
                    CemmberData.Instance.IsCanConnectFail = true;
                    CLog4net.LogError("数据链路打开失败");
                    return false;
                }
                this.shakehandsFrame.ID = 0xFFFFFFFF;
                UsbCanCom.CANEvnet += new CANOBJHANDLE(UsbCanCom_CANEvnet);
                this.isOpen = true;

                this.dataFilter = new DataFilter();
                CemmberData.Instance.IsCanConnectFail = false;
                return true;
            }
            catch(Exception e)
            {
                CemmberData.Instance.IsCanConnectFail = true;
                CLog4net.LogError("CanManager load:" + e);
                return false;
            }
        }

        void UsbCanCom_CANEvnet(VCI_CAN_OBJ obj)
        {
            bool isFilter = dataFilter.DoJob(obj);

            if (isFilter)
            {
                return;
            }

            if (obj.IsResponse && obj.Address == this.shakehandsFrame.Address)
            {
                this.shakehandsFrame = obj;
                CanManager.mre.Set();
                return;
            }
        }

        #region 发送
        public VCI_CAN_OBJ SendPdu(VCI_CAN_OBJ obj)
        {
            VCI_CAN_OBJ response = new VCI_CAN_OBJ();
            response.ID = 0;
            if (this.usbCanCom.SendFrame(obj, 0, 8) == -1)
            {
                return response;
            }

            if (obj.IsRequest)
            {
                lock (this)
                {
                    if (WaitResponse(obj.ID))
                    {
                        response = this.shakehandsFrame;
                        this.shakehandsFrame.ID = 0xFFFFFFFF;
                    }
                }
            }

            return response;
        }

        private VCI_CAN_OBJ shakehandsFrame = new VCI_CAN_OBJ();
        private bool WaitResponse(uint id)
        {
            bool ret = false;
            this.shakehandsFrame.ID = id;
            this.shakehandsFrame.IsResponse = true;
            CanManager.mre.Reset();
            if (CanManager.mre.WaitOne(CanManager.responseTime))
            {
                ret = true;
            }
            else
            {
                ret = false;
            }

            return ret;
        }
        #endregion

        #region 解析数据
        
        #endregion

        public void Dispose()
        {
            if (this.isOpen)
            {
                this.usbCanCom.CloseDevice();
            }
            this.usbCanCom.StopRecv();
        }
    }
}