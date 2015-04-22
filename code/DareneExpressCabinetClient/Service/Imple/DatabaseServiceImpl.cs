using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using System.Data;
using DareneExpressCabinetClient.Resource;
using DareneExpressCabinetClient.Tools;
using Domain.TableConst;

namespace DareneExpressCabinetClient.Service.Imple
{
    class DatabaseServiceImpl:DatabaseService
    {
        private string ip="";
        private string username = "";
        private string password = "";
        private string database = "";
        public DatabaseServiceImpl()
        {
            IniConfigManager iniManager = new IniConfigManager();
            this.ip = iniManager.GetDatabaseIp();
            this.username = iniManager.GetDatabaseUsername();
            this.password = iniManager.GetDatabasePassword();
            this.database = iniManager.GetDatabaseName();
        }

        /// <summary>
        /// 获取全部箱子
        /// </summary>
        /// <returns></returns>
        public List<Box> GetBoxs()
        {

            DataTable table = null;
            LoggingData data = new LoggingData(ip,username,password,database);
            table = data.GetBoxs();

            if (table == null)
            {
                CLog4net.LogError("柜子表初始化错误");
                return null;
            }

            List<Box> boxes = new List<Box>();
            foreach (System.Data.DataRow d in table.Rows)
            {
                Box cb = new Box();
                cb.Id = Convert.ToInt32(d[TbBox.id]);
                cb.Code = Convert.ToInt32(d[TbBox.code]);
                Box.Coordinate location = new Box.Coordinate();
                location.X = Convert.ToInt32(d[TbBox.locationX]);
                location.Y = Convert.ToInt32(d[TbBox.locationY]);
                cb.CoordinateInfo = location;
                cb.CurrentState = (Box.State)Convert.ToByte(d[TbBox.state]);
                cb.IsIdle = Convert.ToBoolean(d[TbBox.idle]);
                cb.ThisSize = (Box.Size)Convert.ToByte(d[TbBox.size]);
                cb.RemarkInfo = Convert.ToString(d[TbBox.remark]);
                boxes.Add(cb);
            }
            return boxes;
        }

        /// <summary>
        /// 随机获取箱子
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public Box GetIdleBoxBySize(Box.Size size)
        {

            DataTable table = null;
            LoggingData data = new LoggingData(ip, username, password, database);
            table = data.GetIdleBoxBySize((int)size);

            if (table == null || table.Rows.Count == 0)
            {
                CLog4net.LogError("未找到合适大小箱子："+size);
                return null;
            }

            Box cb = new Box();
            foreach (System.Data.DataRow d in table.Rows)
            {
                cb.Id = Convert.ToInt32(d[TbBox.id]);
                cb.Code = Convert.ToInt32(d[TbBox.code]);
                Box.Coordinate location = new Box.Coordinate();
                location.X = Convert.ToInt32(d[TbBox.locationX]);
                location.Y = Convert.ToInt32(d[TbBox.locationY]);
                cb.CoordinateInfo = location;
                cb.CurrentState = (Box.State)Convert.ToByte(d[TbBox.state]);
                cb.IsIdle = Convert.ToBoolean(d[TbBox.idle]);
                cb.ThisSize = (Box.Size)Convert.ToByte(d[TbBox.size]);
                cb.RemarkInfo = Convert.ToString(d[TbBox.remark]);
            }
            return cb;
        }

        public int GetIdleBoxCount(Box.Size size)
        {
            DataTable table = null;
            LoggingData data = new LoggingData(ip, username, password, database);
            table = data.GetIdleBoxCount((int)size);

            if (table == null || table.Rows.Count == 0)
            {
                CLog4net.LogError("获取箱子数目失败：" + size);
                return 0;
            }

            int count = 0;
            count=Convert.ToInt32(table.Rows[0][0]);

            return count;
        }

        /// <summary>
        /// 保存箱子信息
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool SaveBox(Box obj)
        {
            LoggingData data = new LoggingData(ip, username, password, database);
            bool result = data.SaveBox(obj.Code, Convert.ToByte(obj.IsIdle), obj.CoordinateInfo.X, obj.CoordinateInfo.Y, obj.RemarkInfo, (byte)obj.ThisSize, (byte)obj.CurrentState);

            return result;
        }

        /// <summary>
        /// 获取包裹列表
        /// </summary>
        /// <returns></returns>
        public List<Package> GetPackages()
        {
            DataTable table = null;
            LoggingData data = new LoggingData(ip, username, password, database);
            table = data.GetPackage();
            if (table == null)
            {
                CLog4net.LogError("快递表初始化错误");
                return null;
            }

            List<Package> packages = new List<Package>();

            foreach (System.Data.DataRow d in table.Rows)
            {
                Package p = new Package();
                /**
                 * 从数据库中读取未被取走的快递
                 * */
                p.Courier = new Courier(Convert.ToString(d[TbPackage.courierCode]));
                p.CreatedTime = Convert.ToDateTime(d[TbPackage.createdTime]);
                if (d[TbPackage.deletedTime].ToString() != "")
                {
                    p.DeletedTime = Convert.ToDateTime(d[TbPackage.deletedTime]);
                }
                p.Place = BoxsManager.GetInstance().Find(Convert.ToInt32(d[TbPackage.boxCode]));
                if (d[TbPackage.receiverIdentity].ToString() != "")
                {
                    p.ReceiverIdentity = Convert.ToByte(d[TbPackage.receiverIdentity]);
                }
                p.ReceiverTelNum = Convert.ToString(d[TbPackage.receiverTelNum]);
                p.RemarkInfo = Convert.ToString(d[TbPackage.remark]);
                p.SN = Convert.ToString(d[TbPackage.packageCode]);
                p.Taken = Convert.ToBoolean(d[TbPackage.taken]);

                packages.Add(p);
            }

            return packages;
        }

        public bool SavePackage(Resource.Package obj)
        {
            LoggingData data = new LoggingData(ip, username, password, database);
            bool result = data.SavePackage(obj.SN, obj.Courier.Code, obj.ReceiverTelNum, obj.Place.Code, Convert.ToByte(obj.Taken), obj.CreatedTime, obj.DeletedTime, obj.ReceiverIdentity, obj.RemarkInfo);
            return result;
        }

        public bool SaveDeliverLog(Resource.DeliverLog obj)
        {
            LoggingData data = new LoggingData(ip, username, password, database);
            bool result = data.SaveDeliverLog(obj.Sn, obj.CourierCode, obj.ReceiverTelNum, obj.BoxCode, obj.CreatedTime, Convert.ToByte(obj.ServerSaved), obj.Remark);
            return result;
        }

        public About GetAbout()
        {
            DataTable table = null;
            LoggingData data = new LoggingData(ip, username, password, database);
            table = data.GetAbout();
            if (table == null)
            {
                CLog4net.LogError("快递表初始化错误");
                return null;
            }

            About a = new About();

            foreach (System.Data.DataRow d in table.Rows)
            {
                /**
                 * 从数据库中读取未被取走的快递
                 * */
                a.Address = Convert.ToString(d[TbAbout.address]);
                a.CabinetCode = Convert.ToString(d[TbAbout.cabinetCode]);
                a.CompanyName = Convert.ToString(d[TbAbout.companyName]);
                a.ConfigTime = Convert.ToDateTime(d[TbAbout.configTime]);
                a.CreatedTime = Convert.ToDateTime(d[TbAbout.createdTime]);
                a.Name = Convert.ToString(d[TbAbout.name]);
                a.Remark = Convert.ToString(d[TbAbout.remark]);
                a.TelNum = Convert.ToString(d[TbAbout.telNum]);
                a.Version = Convert.ToString(d[TbAbout.version]);
                a.ServerUrl = Convert.ToString(d[TbAbout.serverUrl]);
                a.ManagerName = Convert.ToString(d[TbAbout.managerName]);
                a.ManagerPassword = Convert.ToString(d[TbAbout.managerPassword]);
                a.Model = Convert.ToString(d[TbAbout.model]);
            }
            return a;
        }

        public bool SaveAbout(About obj)
        {
            LoggingData data = new LoggingData(ip, username, password, database);
            obj.ConfigTime = DateTime.Now;
            bool result= data.SaveAbout(obj.Address, obj.CabinetCode, obj.CompanyName, obj.ConfigTime, obj.Name, obj.Remark, obj.TelNum, obj.Version,obj.ServerUrl,obj.ManagerName,obj.ManagerPassword,obj.CreatedTime,obj.Model);
            return result;
        }

        public bool UpdateAbout(About obj)
        {
            LoggingData data = new LoggingData(ip, username, password, database);
            obj.ConfigTime = DateTime.Now;
            bool result = data.UpdateAbout(obj.Address, obj.CabinetCode, obj.CompanyName, obj.ConfigTime, obj.Name, obj.Remark, obj.TelNum, obj.Version, obj.ServerUrl, obj.CreatedTime, obj.Model);
            return result;
        }

        public bool UpdateAboutPassword(string password)
        {
            LoggingData data = new LoggingData(ip, username, password, database);
            bool result = data.UpdateAbout(password);
            return result;
        }

        public List<DeliverLog> GetDeliverLogNoUpload()
        {
            DataTable table = null;
            LoggingData data = new LoggingData(ip, username, password, database);
            table = data.GetDeliverLogNoUpload();
            if (table == null)
            {
                CLog4net.LogError("寄件日志表初始化错误");
                return null;
            }
            List<DeliverLog> a = new List<DeliverLog>();
            foreach (System.Data.DataRow d in table.Rows)
            {
                DeliverLog dl = new DeliverLog();
                dl.Sn = Convert.ToString(d[TbDeliverLog.packageCode]);
                dl.CourierCode = Convert.ToString(d[TbDeliverLog.courierCode]);
                dl.ReceiverTelNum = Convert.ToString(d[TbDeliverLog.receiverTelNum]);
                dl.BoxCode = Convert.ToInt32(d[TbDeliverLog.boxCode]);
                dl.CreatedTime = Convert.ToDateTime(d[TbDeliverLog.createdTime]);
                dl.ServerSaved = Convert.ToBoolean(d[TbDeliverLog.serverSaved]);
                dl.Remark = Convert.ToString(d[TbDeliverLog.remark]);
                a.Add(dl);
            }
            return a;
        }

        public bool SavePickUpLog(PickUpLog obj)
        {
            LoggingData data = new LoggingData(ip, username, password, database);
            bool result = data.SavePickUpLog(obj.Sn, obj.CourierCode, obj.ReceiverTelNum, obj.BoxCode, obj.DeletedTime, obj.ReceiverIdentity, Convert.ToByte(obj.ServerSaved), obj.Remark);
            return result;
        }

        public List<PickUpLog> GetPickUpLogNoUpload()
        {
            DataTable table = null;
            LoggingData data = new LoggingData(ip, username, password, database);
            table = data.GetPickUpLogNoUpload();
            if (table == null)
            {
                CLog4net.LogError("取件日志表初始化错误");
                return null;
            }
            List<PickUpLog> a = new List<PickUpLog>();
            foreach (System.Data.DataRow d in table.Rows)
            {
                PickUpLog pl = new PickUpLog();
                pl.Sn = Convert.ToString(d[TbPickuplog.packageCode]);
                pl.CourierCode = Convert.ToString(d[TbPickuplog.courierCode]);
                pl.ReceiverTelNum = Convert.ToString(d[TbPickuplog.receiverTelNum]);
                pl.BoxCode = Convert.ToInt32(d[TbPickuplog.boxCode]);
                pl.DeletedTime = Convert.ToDateTime(d[TbPickuplog.deletedTime]);
                pl.ReceiverIdentity = Convert.ToByte(d[TbPickuplog.receiverIdentity]);
                pl.ServerSaved = Convert.ToBoolean(d[TbPickuplog.serverSaved]);
                pl.Remark = Convert.ToString(d[TbPickuplog.remark]);
                a.Add(pl);
            }
            return a;
        }


        public bool UpdateBox(Box obj)
        {
            LoggingData data = new LoggingData(ip, username, password, database);
            bool result = data.UpdateBox(obj.Code, Convert.ToByte(obj.IsIdle), obj.CoordinateInfo.X, obj.CoordinateInfo.Y, obj.RemarkInfo, (byte)obj.ThisSize, (byte)obj.CurrentState);
            return result;
        }

        public bool UpdatePackage(Package obj)
        {
            LoggingData data = new LoggingData(ip, username, password, database);
            bool result = data.UpdatePackage(obj.SN, obj.Courier.Code, obj.ReceiverTelNum, obj.Place.Code, Convert.ToByte(obj.Taken), obj.CreatedTime, obj.DeletedTime,obj.ReceiverIdentity,obj.RemarkInfo);
            return result;
        }

        public bool DeletePackage(Package obj)
        {
            LoggingData data = new LoggingData(ip, username, password, database);
            bool result = data.DeletePackage(obj.SN);
            return result;
        }

        public bool UpdateDeliverLog(DeliverLog obj)
        {
            LoggingData data = new LoggingData(ip, username, password, database);
            bool result = data.UpdateDeliverLog(obj.Id, obj.Sn, obj.CourierCode, obj.ReceiverTelNum, obj.BoxCode, obj.CreatedTime, Convert.ToByte(obj.ServerSaved), obj.Remark);
            return result;
        }

        public bool UpdatePickUpLog(PickUpLog obj)
        {
            LoggingData data = new LoggingData(ip, username, password, database);
            bool result = data.UpdatePickUpLog(obj.Id, obj.Sn, obj.CourierCode, obj.ReceiverTelNum, obj.BoxCode, obj.DeletedTime, obj.ReceiverIdentity, Convert.ToByte(obj.ServerSaved), obj.Remark);
            return result;
        }


        public List<ELock> GetELock()
        {
            DataTable table = null;
            LoggingData data = new LoggingData(ip, username, password, database);
            table = data.GetELock();

            if (table == null)
            {
                CLog4net.LogError("锁控板列表初始化错误");
                return null;
            }

            List<ELock> boxes = new List<ELock>();
            foreach (System.Data.DataRow d in table.Rows)
            {
                ELock cb = new ELock();
                cb.Id = Convert.ToInt32(d[TbELock.id]);
                if (d[TbELock.boxCode].ToString() != "")
                {
                    cb.BoxCode = Convert.ToInt32(d[TbELock.boxCode]);
                }
                
                cb.Address = Convert.ToString(d[TbELock.ip]);
                cb.Password = Convert.ToString(d[TbELock.password]);
                cb.Value = Convert.ToString(d[TbELock.value]);
                boxes.Add(cb);
            }
            return boxes;
        }
    }
}
