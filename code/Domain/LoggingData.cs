using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Domain.TableConst;

namespace Domain
{
    public class LoggingData
    {
        private MysqlConnection mysql;

        public LoggingData(string ip, string username, string password, string database)
        {
            mysql = MysqlConnection.GetInstance(ip, username, password, database);
        }

        public DataTable GetBoxs()
        {
            string sql = string.Format("Select * from {0}", TbBox.tbBox);
            DataTable table = null; ;
            table = mysql.ExecuteDataTable(sql);
            return table;
        }

        public DataTable GetIdleBoxBySize(int size)
        {
            string sql = string.Format("SELECT * FROM {0} where size={1} and idle=1 and state!=2 order by rand() limit 1", TbBox.tbBox,size);
            DataTable table = null; ;
            table = mysql.ExecuteDataTable(sql);
            return table;
        }

        public DataTable GetIdleBoxCount(int size)
        {
            string sql = string.Format("SELECT count(*) FROM {0} where size={1} and idle=1 and state!=2", TbBox.tbBox, size);
            DataTable table = null; ;
            table = mysql.ExecuteDataTable(sql);
            return table;
        }

        public DataTable GetPackage()
        {
            string sql = string.Format("Select * from {0} where {1}={2}", TbPackage.tbPackage, TbPackage.taken, "'1'");
            DataTable table = null; ;
            table = mysql.ExecuteDataTable(sql);
            return table;
        }

        public DataTable GetAbout()
        {
            string sql = string.Format("Select * from {0}",TbAbout.tbAbout);
            DataTable table = null; ;
            table = mysql.ExecuteDataTable(sql);
            return table;
        }

        public DataTable GetDeliverLogNoUpload()
        {
            string sql = string.Format("Select * from {0} Where {1}={2}", TbDeliverLog.tbDeliverLog, TbDeliverLog.serverSaved, "'0'");
            DataTable table = null; ;
            table = mysql.ExecuteDataTable(sql);
            return table;
        }

        public DataTable GetPickUpLogNoUpload()
        {
            string sql = string.Format("Select * from {0} Where {1}={2}", TbPickuplog.tbPickuplog, TbPickuplog.serverSaved, "'0'");
            DataTable table = null; ;
            table = mysql.ExecuteDataTable(sql);
            return table;
        }

        public bool SavePackage(string packageCode,string courierCode,string receiverTelNum,int boxCode,byte taken,DateTime createdTime,DateTime deletedTime,byte receiverIdentity,string remark)
        {
            string sql = string.Format("insert into {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9}) values('{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}')",
                TbPackage.tbPackage,
                TbPackage.packageCode, TbPackage.courierCode, TbPackage.receiverTelNum, TbPackage.boxCode, TbPackage.taken, TbPackage.createdTime, TbPackage.deletedTime, TbPackage.receiverIdentity, TbPackage.remark,
                packageCode, courierCode, receiverTelNum, boxCode,taken, createdTime, deletedTime, receiverIdentity, remark);
            return mysql.ExecuteNonQuery(sql);
        }
        public bool SaveAbout(string address,string cabinetCode,string companyName,DateTime configTime, string name,string remark,string telNum,string version,string serverUrl,string user,string password,DateTime createdTime,string model)
        {
            string sql = string.Format("insert into {0} ({1},{2},{3},{4},{5},{6},{7},{8},{9},{10},{11},{12},{13}) values('{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}','{22}','{23}','{24}','{25}','{26}')",
                TbAbout.tbAbout,
                TbAbout.address, TbAbout.cabinetCode, TbAbout.companyName, TbAbout.configTime, TbAbout.name, TbAbout.remark, TbAbout.telNum, TbAbout.version,TbAbout.serverUrl,TbAbout.managerName,TbAbout.managerPassword,TbAbout.createdTime,TbAbout.model,
                address, cabinetCode, companyName, configTime, name, remark, telNum, version, serverUrl,user,password,createdTime,model
                );
            return mysql.ExecuteNonQuery(sql);
        }

        public bool UpdateAbout(string address, string cabinetCode, string companyName, DateTime configTime, string name, string remark, string telNum, string version, string serverUrl, DateTime createdTime, string model)
        {
            string sql = string.Format("update {0} set {1}='{12}',{2}='{13}',{3}='{14}',{4}='{15}',{5}='{16}',{6}='{17}',{7}='{18}',{8}='{19}',{9}='{20}',{10}='{21}',{11}='{22}'",
                TbAbout.tbAbout,
                TbAbout.address, TbAbout.cabinetCode, TbAbout.companyName, TbAbout.configTime, TbAbout.name, TbAbout.remark, TbAbout.telNum, TbAbout.version, TbAbout.serverUrl, TbAbout.createdTime, TbAbout.model,
                address, cabinetCode, companyName, configTime, name, remark, telNum, version, serverUrl, createdTime, model
        );
            return mysql.ExecuteNonQuery(sql);
        }

        public bool UpdateAbout(string password)
        {
            string sql = string.Format("update {0} set {1}='{2}'",TbAbout.tbAbout,TbAbout.managerPassword,password);
            return mysql.ExecuteNonQuery(sql);
        }

        public bool SaveBox(int code, byte idle, int x, int y, string remark, byte size, byte state)
        {
            string sql = string.Format("insert into {0} ({1},{2},{3},{4},{5},{6},{7}) values('{8}','{9}','{10}','{11}','{12}','{13}','{14}')",
                TbBox.tbBox,
                TbBox.code, TbBox.idle, TbBox.locationX, TbBox.locationY, TbBox.remark, TbBox.size, TbBox.state,
                code, idle, x, y, remark, size,state);
            return mysql.ExecuteNonQuery(sql);
        }
        public bool SaveDeliverLog(string packageCode,string courierCode,string receiverTelNum,int boxCode,DateTime createdTime,byte serverSaved,string remark)
        {
            string sql = string.Format("insert into {0} ({1},{2},{3},{4},{5},{6},{7}) values('{8}','{9}','{10}','{11}','{12}','{13}','{14}')",
                           TbDeliverLog.tbDeliverLog,
                           TbDeliverLog.packageCode, TbDeliverLog.courierCode, TbDeliverLog.receiverTelNum, TbDeliverLog.boxCode, TbDeliverLog.createdTime, TbDeliverLog.serverSaved, TbDeliverLog.remark,
                           packageCode, courierCode, receiverTelNum, boxCode, createdTime, serverSaved, remark);
            return mysql.ExecuteNonQuery(sql);
        }
        public bool SavePickUpLog(string packageCode, string courierCode, string receiverTelNum, int boxCode, DateTime deletedTime, byte receiverIdentity, byte serverSaved, string remark)
        {
            string sql = string.Format("insert into {0} ({1},{2},{3},{4},{5},{6},{7},{8}) values('{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}')",
                                      TbPickuplog.tbPickuplog,
                                      TbPickuplog.packageCode, TbPickuplog.courierCode, TbPickuplog.receiverTelNum, TbPickuplog.boxCode, TbPickuplog.deletedTime, TbPickuplog.receiverIdentity, TbPickuplog.serverSaved, TbPickuplog.remark,
                                      packageCode, courierCode, receiverTelNum, boxCode, deletedTime, receiverIdentity,serverSaved, remark);
            return mysql.ExecuteNonQuery(sql);
        }
        public bool UpdateBox(int code, byte idle, int x, int y, string remark, byte size, byte state)
        {
            string sql = string.Format("update {0} set {1}='{8}',{2}='{9}',{3}='{10}',{4}='{11}',{5}='{12}',{6}='{13}' where {7}={14}",
                TbBox.tbBox,
                TbBox.idle, TbBox.locationX, TbBox.locationY, TbBox.remark, TbBox.size, TbBox.state, TbBox.code,
                idle, x, y, remark, size, state,code);
            return mysql.ExecuteNonQuery(sql);
        }
        public bool UpdateDeliverLog(int id,string packageCode, string courierCode, string receiverTelNum, int boxCode, DateTime createdTime, byte serverSaved, string remark)
        {
            string sql = string.Format("update {0} set {1}='{9}',{2}='{10}',{3}='{11}',{4}='{12}',{5}='{13}',{6}='{14}',{7}='{15}' where {8}={16})",
                                      TbDeliverLog.tbDeliverLog,
                                      TbDeliverLog.packageCode, TbDeliverLog.courierCode, TbDeliverLog.receiverTelNum, TbDeliverLog.boxCode, TbDeliverLog.createdTime, TbDeliverLog.serverSaved, TbDeliverLog.remark,TbDeliverLog.id,
                                      packageCode, courierCode, receiverTelNum, boxCode, createdTime, serverSaved, remark,id);
            return mysql.ExecuteNonQuery(sql);

        }
        public bool UpdatePickUpLog(int id, string packageCode, string courierCode, string receiverTelNum, int boxCode, DateTime deletedTime, byte receiverIdentity, byte serverSaved, string remark)
        {
            string sql = string.Format("update {0} set {1}='{10}',{2}='{11}',{3}='{12}',{4}='{13}',{5}='{14}',{6}='{15}',{7}='{16}',{8}='{17}' where {9}={18})",
                                                 TbPickuplog.tbPickuplog,
                                                 TbPickuplog.packageCode, TbPickuplog.courierCode, TbPickuplog.receiverTelNum, TbPickuplog.boxCode, TbPickuplog.deletedTime, TbPickuplog.receiverIdentity, TbPickuplog.serverSaved, TbPickuplog.remark, TbPickuplog.id,
                                                 packageCode, courierCode, receiverTelNum, boxCode, deletedTime, receiverIdentity, serverSaved, remark, id);
            return mysql.ExecuteNonQuery(sql);
        }


        public bool UpdatePackage(string packageCode, string courierCode, string receiverTelNum, int boxCode, byte taken, DateTime createdTime, DateTime deletedTime, byte receiverIdentity, string remark)
        {
            string sql = string.Format("update {0} set {1}='{10}',{2}='{11}',{3}='{12}',{4}='{13}',{5}='{14}',{6}='{15}',{7}='{16}',{8}='{17}'where {9}={18}",
                                                 TbPackage.tbPackage,
                                                 TbPackage.courierCode, TbPackage.receiverTelNum, TbPackage.boxCode, TbPackage.taken, TbPackage.createdTime, TbPackage.deletedTime, TbPackage.receiverIdentity, TbPackage.remark, TbPackage.packageCode,
                                                 courierCode, receiverTelNum, boxCode, taken, createdTime, deletedTime, receiverIdentity, remark, packageCode);
            return mysql.ExecuteNonQuery(sql);
        }

        public bool DeletePackage(string sn)
        {
            string sql = string.Format("delete from {0} where {1}='{2}'", TbPackage.tbPackage, TbPackage.packageCode, sn);
            return mysql.ExecuteNonQuery(sql);
        }

        public DataTable GetELock()
        {
            string sql = string.Format("Select * from {0}", TbELock.tbELock);
            DataTable table = null; ;
            table = mysql.ExecuteDataTable(sql);
            return table;
        }

        public bool SaveELock(int id,int boxCode, string ip, string password, string value)
        {
            string sql = string.Format("insert into {0} ({1},{2},{3},{4},{5}) values('{6}','{7}','{8}','{9}','{10}')",
                TbELock.tbELock,
                TbELock.id,TbELock.boxCode, TbELock.ip, TbELock.password, TbELock.value,
                id,boxCode, ip, password, value);
            return mysql.ExecuteNonQuery(sql);
        }

        public bool SaveBox(int id,int code, byte idle, int x, int y, string remark, byte size, byte state)
        {
            string sql = string.Format("insert into {0} ({1},{2},{3},{4},{5},{6},{7},{15}) values('{8}','{9}','{10}','{11}','{12}','{13}','{14}','{16}')",
                TbBox.tbBox,
                TbBox.code, TbBox.idle, TbBox.locationX, TbBox.locationY, TbBox.remark, TbBox.size, TbBox.state,
                code, idle, x, y, remark, size, state,
                TbBox.id,id);
            return mysql.ExecuteNonQuery(sql);
        }
    }
}
