using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DareneExpressCabinetClient.Service;
using DareneExpressCabinetClient.Service.Factory;

namespace DareneExpressCabinetClient.Resource
{
    /// <summary>
    /// 快递员信息
    /// </summary>
    public class Courier
    {
        private int id;
        /// <summary>
        /// 快递员ID
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
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

        

        private int companyId;

        private CourierService service;

        public Courier(int id, string  pwd)
        {
            this.id = id;
            this.password = pwd;
            this.service = ServicesFactory.GetInstance().GetCourierService();
        }

        /// <summary>
        /// 是否是注册会员
        /// </summary>
        /// <returns></returns>
        public bool IsRegister()
        {
            return this.service.IsRegister(this.id,this.password);
        }

    }
}
