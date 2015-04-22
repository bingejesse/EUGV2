using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DareneExpressCabinetClient.Service
{
    public interface BoxControlService : IDisposable
    {
        /// <summary>
        /// 初始化设备
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        bool Init();

        /// <summary>
        /// 开柜子
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Open(int code);
        /// <summary>
        /// 关柜子
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Close(int code);
        /// <summary>
        /// 获取当前柜子状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Box.State GetCurrentState(int code);
    }
}
