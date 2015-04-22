using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DareneExpressCabinetClient.Service
{
    interface BoxsManagerService
    {
        /// <summary>
        /// 获得当前各个型号可用柜子数量
        /// </summary>
        /// <returns></returns>
        int[] GetAvailableBoxCount();

        /// <summary>
        /// 根据编号查找储物箱
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Box Find(int code);

        /// <summary>
        /// 根据size随机寻找一个空闲有用的柜子
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        Box Find(Box.Size size);

        /// <summary>
        /// 停用柜子
        /// </summary>
        /// <param name="code"></param>
        void DisableBox(int code);

        /// <summary>
        /// 启用柜子
        /// </summary>
        /// <param name="code"></param>
        void EnableBox(int code);

         /// <summary>
        /// 清空柜子
        /// </summary>
        /// <param name="code"></param>
        void ClearBox(int code);
    }
}
