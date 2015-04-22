
using DareneExpressCabinetClient.Service;
using DareneExpressCabinetClient.Service.Factory;


namespace DareneExpressCabinetClient.Resource
{
    public class InfoCenterLister
    {
        private ServerCallback3 state;
        /// <summary>
        /// 当前信息中心广播信息
        /// </summary>
        public ServerCallback3 State
        {
            get { return state; }
            set { state = value; }
        }

        private ServerService serverService;
        private static InfoCenterLister instance;

        public static InfoCenterLister GetInsatnce()
        {
            if (instance == null)
            {
                instance = new InfoCenterLister();
            }
            return instance;
        }

        private InfoCenterLister()
        {
            this.serverService = ServicesFactory.GetInstance().GetServerService();
            this.GetInfoLogic();
            this.lastDojobTime = System.Environment.TickCount;
        }

        private void GetInfoLogic()
        {
            this.state = this.serverService.GetBroadcastMessage(AboutConfig.GetInstance().GetAbout());
        }

        private int lastDojobTime;
        private const int delayTime = 60 * 1000 * 60;

        public void LogicInterface()
        {
            int dvalue = System.Environment.TickCount - lastDojobTime;
            //在间隔时间外执行
            if (dvalue < delayTime)
            {
                return;
            }
            this.lastDojobTime = System.Environment.TickCount;
            this.GetInfoLogic();
        }
    }
}
