using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using DareneExpressCabinetClient.Resource;

namespace DareneExpressCabinetClient.Service
{
    public interface DatabaseService
    {
        /// <summary>
        /// 获取最后一条的about
        /// </summary>
        /// <returns></returns>
        About GetAbout();

        /// <summary>
        /// 插入新的about
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool SaveAbout(About obj);

        /// <summary>
        /// 更新about
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool UpdateAbout(About obj);

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        bool UpdateAboutPassword(string password);

        /// <summary>
        /// 获取box列表
        /// </summary>
        /// <returns></returns>
        List<Box> GetBoxs();


        /// <summary>
        /// 根据大小获取当前可用箱子
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        int GetIdleBoxCount(Box.Size size);

        /// <summary>
        /// 根据大小随机获取box
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        Box GetIdleBoxBySize(Box.Size size);

        /// <summary>
        /// 插入新的box
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool SaveBox(Box obj);

        /// <summary>
        /// 根据code更新box
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool UpdateBox(Box obj);

        /// <summary>
        /// 获取package列表
        /// </summary>
        /// <returns></returns>
        List<Package> GetPackages();

        /// <summary>
        /// 插入新的package
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool SavePackage(Package obj);

        /// <summary>
        /// 根据sn更新package的DeletedTime，Taken，ReceiverIdentity，RemarkInfo
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool UpdatePackage(Package obj);

        /// <summary>
        /// 根据sn删除package
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool DeletePackage(Package obj);

        /// <summary>
        /// 插入新的投递记录
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool SaveDeliverLog(DeliverLog obj);

        /// <summary>
        /// 根据id更新DeliverLog表的serverSaved
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool UpdateDeliverLog(DeliverLog obj);

        /// <summary>
        /// 根据serverSaved=0 查找DeliverLog表
        /// </summary>
        /// <returns></returns>
        List<DeliverLog> GetDeliverLogNoUpload();

        /// <summary>
        /// 插入新的PickUpLog
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool SavePickUpLog(PickUpLog obj);

        /// <summary>
        /// 根据id更新PickUpLog表的serverSaved
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        bool UpdatePickUpLog(PickUpLog obj);

        /// <summary>
        /// 根据serverSaved=0 查找PickUpLog表
        /// </summary>
        /// <returns></returns>
        List<PickUpLog> GetPickUpLogNoUpload();

        /// <summary>
        /// 获得锁控板信息
        /// </summary>
        /// <returns></returns>
        List<ELock> GetELock();
    }
}
