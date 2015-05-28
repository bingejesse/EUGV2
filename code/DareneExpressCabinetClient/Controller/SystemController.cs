using DareneExpressCabinetClient.Resource;
using DareneExpressCabinetClient.Service;
using DareneExpressCabinetClient.Service.Factory;
using System;
using DareneExpressCabinetClient.Tools;
using System.ComponentModel;
using System.Threading;
using Domain;

namespace DareneExpressCabinetClient.Controller
{

    public class SystemController : IDisposable
    {
        private DatabaseService databaseService;
        private AboutConfig aboutConfig;
        private BoxsManager boxManager;
        private PackageManager packageManager;
        private ELocksManager elocksManager;
        private RemoteOpenLogic remoteOpenLogic;
        private ADManager adManager;
        private Timer SystemTimer;//系统主逻辑时钟启动

        private const int delay = 50;
        private int stepNum = 0;
        public int Load(BackgroundWorker bw)
        {
            #region 获取初始化基本信息
            bw.ReportProgress(stepNum+=1, "starting......");

            this.databaseService = ServicesFactory.GetInstance().GetDatabaseService();
            this.aboutConfig = AboutConfig.GetInstance();
            this.elocksManager = ELocksManager.GetInstance();
            this.boxManager = BoxsManager.GetInstance();
            this.packageManager = PackageManager.GetInstance();
            this.adManager = ADManager.GetInstance();
            this.remoteOpenLogic = RemoteOpenLogic.GetInstance();

            this.SystemTimer = new Timer(new TimerCallback(this.SystemTimer_Elapsed), null, Timeout.Infinite, Timeout.Infinite);
            #endregion

            System.Threading.Thread.Sleep(delay);
            bw.ReportProgress(stepNum += 1, "aboutConfig loading......");
            this.aboutConfig.Load();
            System.Threading.Thread.Sleep(delay);
            bw.ReportProgress(stepNum += 1, "boxManager loading......");
            this.boxManager.Load();
            System.Threading.Thread.Sleep(delay);
            bw.ReportProgress(stepNum += 1, "elocksManager loading......");
            this.elocksManager.Load();
            System.Threading.Thread.Sleep(delay);
            bw.ReportProgress(stepNum += 1, "packageManager loading......");
            this.packageManager.Load();
            System.Threading.Thread.Sleep(delay);
            bw.ReportProgress(stepNum += 1, "remoteOpenLogic loading......");
            this.remoteOpenLogic.Load();
            System.Threading.Thread.Sleep(delay);
            bw.ReportProgress(stepNum += 1, "adManager loading......");
            this.adManager.Load();
            System.Threading.Thread.Sleep(delay);
            bw.ReportProgress(stepNum += 1, "packageEvent loading......");
            this.packageManager.PackageCreatedEvent += new PackageManager.PackageCreatedDelegate(packageManager_PackageCreatedEvent);
            this.packageManager.PackageTakedEvent += new PackageManager.PackageTakedDelegate(packageManager_PackageTakedEvent);
            this.SystemTimer.Change(0, 600 * 1000);
            System.Threading.Thread.Sleep(delay);
            bw.ReportProgress(stepNum += 1, "over");

            return stepNum;
        }

        /// <summary>
        /// 包裹被取出后操作
        /// </summary>
        /// <param name="p"></param>
        void packageManager_PackageTakedEvent(Package p)
        {
            bool updateBox = false;
            bool deletePackage = false;
            bool savePickUpLog = false;
            //本条语句在xp上测试有时有问题
            //this.databaseService.UpdatePackage(p);
            //updateBox = this.databaseService.UpdateBox(p.Place);

            PickUpLog pLog = new PickUpLog();
            pLog.BoxCode = p.Place.Code;
            pLog.CourierCode = p.Courier.Code;
            pLog.DeletedTime = p.DeletedTime;
            pLog.ReceiverTelNum = p.ReceiverTelNum;
            pLog.Remark = p.RemarkInfo;
            pLog.Sn = p.SN;
            pLog.ReceiverIdentity = p.ReceiverIdentity;
            deletePackage = this.databaseService.DeletePackage(p);

            savePickUpLog = this.databaseService.SavePickUpLog(pLog);

            CLog4net.LogInfo("包裹取出数据库更新：updateBox " + updateBox + " deletePackage " + deletePackage + " savePickUpLog " + savePickUpLog);
        }

        /// <summary>
        /// 包裹投递成功后操作
        /// </summary>
        /// <param name="p"></param>
        void packageManager_PackageCreatedEvent(Package p)
        {
            bool savePackage = false;
            bool updatePackage = false;
            bool updateBox = false;
            bool saveDeliverLog = false;

            if (p.IsNeedUpdate == false)
            {
                savePackage = this.databaseService.SavePackage(p);
            }
            else
            {
                updatePackage = this.databaseService.UpdatePackage(p);
            }
            //updateBox = this.databaseService.UpdateBox(p.Place);
            DeliverLog dLog = new DeliverLog();
            dLog.BoxCode = p.Place.Code;
            dLog.CourierCode = p.Courier.Code;
            dLog.CreatedTime = p.CreatedTime;
            dLog.ReceiverTelNum = p.ReceiverTelNum;
            dLog.Remark = p.RemarkInfo;
            dLog.Sn = p.SN;

            saveDeliverLog = this.databaseService.SaveDeliverLog(dLog);

            CLog4net.LogInfo("包裹创建数据库更新:savePackage " + savePackage + " updatePackage " + updatePackage + " updateBox " + updateBox + " saveDeliverLog " + saveDeliverLog);
        }

        /// <summary>
        /// 系统定时刷新逻辑接口
        /// </summary>
        /// <param name="sender"></param>
        private void SystemTimer_Elapsed(object sender)
        {
            CommLister.GetInstance().LogicInterface();
            InfoCenterLister.GetInsatnce().LogicInterface();
        }

        public void Dispose()
        {
            this.SystemTimer.Dispose();
            this.boxManager.Dispose();
        }
    }
}
