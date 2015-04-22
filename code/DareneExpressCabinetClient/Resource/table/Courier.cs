using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DareneExpressCabinetClient.Service;
using DareneExpressCabinetClient.Service.Factory;
using DareneExpressCabinetClient.Tools;
using Domain;

namespace DareneExpressCabinetClient.Resource
{
    /// <summary>
    /// 快递员信息
    /// </summary>
    public class Courier
    {
        private string code;
        /// <summary>
        /// 快递员ID
        /// </summary>
        public string Code
        {
            get { return code; }
            set { code = value; }
        }

        private String password;
        /// <summary>
        /// 快递员密码
        /// </summary>
        public String Password
        {
            get { return password; }
            set { password = value; }
        }



        private string companyName;
        /// <summary>
        /// 所属公司名称
        /// </summary>
        public string CompanyName
        {
            set { companyName = value; }
            get { return companyName; }
        }

        private ServerService service;

        public Courier(string id)
        {
            this.code = id;
            this.service = ServicesFactory.GetInstance().GetServerService();
        }

        public Courier(string id, string  pwd)
        {
            this.code = id;
            this.password = pwd;
            this.service = ServicesFactory.GetInstance().GetServerService();
        }

        /// <summary>
        /// 是否是注册会员
        /// </summary>
        /// <returns></returns>
        public bool IsRegister()
        {
            try
            {
                ServerCallback dic = this.service.CourierLogin(this, AboutConfig.GetInstance().GetAbout());
                if (dic.Success)
                {
                    this.companyName = dic.CompanyName;
                    return true;
                }

                return false;
            }
            catch (Exception e)
            {
                CLog4net.LogError(e);
                return false;
            }
        }
    }
}
