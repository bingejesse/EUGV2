using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DareneExpressCabinetClient.Resource
{
    public class Package
    {
        private string sn;
        /// <summary>
        /// 序列号
        /// </summary>
        public string SN
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

        private string receiverTelNum;
        /// <summary>
        /// 收件人电话
        /// </summary>
        public string ReceiverTelNum
        {
            get { return receiverTelNum; }
            set { receiverTelNum = value; }
        }


        //private string key;
        ///// <summary>
        ///// 取出密码
        ///// </summary>
        //public string Key
        //{
        //    get { return key; }
        //    set { key = value; }
        //}

        private DateTime createdTime;
        /// <summary>
        /// 投递时间
        /// </summary>
        public DateTime CreatedTime
        {
            get { return createdTime; }
            set { createdTime = value; }
        }

        private DateTime deletedTime;
        /// <summary>
        /// 取件时间
        /// </summary>
        public DateTime DeletedTime
        {
            get { return deletedTime; }
            set { deletedTime = value; }
        }

        private Box place;
        /// <summary>
        /// 存放地点
        /// </summary>
        public Box Place
        {
            get { return place; }
            set { place = value; }
        }


        private bool taken;
        /// <summary>
        /// 是否被取走 False：被取走 true：在柜中
        /// </summary>
        public bool Taken
        {
            get { return taken; }
            set { taken = value; }
        }

        private byte receiverIdentity;
        /// <summary>
        /// 取件人身份 0:收件人  1：投递员  2：其它
        /// </summary>
        public byte ReceiverIdentity
        {
            get { return receiverIdentity; }
            set { receiverIdentity = value; }
        }

        private string remarkInfo;
        /// <summary>
        /// 备注信息
        /// </summary>
        public string RemarkInfo
        {
            get { return remarkInfo; }
            set { remarkInfo = value; }
        }

        private bool isNeedUpdate;
        /// <summary>
        /// 是否需要更新
        /// </summary>
        public bool IsNeedUpdate
        {
            get { return isNeedUpdate; }
            set { isNeedUpdate = value; }
        }
    }
}
