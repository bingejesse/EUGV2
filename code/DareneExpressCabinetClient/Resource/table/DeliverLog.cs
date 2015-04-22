using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DareneExpressCabinetClient.Resource
{
    public class DeliverLog
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
        private string sn;
        /// <summary>
        /// 包裹序列号
        /// </summary>
        public string Sn
        {
            get { return sn; }
            set { sn = value; }
        }
        private string courierCode;
        /// <summary>
        /// 投递员Code
        /// </summary>
        public string CourierCode
        {
            get { return courierCode; }
            set { courierCode = value; }
        }
        private string receiverTelNum;
        /// <summary>
        /// 收件人手机号
        /// </summary>
        public string ReceiverTelNum
        {
            get { return receiverTelNum; }
            set { receiverTelNum = value; }
        }

        private int boxCode;
        /// <summary>
        /// 所在柜子id
        /// </summary>
        public int BoxCode
        {
            get { return boxCode; }
            set { boxCode = value; }
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
        private bool serverSaved;
        /// <summary>
        /// 0:未上传服务器  1：已经上传服务器
        /// </summary>
        public bool ServerSaved
        {
            get { return serverSaved; }
            set { serverSaved = value; }
        }
        private string remark;
        /// <summary>
        /// 备注
        /// </summary>
        public string Remark
        {
            get { return remark; }
            set { remark = value; }
        }
    }
}
