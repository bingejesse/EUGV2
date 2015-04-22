
using DareneExpressCabinetClient.Service.Factory;
using DareneExpressCabinetClient.Service;
using System.Collections;
using System.Collections.Generic;

namespace DareneExpressCabinetClient.Resource
{
    public class CommLister
    {
        private static CommLister instance;

        public static CommLister GetInstance()
        {
            if (instance == null)
            {
                instance = new CommLister();
            }

            return instance;
        }

        private ServerService serverService;

        private CommLister()
        {
            this.serverService = ServicesFactory.GetInstance().GetServerService();
        }

        private ServerCallback3 state;
        /// <summary>
        /// 当前服务器连接状态
        /// </summary>
        public ServerCallback3 State
        {
            get { return state; }
            set { state = value; }
        }

        private void ServerSateListenLogic()
        {
            this.state = this.serverService.ServiceShakeHand(AboutConfig.GetInstance().GetAbout(),GetDevicesStatus());

            if (this.state == null || this.state.Success == false)
            {
                CemmberData.Instance.IsServerConnectFail = true;
            }
            else
            {
                CemmberData.Instance.IsServerConnectFail = false;
            }
        }

        private IDictionary<string,string> GetDevicesStatus()
        {
            IDictionary<string, string> dic = new Dictionary<string, string>();
            if (CemmberData.Instance.IsCanConnectFail)
            {
                dic.Add("camera", "camera:ok");
            }
            else
            {
                dic.Add("camera", "camera:failure");
            }

            if (CemmberData.Instance.IsCameraConnectFail)
            {
                dic.Add("comcard", "comcard:ok");
            }
            else
            {
                dic.Add("comcard", "comcard:failure");
            }

            return (IDictionary<string,string>)dic;
        }

        public void LogicInterface()
        {
            this.ServerSateListenLogic();
        }
    }
}
