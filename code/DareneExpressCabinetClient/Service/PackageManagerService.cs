using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DareneExpressCabinetClient.Resource;

namespace DareneExpressCabinetClient.Service
{
    interface PackageManagerService
    {
         /// <summary>
        /// 从储物箱编号获得快递
        /// </summary>
        /// <param name="boxCode"></param>
        /// <returns></returns>
        Package FindPackageByBoxCode(int boxCode);

        /// <summary>
        /// 根据序列号获取快递
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        Package FindPackageBySN(string code);

        /// <summary>
        /// 快递员投入包裹
        /// </summary>
        /// <param name="courierId">柜子号</param>
        /// <param name="companyName"></param>
        /// <param name="sn"></param>
        /// <param name="receiverTelNum"></param>
        /// <param name="box"></param>
        /// <returns></returns>
        Package CreatePackage(string courierId, string companyName, string sn, string receiverTelNum, Box box);

        /// <summary>
        /// 投递操作成功
        /// </summary>
        void CreatePackageSuccess(Package p);

        /// <summary>
        /// 取件人根据密码获取包裹
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Package TakePackage(ServerCallback callback);

        /// <summary>
        /// 根据储物柜编号取走包裹
        /// </summary>
        /// <param name="boxCode"></param>
        /// <returns></returns>
        Package TakePackage(int boxCode);

        /// <summary>
        /// 投递员根据快递序列号和自己的id及包裹密码取回快递
        /// </summary>
        /// <param name="boxCode"></param>
        /// <param name="receiverIdentity">0：取件人；1:快递员；2：管理员；3其它</param>
        /// <returns></returns>
        bool TakePackage(int boxCode, byte receiverIdentity);
    }
}
