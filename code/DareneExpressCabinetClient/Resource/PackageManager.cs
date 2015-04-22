using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DareneExpressCabinetClient.Tools;
using DareneExpressCabinetClient.Service;
using Domain;

namespace DareneExpressCabinetClient.Resource
{
    public class PackageManager
    {
        public delegate void PackageCreatedDelegate(Package p);
        public delegate void PackageTakedDelegate(Package p);
        /// <summary>
        /// 投递成功促发事件
        /// </summary>
        public event PackageCreatedDelegate PackageCreatedEvent;
        /// <summary>
        /// 包裹被取促发事件
        /// </summary>
        public event PackageTakedDelegate PackageTakedEvent;

        private static PackageManager instance;

        public static PackageManager GetInstance()
        {
            if (instance == null)
            {
                instance = new PackageManager();
            }

            return instance;
        }

        public void Load()
        {
            DatabaseService service = Service.Factory.ServicesFactory.GetInstance().GetDatabaseService();
            this.storage = service.GetPackages();

            CLog4net.LogInfo("PackageManager is loaded");
        }

        /// <summary>
        /// 包裹列表
        /// </summary>
        public List<Package> storage = new List<Package>();

        /// <summary>
        /// 从储物箱编号获得快递
        /// </summary>
        /// <param name="boxCode"></param>
        /// <returns></returns>
        public Package FindPackageByBoxCode(int boxCode)
        {
            foreach (Package p in storage)
            {
                if (p.Place.Code.Equals(boxCode))
                {
                    return p;
                }
            }

            return null;
        }

        /// <summary>
        /// 根据序列号获取快递
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public Package FindPackageBySN(string code)
        {
            foreach (Package p in storage)
            {
                if (p.SN.Equals(code))
                {
                    return p;
                }
            }

            return null;
        }

        /// <summary>
        /// 快递员投入包裹
        /// </summary>
        /// <param name="courierId">柜子号</param>
        /// <param name="companyName"></param>
        /// <param name="sn"></param>
        /// <param name="receiverTelNum"></param>
        /// <param name="box"></param>
        /// <returns></returns>
        public Package CreatePackage(string courierId, string companyName, string sn, string receiverTelNum, Box box)
        {
            Package p = new Package();
            p.CreatedTime = DateTime.Now;
            p.Place = box;
            //p.Place.IsIdle = false;//该柜子至为已经使用状态
            p.Courier = new Courier(courierId);
            p.Courier.CompanyName = companyName;
            p.SN = sn;
            p.ReceiverTelNum = receiverTelNum;

            p.IsNeedUpdate = false;
            p.Taken = true;

            return p;
        }

        /// <summary>
        /// 投递操作成功
        /// </summary>
        public void CreatePackageSuccess(Package p)
        {
            p.Place.IsIdle = false;
            if (this.PackageCreatedEvent != null)
            {
                this.PackageCreatedEvent(p);
            }

            //是第一次创建时才添加
            if (p.IsNeedUpdate == false)
            {
                this.storage.Add(p);
            }
        }

        /// <summary>
        /// 取件人根据密码获取包裹
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Package TakePackage(ServerCallback callback)
        {
            try
            {
                if (callback.Success)
                {
                    foreach (Package p in storage)
                    {
                        if (p.Place.Code.Equals(Convert.ToInt32(callback.BoxCode)))
                        {
                            p.ReceiverIdentity = 0;
                            p.DeletedTime = DateTime.Now;
                            this.storage.Remove(p);
                            p.Place.IsIdle = true;
                            p.Taken = false;
                            if (this.PackageTakedEvent != null)
                            {
                                this.PackageTakedEvent(p);
                            }
                            return p;
                        }
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                CLog4net.LogError("Package TakePackage " + callback.BoxCode + ":" + e);
                return null;
            }
        }

        /// <summary>
        /// 根据储物柜编号取走包裹
        /// </summary>
        /// <param name="boxCode"></param>
        /// <returns></returns>
        public Package TakePackage(int boxCode)
        {
            foreach (Package p in storage)
            {
                if (p.Place.Code.Equals(boxCode))
                {
                    p.ReceiverIdentity = 0;
                    p.DeletedTime = DateTime.Now;
                    this.storage.Remove(p);
                    p.Place.IsIdle = true;
                    p.Taken = false;
                    if (this.PackageTakedEvent != null)
                    {
                        this.PackageTakedEvent(p);
                    }
                    return p;
                }
            }
            return null;
        }

   
        /// <summary>
        /// 投递员根据快递序列号和自己的id及包裹密码取回快递
        /// </summary>
        /// <param name="boxCode"></param>
        /// <param name="receiverIdentity">0：取件人；1:快递员；2：管理员；3其它</param>
        /// <returns></returns>
        public bool TakePackage(int boxCode, byte receiverIdentity)
        {
            Package pac = this.FindPackageByBoxCode(boxCode);

            if (pac == null)
            {
                return false;
            }

            pac.ReceiverIdentity = receiverIdentity;
            pac.DeletedTime = DateTime.Now;

            this.storage.Remove(pac);
            pac.Place.IsIdle = true;
            pac.Taken = false;
            if (this.PackageTakedEvent != null)
            {
                this.PackageTakedEvent(pac);
            }
            return true;
        }
    }
}
