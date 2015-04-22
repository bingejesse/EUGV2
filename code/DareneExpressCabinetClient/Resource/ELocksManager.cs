using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DareneExpressCabinetClient.Service;
using DareneExpressCabinetClient.Tools;
using Domain;

namespace DareneExpressCabinetClient.Resource
{
    class ELocksManager
    {
        private ELocksManager eLocksManager;

        private static ELocksManager instance;

        public static ELocksManager GetInstance()
        {
            if (instance == null)
            {
                instance = new ELocksManager();
            }

            return instance;
        }

        public void Load()
        {
            this.eLocksManager = ELocksManager.GetInstance();

            /**
             * 从数据库获取锁控板列表
             * 
             * */
             DatabaseService service = Service.Factory.ServicesFactory.GetInstance().GetDatabaseService();
             this.locks = service.GetELock();

             CLog4net.LogInfo("ELocksManager is Loaded");
        }

        public List<ELock> locks = new List<ELock>();

        public ELock GetLock(int boxCode)
        {
            foreach (ELock e in locks)
            {
                if (e.BoxCode == boxCode)
                {
                    return e;
                }
            }
            return null;
        }
    }
}
