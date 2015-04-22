using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DareneExpressCabinetClient.Resource
{
    /// <summary>
    /// 本套快递柜信息
    /// </summary>
    public class About
    {
        private string cabinetCode;
        /// <summary>
        /// 快递柜编号
        /// </summary>
        public string CabinetCode
        {
            get { return cabinetCode; }
            set { cabinetCode = value; }
        }

        private string name;
        /// <summary>
        /// 名称描述
        /// </summary>
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string companyName;
        /// <summary>
        /// 所属公司名称
        /// </summary>
        public string CompanyName
        {
            get { return companyName; }
            set { companyName = value; }
        }
        private string address;
        /// <summary>
        /// 所在地址
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        private string telNum;
        /// <summary>
        /// 联系人电话
        /// </summary>
        public string TelNum
        {
            get { return telNum; }
            set { telNum = value; }
        }
        private DateTime configTime;
        /// <summary>
        /// 配置时间
        /// </summary>
        public DateTime ConfigTime
        {
            get { return configTime; }
            set { configTime = value; }
        }
        private DateTime createdTime;
        /// <summary>
        /// 启用时间
        /// </summary>
        public DateTime CreatedTime
        {
            get { return createdTime; }
            set { createdTime = value; }
        }
        private string remark;
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }

        private string version;
        /// <summary>
        /// 客户端版本号
        /// </summary>
        public string Version
        {
            get { return version; }
            set { version = value; }
        }

        private string serverUrl;
        /// <summary>
        /// 服务器访问地址
        /// </summary>
        public string ServerUrl
        {
            get { return serverUrl; }
            set { serverUrl = value; }
        }

        private string managerName;
        /// <summary>
        /// 超级管理员账户
        /// </summary>
        public string ManagerName
        {
            get { return managerName; }
            set { managerName = value; }
        }

        private string managerPassword;
        /// <summary>
        /// 超级管理员密码
        /// </summary>
        public string ManagerPassword
        {
            get { return managerPassword; }
            set { managerPassword = value; }
        }

        private string model;
        /// <summary>
        /// 型号类型:a(基础版)、b（手机扫描柜子二维码版）、c(柜子扫描手机二维码版)
        /// </summary>
        public string Model
        {
            get
            {
                return model;
            }
            set
            {
                model = value;
            }
        }
    }
}
