using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DareneExpressCabinetClient.Resource;
using System.Threading;
using DareneExpressCabinetClient.Service;
using DareneExpressCabinetClient.Service.Factory;
using DareneExpressCabinetClient.Tools;
using Domain;

namespace DareneExpressCabinetClient.Controller
{
    public class RemoteOpenLogic
    {
        private static RemoteOpenLogic instance;
        public static RemoteOpenLogic GetInstance()
        {
            if (instance == null)
            {
                instance = new RemoteOpenLogic();
            }

            return instance;
        }


        private int timeSpan = 3000;
        public bool IsEnable;
        private Timer remoteLinstener;
        private ServerService server;
        private About about;
        private PackageManager packageManager;
        public delegate void RemoteOpenBoxDelegate(ServerCallback2 sc);
        public event RemoteOpenBoxDelegate RemoteOpenBoxEvent;
        public bool IsWorking;

        public void Load()
        {
            this.about = AboutConfig.GetInstance().GetAbout();
            if (about.Model == "b")
            {
                this.IsEnable = true;
                this.server = Service.Factory.ServicesFactory.GetInstance().GetServerService();
                this.packageManager = PackageManager.GetInstance();
                this.remoteLinstener = new Timer(new TimerCallback(RemoteOpenListen), null, Timeout.Infinite, Timeout.Infinite);
                IniConfigManager ini = new IniConfigManager();
                this.timeSpan =Convert.ToInt32(ini.GetServerTimeup());
            }
            else
            {
                this.IsEnable = false;
            }

            CLog4net.LogInfo("RemoteOpenLogic is loaded");
        }

        private void RemoteOpenListen(object state)
        {
            ServerCallback2 sc = this.server.OpenBoxCmdListener(this.about);
            if (!sc.HasOpenOrder)
            {
                return;
            }
            this.remoteLinstener.Change(Timeout.Infinite, Timeout.Infinite);
            if (this.RemoteOpenBoxEvent != null)
            {
                this.RemoteOpenBoxEvent(sc);
            }
        }

        public bool Response(string code, bool isOpen, About about)
        {
            return this.server.ResponseOpenBoxCmd(code, isOpen, about);
        }

        public void StartRemoteOpenListen()
        {
            this.remoteLinstener.Change(0, this.timeSpan);
            this.IsWorking = true;
        }

        public void StopRemoteOpenListen()
        {
            this.remoteLinstener.Change(Timeout.Infinite, Timeout.Infinite);
            this.IsWorking = false;
        }
    }
}
