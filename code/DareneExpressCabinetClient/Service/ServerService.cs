using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DareneExpressCabinetClient.Resource;

namespace DareneExpressCabinetClient.Service
{
    public interface ServerService
    {
        /// <summary>
        /// 快递柜配置JSON	{"success":true,”cabinetCode”:0123}
        /// </summary>
        /// <param name="about"></param>
        /// <returns></returns>
        ServerCallback CabinetConfig(About about);

        /// <summary>
        /// 2.	快递员认证JSON	{"success":true, “companyName”:“顺丰”}
        /// </summary>
        /// <param name="cou"></param>
        /// <param name="about"></param>
        /// <returns></returns>
        ServerCallback CourierLogin(Courier cou, About about);

        /// <summary>
        /// 3.	创建包裹
        /// </summary>
        /// <param name="pac"></param>
        /// <param name="about"></param>
        /// <returns></returns>
        ServerCallback PackageCreate(Package pac, About about);

        /// <summary>
        /// 4.	收件人认证JSON	{"success":true,”boxCode”:”123” }
        /// </summary>
        /// <param name="password"></param>
        /// <param name="about"></param>
        /// <returns></returns>
        ServerCallback RceiverLogin(string password, About about);

        /// <summary>
        /// 5.	快递员取回JSON	{"success":true, “boxCode”: “01234” }
        /// </summary>
        /// <param name="pac"></param>
        /// <param name="about"></param>
        /// <returns></returns>
        ServerCallback CourierTackBack(string sn,Courier cour, About about);

        /// <summary>
        /// 6.	投递记录
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        bool PackageDeliverLog(DeliverLog log,About about);

        /// <summary>
        /// 7.	取件记录
        /// </summary>
        /// <param name="log"></param>
        /// <returns></returns>
        bool PackagePickUpLog(PickUpLog log, About about);

        /// <summary>
        /// 查询远程开箱指令
        /// </summary>
        /// <param name="about"></param>
        /// <returns></returns>
        ServerCallback2 OpenBoxCmdListener(About about);

        /// <summary>
        /// 响应远程开箱指令
        /// </summary>
        /// <param name="code"></param>
        /// <param name="isOpen"></param>
        /// <returns></returns>
        bool ResponseOpenBoxCmd(string code, bool isOpen, About about);

        /// <summary>
        /// 快递柜启动握手指令
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cabinetCode"></param>
        /// <param name="datetime"></param>
        /// <returns></returns>
        ServerCallback3 ServiceShakeHand(About about,IDictionary<string,string> dic);

        /// <summary>
        /// 从服务器获得通知信息
        /// </summary>
        /// <param name="token"></param>
        /// <param name="cabinetCode"></param>
        /// <param name="datetime"></param>
        /// <returns></returns>
        ServerCallback3 GetBroadcastMessage(About about);

        /// <summary>
        /// 管理员删除包裹
        /// </summary>
        /// <param name="about"></param>
        /// <returns></returns>
        ServerCallback3 ManagerDeletePackage(string boxCode, About about);

        /// <summary>
        /// 同步指令
        /// </summary>
        /// <param name="pack"></param>
        /// <param name="about"></param>
        /// <returns></returns>
        //ServerCallback3 SyncPackState(Package pack, About about);

        /// <summary>
        /// 12.	快递员查询快件 (2.0新增)
        /// </summary>
        /// <param name="about"></param>
        /// <param name="courier"></param>
        /// <param name="pageNum"></param>
        /// <returns></returns>
        string GetCourierSearchPGUrl(About about, Courier courier, int pageNum);

        /// <summary>
        /// 13.	收件人查询快件 (2.0新增)
        /// </summary>
        /// <param name="about"></param>
        /// <param name="packageCode"></param>
        /// <param name="pageNum"></param>
        /// <returns></returns>
        string GetRceiverSearchPGUrl(About about, string packageCode, int pageNum);

        /// <summary>
        /// 14.	首页广告查询
        /// </summary>
        /// <param name="about"></param>
        /// <returns></returns>
        ServerCallback4 GetAdImageNames(About about);


        /// <summary>
        /// 15.	首页广告下载
        /// </summary>
        /// <param name="about"></param>
        /// <param name="imageName"></param>
        /// <returns></returns>
        System.Drawing.Image DownloadImage(About about, string imageName);
    }

    public class ServerCallback
    {
        /// <summary>
        /// 成功
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 快递柜代码
        /// </summary>
        public object CabinetCode { get; set; }

        /// <summary>
        /// 投递员公司名称
        /// </summary>
        public string CompanyName { get; set; }

        /// <summary>
        /// 储物箱编号
        /// </summary>
        public object BoxCode { get; set; }

        /// <summary>
        /// 消息：成功为空，不成功返回错误指示
        /// </summary>
        public string Message { get; set; }

    }

    public class ServerCallback2
    {
        /// <summary>
        /// 有开箱指令为true，否则为false
        /// </summary>
        public bool HasOpenOrder { get; set; }

        /// <summary>
        /// 需要打开的箱号
        /// </summary>
        public string Boxnumber { get; set; }

        /// <summary>
        /// 校验码
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// 消息：成功为空，不成功返回错误指示
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 收到回执
        /// </summary>
        public bool Received { get; set; }

    }

    public class ServerCallback3
    {
        /// <summary>
        /// 是否收到回执
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 服务器响应时的时间
        /// </summary>
        public string Servertime { get; set; }

        /// <summary>
        /// 消息：成功为空，不成功返回错误指示
        /// </summary>
        public string Message { get; set; }

    }

    public class ServerCallback4
    {
        /// <summary>
        /// 是否收到回执
        /// </summary>
        public bool Success { get; set; }

        /// <summary>
        /// 消息：成功为空，不成功返回错误指示
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 广告图片的名称代码列表
        /// </summary>
        public List<string> Files { get; set; }
    }

}
