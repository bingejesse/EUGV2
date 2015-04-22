using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DareneExpressCabinetClient.Service
{
    public interface CabinetControlService
    {
        /// <summary>
        /// 开柜子
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Open(int id);
        /// <summary>
        /// 关柜子
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Close(int id);
        /// <summary>
        /// 获取当前柜子状态
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Cabinet.State GetCabinetCurrentState(int id);
    }
}
