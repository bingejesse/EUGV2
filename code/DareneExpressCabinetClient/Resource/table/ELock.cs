using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DareneExpressCabinetClient
{
    public class ELock
    {
        private int id;
        /// <summary>
        /// id
        /// </summary>
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private string address;
        /// <summary>
        /// ip地址
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }

        private string password;
        /// <summary>
        /// 密码
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        private string value;
        /// <summary>
        /// 设置的路数16进制
        /// </summary>
        public string Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        private int boxCode;
        /// <summary>
        /// 对应的box
        /// </summary>
        public int BoxCode
        {
            get { return boxCode; }
            set { boxCode = value; }
        }

    }
}
