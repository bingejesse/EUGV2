using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DareneExpressCabinetClient.Tools;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DareneExpressCabinetClient.Resource;
using Domain;

namespace DareneExpressCabinetClient.Service.Imple
{
    class ServerServiceImpl : ServerService
    {
        //private const string cabinetConfig = "cabinet/config.do";
        //private const string courierLogin="courier/login.do";
        //private const string packageCreate="package/create.do";
        //private const string receiverLogin="receiver/login.do";
        //private const string courierTackBack="courier/tackBack.do";
        //private const string packageDeliverLog="package/deliverLog.do";
        //private const string packagePickUpLog="package/pickUpLog.do";
        private const string cabinetConfig = "";
        private const string courierLogin = "";
        private const string packageCreate = "";
        private const string receiverLogin = "";
        private const string courierTackBack = "";
        private const string packageDeliverLog = "";
        private const string packagePickUpLog = "";

        /// <summary>
        /// 服务器超时时间
        /// </summary>
        private int timeoutMSecond = 3000;

        public ServerServiceImpl()
        {
            IniConfigManager iniManager=new IniConfigManager();
            try
            {
                timeoutMSecond = Convert.ToInt32(iniManager.GetServerTimeup());
            }
            catch(Exception e)
            {
                CLog4net.LogError(e);
            }
        }

        /// <summary>
        /// 快递柜配置
        /// </summary>
        /// <param name="about"></param>
        /// <returns></returns>
        public ServerCallback CabinetConfig(Resource.About about)
        {
            ServerCallback sc = new ServerCallback();
            string loginUrl = about.ServerUrl + courierLogin;
            Encoding encoding = Encoding.GetEncoding("gb2312");

            IDictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("cabinetName", about.Name);
            parameters.Add("companyName", about.CompanyName);
            parameters.Add("address", about.Address);
            parameters.Add("telNum", about.TelNum);
            parameters.Add("configTime", UnixTime.ConvertDateTimeToUnixTime(about.ConfigTime).ToString());
            parameters.Add("createdTime", UnixTime.ConvertDateTimeToUnixTime(about.CreatedTime).ToString());
            parameters.Add("remark", about.Remark);

            try
            {
                string result = "";
                using (HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, timeoutMSecond, null, encoding, null))
                {

                    string cookieString = response.Headers["Set-Cookie"];
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }
                }

                StringReader sr = new StringReader(result);
                JsonSerializer serializer = new JsonSerializer();
                try
                {
                    sc = (ServerCallback)serializer.Deserialize(new JsonTextReader(sr), typeof(ServerCallback));
                }
                catch (Exception e)
                {
                    CLog4net.LogError("CabinetConfig"+e);
                }

                CLog4net.LogInfo("服务器连接：" + result);
            }
            catch (Exception e)
            {
                CLog4net.LogError(e);
            }
            return sc;
        }

        /// <summary>
        /// 快递员认证
        /// </summary>
        /// <param name="cou"></param>
        /// <param name="about"></param>
        /// <returns></returns>
        public ServerCallback CourierLogin(Courier cou, About about)
        {
            ServerCallback sc = new ServerCallback();
            string loginUrl = about.ServerUrl + cabinetConfig;
            Encoding encoding = Encoding.GetEncoding("gb2312");

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            string datetime = UnixTime.ConvertDateTimeToUnixTime(DateTime.Now).ToString();
            string taken = CMD5.UserMd5(cou.Password) + CMD5.UserMd5(datetime);
            parameters.Add("token", CMD5.UserMd5(taken));
            parameters.Add("courierCode", cou.Code.ToString());
            parameters.Add("cabinetCode", about.CabinetCode.ToString());
            parameters.Add("datetime", datetime);
            parameters.Add("c", "Courier");
            parameters.Add("a", "login");

            try
            {
                string result = "";
                using (HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, timeoutMSecond, null, encoding, null))
                {

                    string cookieString = response.Headers["Set-Cookie"];
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }
                }

                StringReader sr = new StringReader(result);
                JsonSerializer serializer = new JsonSerializer();

                try
                {
                    sc = (ServerCallback)serializer.Deserialize(new JsonTextReader(sr), typeof(ServerCallback));
                }
                catch (Exception e)
                {
                    CLog4net.LogError(e.ToString());

                }
                CLog4net.LogInfo("服务器连接：" + result);
            }
            catch (Exception e)
            {
                CLog4net.LogError("CourierLogin"+e);
            }
            return sc;
        }

        /// <summary>
        /// 创建包裹
        /// </summary>
        /// <param name="pac"></param>
        /// <param name="about"></param>
        /// <returns></returns>
        public ServerCallback PackageCreate(Resource.Package pac, Resource.About about)
        {
            ServerCallback sc = new ServerCallback();
            string loginUrl = about.ServerUrl + packageCreate;
            Encoding encoding = Encoding.GetEncoding("gb2312");

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            string datetime = UnixTime.ConvertDateTimeToUnixTime(DateTime.Now).ToString();
            string token = CMD5.UserMd5(pac.Courier.Code) + CMD5.UserMd5(datetime);
             //柜子地址
            string boxName = pac.Place.CoordinateInfo.X.ToString() + pac.Place.CoordinateInfo.Y.ToString();
            parameters.Add("token", CMD5.UserMd5(token));
            parameters.Add("courierCode", pac.Courier.Code.ToString());
            parameters.Add("boxName", boxName);
            parameters.Add("packageCode", pac.SN);
            parameters.Add("boxCode", pac.Place.Code.ToString());
            parameters.Add("receiverTelNum", pac.ReceiverTelNum);
            parameters.Add("cabinetCode", about.CabinetCode.ToString());
            parameters.Add("datetime", UnixTime.ConvertDateTimeToUnixTime(pac.CreatedTime).ToString());
            parameters.Add("c", "Pack");
            parameters.Add("a", "putpack");

            try
            {
                string result = "";
                using (HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, timeoutMSecond, null, encoding, null))
                {

                    string cookieString = response.Headers["Set-Cookie"];
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }
                }

                StringReader sr = new StringReader(result);
                JsonSerializer serializer = new JsonSerializer();
                try
                {
                    sc = (ServerCallback)serializer.Deserialize(new JsonTextReader(sr), typeof(ServerCallback));
                }
                catch (Exception e)
                {
                    CLog4net.LogError(e.ToString());

                }
                CLog4net.LogInfo("服务器连接：" + result);
            }
            catch (Exception e)
            {
                CLog4net.LogError("PackageCreate"+e);
            }
            return sc;
        }

        /// <summary>
        /// 收件人认证
        /// </summary>
        /// <param name="password"></param>
        /// <param name="about"></param>
        /// <returns></returns>
        public ServerCallback RceiverLogin(string password, Resource.About about)
        {
            ServerCallback sc = new ServerCallback();
            string loginUrl = about.ServerUrl + receiverLogin;
            Encoding encoding = Encoding.GetEncoding("gb2312");

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            string datetime = UnixTime.ConvertDateTimeToUnixTime(DateTime.Now).ToString();
            string token = CMD5.UserMd5(password) + CMD5.UserMd5(datetime);
            parameters.Add("token", CMD5.UserMd5(token));
            parameters.Add("smsCode", password);
            parameters.Add("cabinetCode", about.CabinetCode.ToString());
            parameters.Add("datetime", datetime);
            parameters.Add("c", "Receiver");
            parameters.Add("a", "login");

            try
            {
                string result = "";
                using (HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, timeoutMSecond, null, encoding, null))
                {

                    string cookieString = response.Headers["Set-Cookie"];
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }
                }

                StringReader sr = new StringReader(result);
                JsonSerializer serializer = new JsonSerializer();
                try
                {
                    sc = (ServerCallback)serializer.Deserialize(new JsonTextReader(sr), typeof(ServerCallback));
                }
                catch (Exception e)
                {
                    CLog4net.LogError(e.ToString());

                }
                CLog4net.LogInfo("服务器连接：" + result);
            }
            catch (Exception e)
            {
                CLog4net.LogError("RceiverLogin"+e);
            }
            return sc;
        }

        /// <summary>
        /// 快递员取回
        /// </summary>
        /// <param name="pac"></param>
        /// <param name="about"></param>
        /// <returns></returns>
        public ServerCallback CourierTackBack(string sn,Courier cour, Resource.About about)
        {
            ServerCallback sc = new ServerCallback();
            string loginUrl = about.ServerUrl + courierTackBack;
            Encoding encoding = Encoding.GetEncoding("gb2312");

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            string datetime = UnixTime.ConvertDateTimeToUnixTime(DateTime.Now).ToString();
            string token = CMD5.UserMd5(cour.Code) + CMD5.UserMd5(datetime);
            parameters.Add("token", CMD5.UserMd5(token));
            parameters.Add("courierCode", cour.Code);
            parameters.Add("packageCode", sn);
            parameters.Add("cabinetCode", about.CabinetCode);
            parameters.Add("datetime", datetime);
            parameters.Add("c", "Courier");
            parameters.Add("a", "getback");

            try
            {
                string result = "";
                using (HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, timeoutMSecond, null, encoding, null))
                {

                    string cookieString = response.Headers["Set-Cookie"];
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }
                }

                StringReader sr = new StringReader(result);
                JsonSerializer serializer = new JsonSerializer();
                try
                {
                    sc = (ServerCallback)serializer.Deserialize(new JsonTextReader(sr), typeof(ServerCallback));
                }
                catch (Exception e)
                {
                    CLog4net.LogError(e.ToString());

                }
                CLog4net.LogInfo("服务器连接：" + result);
            }
            catch (Exception e)
            {
                CLog4net.LogError("CourierTackBack"+e);
            }
            return sc;
        }

        public bool PackageDeliverLog(Resource.DeliverLog log, About about)
        {
            ServerCallback sc = new ServerCallback();
            string loginUrl = about.ServerUrl + packageDeliverLog;
            Encoding encoding = Encoding.GetEncoding("gb2312");

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("courierCode", log.CourierCode.ToString());
            parameters.Add("sn", log.Sn);
            parameters.Add("boxCode", log.BoxCode.ToString());
            parameters.Add("receiverTelNum", log.ReceiverTelNum);
            parameters.Add("cabinetCode", about.CabinetCode.ToString());
            parameters.Add("createdTime", UnixTime.ConvertDateTimeToUnixTime(log.CreatedTime).ToString());
            parameters.Add("remark", log.Remark);
            try
            {
                string result = "";
                using (HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, timeoutMSecond, null, encoding, null))
                {

                    string cookieString = response.Headers["Set-Cookie"];
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }
                }

                StringReader sr = new StringReader(result);
                JsonSerializer serializer = new JsonSerializer();
                try
                {
                    sc = (ServerCallback)serializer.Deserialize(new JsonTextReader(sr), typeof(ServerCallback));
                }
                catch (Exception e)
                {
                    CLog4net.LogError(e.ToString());

                }
                CLog4net.LogInfo("服务器连接：" + result);
            }
            catch (Exception e)
            {
                CLog4net.LogError("PackageDeliverLog"+e);
            }
            return sc.Success;
        }

        public bool PackagePickUpLog(Resource.PickUpLog log, About about)
        {
            ServerCallback sc = new ServerCallback();
            string loginUrl = about.ServerUrl + packageDeliverLog;
            Encoding encoding = Encoding.GetEncoding("gb2312");

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("courierCode", log.CourierCode.ToString());
            parameters.Add("sn", log.Sn);
            parameters.Add("boxCode", log.BoxCode.ToString());
            parameters.Add("receiverTelNum", log.ReceiverTelNum);
            parameters.Add("cabinetCode", about.CabinetCode.ToString());
            parameters.Add("deletedTime", UnixTime.ConvertDateTimeToUnixTime(log.DeletedTime).ToString());
            parameters.Add("receiverIdentity", log.ReceiverIdentity.ToString());
            parameters.Add("remark", log.Remark);
            try
            {
                string result = "";
                using (HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, timeoutMSecond, null, encoding, null))
                {

                    string cookieString = response.Headers["Set-Cookie"];
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }
                }

                StringReader sr = new StringReader(result);
                JsonSerializer serializer = new JsonSerializer();
                try
                {
                    sc = (ServerCallback)serializer.Deserialize(new JsonTextReader(sr), typeof(ServerCallback));
                }
                catch (Exception e)
                {
                    CLog4net.LogError(e.ToString());

                }
                CLog4net.LogInfo("服务器连接：" + result);
            }
            catch (Exception e)
            {
                CLog4net.LogError("PackagePickUpLog"+e);
            }
            return sc.Success;
        }


        public ServerCallback2 OpenBoxCmdListener(About about)
        {
            ServerCallback2 sc = new ServerCallback2();
            string loginUrl = about.ServerUrl;
            Encoding encoding = Encoding.GetEncoding("gb2312");

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            string datetime = UnixTime.ConvertDateTimeToUnixTime(DateTime.Now).ToString();
            string token = CMD5.UserMd5(about.CabinetCode) + CMD5.UserMd5(datetime);
            parameters.Add("token", CMD5.UserMd5(token));
            parameters.Add("cabinetCode", about.CabinetCode);
            parameters.Add("datetime", datetime);
            parameters.Add("c", "Pack");
            parameters.Add("a", "remoteOpenBox");
            try
            {
                string result = "";
                using (HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, timeoutMSecond, null, encoding, null))
                {

                    string cookieString = response.Headers["Set-Cookie"];
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }
                }

                StringReader sr = new StringReader(result);
                JsonSerializer serializer = new JsonSerializer();

                try
                {
                    sc = (ServerCallback2)serializer.Deserialize(new JsonTextReader(sr), typeof(ServerCallback2));
                }
                catch (Exception e)
                {
                    CLog4net.LogError(e.ToString());

                }
                CLog4net.LogInfo("服务器连接：" + result);
            }
            catch (Exception e)
            {
                CLog4net.LogError("OpenBoxCmdListener"+e);
            }
            return sc;
        }

        public bool ResponseOpenBoxCmd(string code, bool isOpen,About about)
        {
            ServerCallback2 sc = new ServerCallback2();
            string loginUrl = about.ServerUrl;
            Encoding encoding = Encoding.GetEncoding("gb2312");

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            string datetime = UnixTime.ConvertDateTimeToUnixTime(DateTime.Now).ToString();
            string orderstatus = isOpen == true ? "boxopened" : "error";
            string token = CMD5.UserMd5(code) + CMD5.UserMd5(datetime);
            parameters.Add("token", CMD5.UserMd5(token));
            parameters.Add("code", code);
            parameters.Add("orderstatus",orderstatus);
            parameters.Add("datetime", datetime);
            parameters.Add("c", "Pack");
            parameters.Add("a", "remoteOpenBoxFeedback");
            try
            {
                string result = "";
                using (HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, timeoutMSecond, null, encoding, null))
                {

                    string cookieString = response.Headers["Set-Cookie"];
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }
                }

                StringReader sr = new StringReader(result);
                JsonSerializer serializer = new JsonSerializer();

                try
                {
                    sc = (ServerCallback2)serializer.Deserialize(new JsonTextReader(sr), typeof(ServerCallback2));
                }
                catch (Exception e)
                {
                    CLog4net.LogError(e);

                }
                CLog4net.LogInfo("服务器连接：" + result);
            }
            catch (Exception e)
            {
                CLog4net.LogError("ResponseOpenBoxCmd"+e);
            }
            return sc.Received;
        }


        public ServerCallback3 ServiceShakeHand(About about, IDictionary<string, string> dic)
        {
            ServerCallback3 sc = new ServerCallback3();
            string loginUrl = about.ServerUrl;
            Encoding encoding = Encoding.GetEncoding("gb2312");

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            string datetime = UnixTime.ConvertDateTimeToUnixTime(DateTime.Now).ToString();
            string token = CMD5.UserMd5(about.CabinetCode) + CMD5.UserMd5(datetime);
            parameters.Add("cabinetCode", about.CabinetCode);
            parameters.Add("datetime", datetime);
            parameters.Add("c", "Security");
            parameters.Add("a", "hiCabinet");

            if (dic != null)
            {
                StringBuilder cabinetStatus = new StringBuilder();
                cabinetStatus.Append("{");
                cabinetStatus.Append(dic["camera"]);
                cabinetStatus.Append(",");
                cabinetStatus.Append(dic["comcard"]);
                cabinetStatus.Append("}");
                parameters.Add("cabinetStatus", cabinetStatus.ToString());
            }
            try
            {
                string result = "";
                using (HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, timeoutMSecond, null, encoding, null))
                {

                    string cookieString = response.Headers["Set-Cookie"];
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }
                }

                StringReader sr = new StringReader(result);
                JsonSerializer serializer = new JsonSerializer();

                try
                {
                    sc = (ServerCallback3)serializer.Deserialize(new JsonTextReader(sr), typeof(ServerCallback3));
                }
                catch (Exception e)
                {
                    CLog4net.LogError(e.ToString());

                }
                CLog4net.LogInfo("服务器连接：" + result);
            }
            catch (Exception e)
            {
                CLog4net.LogError("ServiceShakeHand"+e);
            }
            return sc;
        }

        public ServerCallback3 GetBroadcastMessage(About about)
        {
            ServerCallback3 sc = new ServerCallback3();
            string loginUrl = about.ServerUrl;
            Encoding encoding = Encoding.GetEncoding("gb2312");

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            string datetime = UnixTime.ConvertDateTimeToUnixTime(DateTime.Now).ToString();
            string token = CMD5.UserMd5(about.CabinetCode) + CMD5.UserMd5(datetime);
            parameters.Add("cabinetCode", about.CabinetCode);
            parameters.Add("datetime", datetime);
            parameters.Add("c", "Message");
            parameters.Add("a", "weather");
            try
            {
                string result = "";
                using (HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, timeoutMSecond, null, encoding, null))
                {

                    string cookieString = response.Headers["Set-Cookie"];
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }
                }

                StringReader sr = new StringReader(result);
                JsonSerializer serializer = new JsonSerializer();

                try
                {
                    sc = (ServerCallback3)serializer.Deserialize(new JsonTextReader(sr), typeof(ServerCallback3));
                }
                catch (Exception e)
                {
                    CLog4net.LogError(e.ToString());

                }
                CLog4net.LogInfo("服务器连接：" + result);
            }
            catch (Exception e)
            {
                CLog4net.LogError("GetBroadcastMessage"+e);
            }
            return sc;
        }


        public ServerCallback3 ManagerDeletePackage(string boxCode, About about)
        {
            ServerCallback3 sc = new ServerCallback3();
            string loginUrl = about.ServerUrl;
            Encoding encoding = Encoding.GetEncoding("gb2312");

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            string datetime = UnixTime.ConvertDateTimeToUnixTime(DateTime.Now).ToString();
            string token = CMD5.UserMd5(boxCode) + CMD5.UserMd5(datetime) + CMD5.UserMd5(CMD5.UserMd5(about.CabinetCode));
            parameters.Add("token", CMD5.UserMd5(token));
            parameters.Add("box", boxCode);
            parameters.Add("cabinetCode", about.CabinetCode);
            parameters.Add("datetime", datetime);
            parameters.Add("c", "Admin");
            parameters.Add("a", "openbox");
            try
            {
                string result = "";
                using (HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, timeoutMSecond, null, encoding, null))
                {

                    string cookieString = response.Headers["Set-Cookie"];
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }
                }

                StringReader sr = new StringReader(result);
                JsonSerializer serializer = new JsonSerializer();

                try
                {
                    sc = (ServerCallback3)serializer.Deserialize(new JsonTextReader(sr), typeof(ServerCallback3));
                }
                catch (Exception e)
                {
                    sc = null;
                    CLog4net.LogError(e.ToString());

                }
                CLog4net.LogInfo("服务器连接：" + result);
            }
            catch (Exception e)
            {
                CLog4net.LogError("ManagerDeletePackage " + e);
            }
            return sc;
        }

        public string GetCourierSearchPGUrl(About about,Courier courier,int pageNum)
        {
            string result="";
            string loginUrl = about.ServerUrl;
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            string datetime = UnixTime.ConvertDateTimeToUnixTime(DateTime.Now).ToString();
            string token = CMD5.UserMd5(about.CabinetCode) + CMD5.UserMd5(datetime);
            parameters.Add("token", CMD5.UserMd5(token));
            parameters.Add("cabinetCode", about.CabinetCode);
            parameters.Add("courierCode", courier.Code);
            parameters.Add("datetime", datetime);
            parameters.Add("reqPageNum", pageNum.ToString());
            parameters.Add("c", "Courier");
            parameters.Add("a", "packstatus");

            StringBuilder buffer = new StringBuilder();
            int i = 0;
            foreach (string key in parameters.Keys)
            {
                if (i > 0)
                {
                    buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                }
                else
                {
                    buffer.AppendFormat("{0}={1}", key, parameters[key]);
                }
                i++;
            }

            result = about.ServerUrl+"?" + buffer.ToString();

            return result;
        }

        public string GetRceiverSearchPGUrl(About about, string packageCode, int pageNum)
        {
            string result = "";
            string loginUrl = about.ServerUrl;
            IDictionary<string, string> parameters = new Dictionary<string, string>();
            string datetime = UnixTime.ConvertDateTimeToUnixTime(DateTime.Now).ToString();
            string token = CMD5.UserMd5(about.CabinetCode) + CMD5.UserMd5(datetime);
            parameters.Add("token", CMD5.UserMd5(token));
            parameters.Add("cabinetCode", about.CabinetCode);
            parameters.Add("packageCode", packageCode);
            parameters.Add("datetime", datetime);
            parameters.Add("reqPageNum", pageNum.ToString());
            parameters.Add("c", "Receiver");
            parameters.Add("a", "packstatus");

            StringBuilder buffer = new StringBuilder();
            int i = 0;
            foreach (string key in parameters.Keys)
            {
                if (i > 0)
                {
                    buffer.AppendFormat("&{0}={1}", key, parameters[key]);
                }
                else
                {
                    buffer.AppendFormat("{0}={1}", key, parameters[key]);
                }
                i++;
            }

            result = about.ServerUrl + "?" + buffer.ToString();

            return result;
        }


        public ServerCallback4 GetAdImageNames(About about)
        {
            ServerCallback4 sc = new ServerCallback4();
            string loginUrl = about.ServerUrl;
            Encoding encoding = Encoding.GetEncoding("gb2312");

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            string datetime = UnixTime.ConvertDateTimeToUnixTime(DateTime.Now).ToString();
            string token = CMD5.UserMd5(about.CabinetCode) + CMD5.UserMd5(datetime);
            parameters.Add("token", CMD5.UserMd5(token));
            parameters.Add("cabinetCode", about.CabinetCode);
            parameters.Add("datetime", datetime);
            parameters.Add("c", "Adimage");
            parameters.Add("a", "query");
            try
            {
                string result = "";
                using (HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, timeoutMSecond, null, encoding, null))
                {

                    string cookieString = response.Headers["Set-Cookie"];
                    using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
                    {
                        result = reader.ReadToEnd();
                    }
                }

                StringReader sr = new StringReader(result);
                JsonSerializer serializer = new JsonSerializer();

                try
                {
                    sc = (ServerCallback4)serializer.Deserialize(new JsonTextReader(sr), typeof(ServerCallback4));
                }
                catch (Exception e)
                {
                    CLog4net.LogError(e.ToString());

                }
                CLog4net.LogInfo("服务器连接：" + result);
            }
            catch (Exception e)
            {
                CLog4net.LogError("GetAdImageNames" + e);
            }
            return sc;
        }

        public System.Drawing.Image DownloadImage(About about, string imageName)
        {
            System.Drawing.Image ad = null;
            string loginUrl = about.ServerUrl;
            Encoding encoding = Encoding.GetEncoding("gb2312");

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            string datetime = UnixTime.ConvertDateTimeToUnixTime(DateTime.Now).ToString();
            string token = CMD5.UserMd5(about.CabinetCode) + CMD5.UserMd5(datetime);
            parameters.Add("token", CMD5.UserMd5(token));
            parameters.Add("cabinetCode", about.CabinetCode);
            parameters.Add("filename", imageName);
            parameters.Add("datetime", datetime);
            parameters.Add("c", "Adimage");
            parameters.Add("a", "download");
            try
            {
                using (HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, timeoutMSecond, null, encoding, null))
                {
                    Stream stream = response.GetResponseStream();

                    ad = System.Drawing.Bitmap.FromStream(stream);
                    stream.Close();  
                }

                
                CLog4net.LogInfo("服务器连接：获得图片");
            }
            catch (Exception e)
            {
                CLog4net.LogError("GetAdImageNames" + e);
            }
            return ad;
        }
    }
}
