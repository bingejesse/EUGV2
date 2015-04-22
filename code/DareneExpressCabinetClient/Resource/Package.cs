using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DareneExpressCabinetClient.Resource
{
    public class Package
    {
        private int sn;
        /// <summary>
        /// 序列号
        /// </summary>
        public int SN
        {
            get { return sn; }
            set { sn = value; }
        }
        private Courier courier;
        /// <summary>
        /// 投递员
        /// </summary>
        public Courier Courier
        {
            get { return courier; }
            set { courier = value; }
        }

        private int receiverTelNum;
        /// <summary>
        /// 收件人电话
        /// </summary>
        public int ReceiverTelNum
        {
            get { return receiverTelNum; }
            set { receiverTelNum = value; }
        }


        private string key;
        /// <summary>
        /// 取出密码
        /// </summary>
        public string Key
        {
            get { return key; }
            set { key = value; }
        }

        private DateTime createdTime;
        /// <summary>
        /// 投递时间
        /// </summary>
        public DateTime CreatedTime
        {
            get { return createdTime; }
            set { createdTime = value; }
        }

        private Cabinet place;
        /// <summary>
        /// 存放地点
        /// </summary>
        public Cabinet Place
        {
            get { return place; }
            set { place = value; }
        }


    }
}
