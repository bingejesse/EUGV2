using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DareneExpressCabinetClient.Service
{
    public interface SMSCenterService
    {
        /// <summary>
        /// 发送短信接口
        /// </summary>
        /// <param name="telNum">对面手机号</param>
        /// <param name="message">消息</param>
        /// <returns></returns>
        bool SendNote(int telNum,string message);
    }
}
