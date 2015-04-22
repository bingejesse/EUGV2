using System;  
using System.Collections.Generic;  
using System.Linq;  
using System.Text;  
using System.Net.Security;  
using System.Security.Cryptography.X509Certificates;  
using System.DirectoryServices.Protocols;  
using System.ServiceModel.Security;  
using System.Net;  
using System.IO;  
using System.IO.Compression;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using DareneExpressCabinetClient.Service;
using System.Threading;
using Domain;

namespace DareneExpressCabinetClient.Tools
{
    /// <summary>  
    /// 有关HTTP请求的辅助类  
    /// </summary>  
    public class HttpWebResponseUtility
    {
        private static Mutex httpMutex = new Mutex();
        private static readonly string DefaultUserAgent = "Mozilla/4.0 (compatible; MSIE 6.0; Windows NT 5.2; SV1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
        /// <summary>  
        /// 创建GET方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="timeout">请求的超时时间</param>  
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <returns></returns>  
        public static HttpWebResponse CreateGetHttpResponse(string url, int? timeout, string userAgent, CookieCollection cookies)
        {
            httpMutex.WaitOne();
            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    throw new ArgumentNullException("url");
                }
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.UserAgent = DefaultUserAgent;
                if (!string.IsNullOrEmpty(userAgent))
                {
                    request.UserAgent = userAgent;
                }
                if (timeout.HasValue)
                {
                    request.Timeout = timeout.Value;
                }
                if (cookies != null)
                {
                    request.CookieContainer = new CookieContainer();
                    request.CookieContainer.Add(cookies);
                }
                return request.GetResponse() as HttpWebResponse;
            }
            catch (Exception e)
            {
                CLog4net.LogError(e.ToString());
                return null;
            }
            finally
            {
                httpMutex.ReleaseMutex();
            }
        }
        /// <summary>  
        /// 创建POST方式的HTTP请求  
        /// </summary>  
        /// <param name="url">请求的URL</param>  
        /// <param name="parameters">随同请求POST的参数名称及参数值字典</param>  
        /// <param name="timeout">请求的超时时间</param>  
        /// <param name="userAgent">请求的客户端浏览器信息，可以为空</param>  
        /// <param name="requestEncoding">发送HTTP请求时所用的编码</param>  
        /// <param name="cookies">随同HTTP请求发送的Cookie信息，如果不需要身份验证可以为空</param>  
        /// <returns></returns>  
        public static HttpWebResponse CreatePostHttpResponse(string url, IDictionary<string, string> parameters, int? timeout, string userAgent, Encoding requestEncoding, CookieCollection cookies)
        {
            httpMutex.WaitOne();

            try
            {
                if (string.IsNullOrEmpty(url))
                {
                    throw new ArgumentNullException("url");
                }
                if (requestEncoding == null)
                {
                    throw new ArgumentNullException("requestEncoding");
                }
                HttpWebRequest request = null;
                //如果是发送HTTPS请求  
                if (url.StartsWith("https", StringComparison.OrdinalIgnoreCase))
                {
                    ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(CheckValidationResult);
                    request = WebRequest.Create(url) as HttpWebRequest;
                    request.ProtocolVersion = HttpVersion.Version10;
                }
                else
                {
                    request = WebRequest.Create(url) as HttpWebRequest;
                }
                request.Method = "POST";
                request.ContentType = "application/x-www-form-urlencoded";

                if (!string.IsNullOrEmpty(userAgent))
                {
                    request.UserAgent = userAgent;
                }
                else
                {
                    request.UserAgent = DefaultUserAgent;
                }

                if (timeout.HasValue)
                {
                    request.Timeout = timeout.Value;
                }
                if (cookies != null)
                {
                    request.CookieContainer = new CookieContainer();
                    request.CookieContainer.Add(cookies);
                }
                //如果需要POST数据  
                if (!(parameters == null || parameters.Count == 0))
                {
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
                    byte[] data = requestEncoding.GetBytes(buffer.ToString());
                    using (Stream stream = request.GetRequestStream())
                    {
                        stream.Write(data, 0, data.Length);
                    }
                }

                return request.GetResponse() as HttpWebResponse;
            }
            catch (Exception e)
            {
                CLog4net.LogError(e.ToString());
                return null;
            }
            finally
            {
                httpMutex.ReleaseMutex();
            }
        }

        private static bool CheckValidationResult(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            return true; //总是接受  
        }

        public static void TestJson()
        {
            string result = "{success:false, boxCode:'',message: '找不到包裹'}\r\n";
            string result2 = "{success:true,message=''}\r\n";
            string result3 = "{success:true,boxCode:'6',message:''\r\n";
            string result4 = "{success:true,boxCode:'4',message:''\r\n";

            ServerCallback sc = new ServerCallback();
            StringReader sr = new StringReader(result2);
            JsonSerializer serializer = new JsonSerializer();
            try
            {
                sc = (ServerCallback)serializer.Deserialize(new JsonTextReader(sr), typeof(ServerCallback));
            }
            catch (Exception e)
            {
                CLog4net.LogError(e.ToString());
                //throw (e);
                sc = null;
            }

        }

        public static void TestPostHttps()
        {
            string loginUrl = "https://42.96.143.36:8443/index";

            Encoding encoding = Encoding.GetEncoding("gb2312");
            //Encoding encoding = Encoding.GetEncoding("utf8");

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("c", "Courier");
            parameters.Add("a", "login");
            parameters.Add("courierCode", "1000");
            //parameters.Add("cabinetCode", "20140801001");
            parameters.Add("cabinetCode", "21");
            parameters.Add("datetime", "1408202160");
            parameters.Add("token", "2b4109904540e7f1a858a70f99c76dad");

            CookieCollection cookies = new CookieCollection();//如何从response.Headers["Set-Cookie"];中获取并设置CookieCollection的代码略 
            HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, null, null, encoding, cookies);
            string cookieString = response.Headers["Set-Cookie"];

            string result = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            ServerCallback sc = new ServerCallback();
            StringReader sr = new StringReader(result);
            JsonSerializer serializer = new JsonSerializer();
            try
            {
                sc = (ServerCallback)serializer.Deserialize(new JsonTextReader(sr), typeof(ServerCallback));
            }
            catch (Exception e)
            {
                CLog4net.LogError(e.ToString());
                sc = null;
            }

            //JsonReader readerjson = new JsonTextReader(new StringReader(result));
            //JObject jo = JObject.Parse(result);
            //string[] values = jo.Properties().Select(item => item.Value.ToString()).ToArray();

            //DareneExpressCabinetClient.Service.ServerCallback cb = new DareneExpressCabinetClient.Service.ServerCallback();

            //StringReader sr = new StringReader(result);
            //JsonSerializer serializer = new JsonSerializer();
            ////StringReader sr = new StringReader(@"{""Input"":""stone"", ""Output"":""gold""}");
            //cb = (DareneExpressCabinetClient.Service.ServerCallback)serializer.Deserialize(new JsonTextReader(sr), typeof(DareneExpressCabinetClient.Service.ServerCallback));
            //Console.WriteLine(cb.Success + "=>" + cb.CabinetCode);

        }

        public static void TestGetHttp()
        {
            string userName = "userName";
            //string tagUrl = "http://cang.baidu.com/" + userName + "/tags";
            //string tagUrl = "http://localhost:8080/Loom/comm/get.do?id=1";
            string tagUrl = "http://localhost:8080/Loom/comm/get.do?id=1";
            CookieCollection cookies = new CookieCollection();//如何从response.Headers["Set-Cookie"];中获取并设置CookieCollection的代码略  
            HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(tagUrl, null, null, cookies);

            string result = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
            {
                result=reader.ReadToEnd();
            }


            JsonReader readerjson = new JsonTextReader(new StringReader(result));
        }

        public static void TestPostHttp()
        {
            string loginUrl = "http://localhost:8080/Loom/factory/get.do";
            string id = "1";

            IDictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("id", id);

            HttpWebResponse response = HttpWebResponseUtility.CreatePostHttpResponse(loginUrl, parameters, null, null, Encoding.UTF8, null);

            string result = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }


            JsonReader readerjson = new JsonTextReader(new StringReader(result));
            //while (readerjson.Read())
            //{
            //    Console.WriteLine(readerjson.TokenType + "\t\t" + readerjson.ValueType + "\t\t" + readerjson.Value);
            //}

            JObject jo = JObject.Parse(result);
            string[] values = jo.Properties().Select(item => item.Value.ToString()).ToArray(); 
        }
    }  
}
