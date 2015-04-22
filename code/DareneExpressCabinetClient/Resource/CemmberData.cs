using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DareneExpressCabinetClient.Resource
{
    public class CemmberData
    {
        public static CemmberData Instance = new CemmberData();

        /// <summary>
        /// Can控制器连接失败
        /// </summary>
        public bool IsCanConnectFail { get; set; }

        /// <summary>
        /// 摄像头连接失败
        /// </summary>
        public bool IsCameraConnectFail { get; set; }

        /// <summary>
        /// 服务器连接失败
        /// </summary>
        public bool IsServerConnectFail { get; set; }
    }
}
