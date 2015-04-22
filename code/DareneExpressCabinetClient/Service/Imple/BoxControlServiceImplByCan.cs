using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DareneExpressCabinetClient.Tools;
using DareneExpressCabinetClient.Resource;
using Domain;

namespace DareneExpressCabinetClient.Service.Imple
{
    class BoxControlServiceImplByCan:BoxControlService
    {
        /// <summary>
        /// 是否是调试模式，调试模式不连接can
        /// </summary>
        private static bool isDebug = false;

        /// <summary>
        /// 发送命令延时时间，单位100ms
        /// </summary>
        private static byte timeout = 2;

        public bool Open(int code)
        {
            bool success = false;
            ELock eLock = ELocksManager.GetInstance().GetLock(code);
            if (eLock == null)
            {
                CLog4net.LogError("根据柜号:"+code+" 寻找锁号失败:eLock==nulll");
                return false;
            }
            if ( eLock.BoxCode == 0)
            {
                CLog4net.LogError("根据柜号:" + code + " 寻找锁号失败:eLock.BoxCode == 0");
                return false;
            }
            try
            {
                if (isDebug)
                {
                    return true;
                }

                VCI_CAN_OBJ obj = PDUProducter.CreateOpenCmd(Convert.ToUInt32(eLock.Address), Convert.ToUInt32(eLock.Password), Convert.ToInt32(eLock.Value), timeout);
                VCI_CAN_OBJ response = CanManager.GetInsatnce().SendPdu(obj);
                if (response.Data != null)
                {
                    bool parameterLegal = response.Data[0] == 1 ? true : false;
                    bool passwordPass = response.Data[1] == 1 ? true : false;
                    bool isReceivedData = response.Data[2] == 1 ? true : false;


                    success = (isReceivedData & passwordPass & parameterLegal) == true ? true : false;

                    if (!success)
                    {
                        CLog4net.LogError("Can发送开箱 "+"parameterLegal:" + parameterLegal + " passwordPass" + passwordPass + " parameterLegal" + parameterLegal);
                    }
                }
                else
                {
                    CLog4net.LogError("Can发送开箱 " + "response.Data == null");
                }
                
            }
            catch (Exception e)
            {
                CLog4net.LogError("Can控制器OPEN异常: "+e.ToString());
                return false;
            }
            return success;
        }

        public bool Close(int code)
        {
            return true;
        }

        public Box.State GetCurrentState(int code)
        {
            return Box.State.Close;
        }

        public void Dispose()
        {
            CanManager.GetInsatnce().Dispose();
        }

        public bool Init()
        {
            IniConfigManager iniconfig = new IniConfigManager();
            try
            {
                timeout = Convert.ToByte(iniconfig.GetCanTimeout());
                if (iniconfig.GetCanDebug().Equals("true"))
                {
                    isDebug = true;
                }
            }
            catch (Exception e)
            {
                isDebug = false;
                timeout = 2;
                CLog4net.LogError("读Can ini错误:" + e);
            }

            return CanManager.GetInsatnce().Load();
        }
    }
}
