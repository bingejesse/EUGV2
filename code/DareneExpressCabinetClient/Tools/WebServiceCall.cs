using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Collections;
using System.Net;
using System.Xml.Serialization;
using System.IO;
using Domain;

namespace DareneExpressCabinetClient.Tools
{
    class WebServiceCall
    {
        //<webServices>
        // by 郁达飞  浙江嘉科新能源
        //</webServices>
        /*
                                     使用说明
         * 
         * 发送短信  public static  bool sendSMS(String target,String content)
         * 示例： 向号码为15858342188的手机发送helloworld字符串
         * WebServiceCall.sendSMS("15858342188","helloword");
         * 
         * 接收短信
         * public static string[] receiverSMS()  
         * 示例：
         * String[] myArray = new String[300000];
         * myArray = WebServiceCall.processSms(strmsg);
         * 短信会依次进入myArray数组，第一条手机的号码，内容，时间依次存放在myArray[0],myArray[1],myArray[2]
         * 第二天信息的的号码，内容，时间依次存放在myArray[3],myArray[4],myArray[5]...........依次类推
        */

        public static string s_number = "057382651761";
        public static string s_password = "jx82651761";

        public string sendxml_part1 = "<soapenv:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:def=\"http://DefaultNamespace\"><soapenv:Header/><soapenv:Body><def:sendMessages soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\"><mainphone xsi:type=\"xsd:string\">057382651761</mainphone><password xsi:type=\"xsd:string\">jx82651761</password><str xsi:type=\"xsd:string\">1/%/$/15858342187/%/$/1/%/$/helloworld/r/n/</str></def:sendMessages></soapenv:Body></soapenv:Envelope>";

        private static Hashtable _xmlNamespaces = new Hashtable();//缓存xmlNamespace，避免重复调用GetNamespace

        public static bool sendSMS(String target, String content)   //发送短信函数
        {
            String Url = "http://122.224.69.42:8181/axis/SendAndGetMessage.jws";
            Hashtable pars = new Hashtable();
            pars["mainphone"] = s_number;
            pars["password"] = s_password;
            pars["targetnumber"] = target;
            pars["content"] = content;
            try
            {
                XmlDocument doc = WebServiceCall.QuerySoapWebService(Url, "sendMessages", pars);
                return true;
            }
            catch (System.Exception ex)
            {
                CLog4net.LogError("sendsms "+ex.ToString());
                return false;
            }
        }

        public static string[] TestGet()
        {
            String Url = "http://localhost:8080/Loom/factory/get.do";
            Hashtable pars = new Hashtable();
            pars["id"] = 1;
            XmlDocument doc = WebServiceCall.QuerySoapWebService(Url, "getMessages", pars);
            String sDoc = doc.InnerXml;                                          //获得正文内容
            return processSms(sDoc);
        }

        public static string[] receiverSMS()                                      //接收短信函数
        {
            String Url = "http://122.224.69.42:8181/axis/SendAndGetMessage.jws";
            Hashtable pars = new Hashtable();
            pars["mainphone"] = s_number;
            pars["password"] = s_password;
            XmlDocument doc = WebServiceCall.QuerySoapWebService(Url, "getMessages", pars);
            String sDoc = doc.InnerXml;                                          //获得正文内容
            return processSms(sDoc);
        }

        public static string[] processSms(string strmsg)
        {
            String[] RecmsgArray = new String[300000];                       //用于存放接收到的短信内容

            int contentnum = 0;                                                       //记录有几条短信内容
            int tempK = 0;                                                              //用于保存每条记录的开始
            int temp = strmsg.LastIndexOf("/r/n");                           //保存字段的末尾
            if (temp < 0)
            {
                return null;
            }
            else
            {
                int temp1 = 0;                                                              //保存每条记录的关键节点1
                int temp2 = 0;                                                              //保存每条记录的关键节点2
                int temp3 = 0;                                                              //保存每条记录的关键节点3
                for (int i = 0; i < 100000; i++)
                {
                    temp1 = strmsg.IndexOf("/%/$", tempK);
                    temp2 = strmsg.IndexOf("/%/$", temp1 + 1);
                    temp3 = strmsg.IndexOf("/r/n", temp2 + 1);
                    String phonenum = "";
                    String msgcontent = "";
                    String msgtime = "";
                    //处理数据
                    for (int k = 0; k < 11; k++)                                       //获得手机号码
                    {
                        phonenum = phonenum + strmsg[temp1 - 11 + k].ToString();
                    }
                    for (int j = temp1 + 5; j < temp2; j++)                        //获得正文
                    {
                        msgcontent = msgcontent + strmsg[j];
                    }
                    for (int l = 0; l < 14; l++)                                          //获得时间
                    {
                        msgtime = msgtime + strmsg[temp3 - 14 + l].ToString();
                    }
                    //保存数据
                    RecmsgArray[contentnum * 3] = phonenum;
                    RecmsgArray[contentnum * 3 + 1] = msgcontent;
                    RecmsgArray[contentnum * 3 + 2] = msgtime;


                    if (temp3 >= temp)                                                    //如果读取记录已到尾部，则跳出循环
                    {
                        i = 100000;
                    }

                    tempK = temp3;
                    contentnum++;
                }

                return RecmsgArray;

            }

        }

        //**/
        /// <summary>
        /// 需要WebService支持Post调用
        /// </summary>
        public static XmlDocument QueryPostWebService(String URL, String MethodName, Hashtable Pars)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL + "/" + MethodName);
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            SetWebRequest(request);
            byte[] data = EncodePars(Pars);
            WriteRequestData(request, data);
            return ReadXmlResponse(request.GetResponse());
        }
        /**/
        /// <summary>
        /// 需要WebService支持Get调用
        /// </summary>
        public static XmlDocument QueryGetWebService(String URL, String MethodName, Hashtable Pars)
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL + "/" + MethodName + "?" + ParsToString(Pars));
            request.Method = "GET";
            request.ContentType = "application/x-www-form-urlencoded";
            SetWebRequest(request);
            return ReadXmlResponse(request.GetResponse());
        }


        /**/
        /// <summary>
        /// 通用WebService调用(Soap),参数Pars为String类型的参数名、参数值
        /// </summary>
        /// 


        public static XmlDocument QuerySoapWebService(String URL, String MethodName, Hashtable Pars)
        {
            if (_xmlNamespaces.ContainsKey(URL))
            {
                return QuerySoapWebService(URL, MethodName, Pars, _xmlNamespaces[URL].ToString());
            }
            else
            {
                return QuerySoapWebService(URL, MethodName, Pars, GetNamespace(URL));
            }
        }

        private static XmlDocument QuerySoapWebService(String URL, String MethodName, Hashtable Pars, string XmlNs)
        {
            _xmlNamespaces[URL] = XmlNs;                                //加入缓存，提高效率
            XmlDocument doc = new XmlDocument(), doc2 = new XmlDocument(), doc3 = new XmlDocument();
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(URL);
            request.Method = "POST";
            request.ContentType = "text/xml; charset=UTF-8";
            request.Headers.Add("SOAPAction", "\"" + XmlNs + (XmlNs.EndsWith("/") ? "" : "/") + MethodName + "\"");
            SetWebRequest(request);
            switch (MethodName)                                               //获得XML的正文内容，并转换成byte
            {
                case "sendMessages":
                    doc3.LoadXml(build_sendxml(Pars["mainphone"].ToString(), Pars["password"].ToString(), Pars["targetnumber"].ToString(), Pars["content"].ToString()));
                    break;
                case "getMessages":
                    doc3.LoadXml(build_receivexml(Pars["mainphone"].ToString(), Pars["password"].ToString()));
                    break;
            }

            byte[] data = Encoding.UTF8.GetBytes(doc3.OuterXml);
            WriteRequestData(request, data);
            doc = ReadXmlResponse(request.GetResponse());
            XmlNamespaceManager mgr = new XmlNamespaceManager(doc.NameTable);
            mgr.AddNamespace("soapevn", "http://schemas.xmlsoap.org/soap/envelope/");
            String RetXml = doc.SelectSingleNode("//soapevn:Body/*/*", mgr).InnerXml;
            doc2.LoadXml("<root>" + RetXml + "</root>");
            AddDelaration(doc2);
            return doc2;
        }

        private static string GetNamespace(String URL)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(URL + "?WSDL");
            SetWebRequest(request);
            WebResponse response = request.GetResponse();
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(sr.ReadToEnd());
            sr.Close();
            return doc.SelectSingleNode("//@targetNamespace").Value;
        }

        private static string ObjectToSoapXml(object o)
        {
            XmlSerializer mySerializer = new XmlSerializer(o.GetType());
            MemoryStream ms = new MemoryStream();
            mySerializer.Serialize(ms, o);
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(Encoding.UTF8.GetString(ms.ToArray()));
            if (doc.DocumentElement != null)
            {
                return doc.DocumentElement.InnerXml;
            }
            else
            {
                return o.ToString();
            }
        }

        private static void SetWebRequest(HttpWebRequest request)
        {
            request.Credentials = CredentialCache.DefaultCredentials;
            request.Timeout = 10000;
        }

        private static void WriteRequestData(HttpWebRequest request, byte[] data)
        {
            request.ContentLength = data.Length;
            Stream writer = request.GetRequestStream();
            writer.Write(data, 0, data.Length);
            writer.Close();
        }

        private static byte[] EncodePars(Hashtable Pars)
        {
            return Encoding.UTF8.GetBytes(ParsToString(Pars));
        }

        private static String ParsToString(Hashtable Pars)
        {
            StringBuilder sb = new StringBuilder();
            foreach (string k in Pars.Keys)
            {
                if (sb.Length > 0)
                {
                    sb.Append("&");
                }
                //sb.Append(HttpUtility.UrlEncode(k) + "=" + HttpUtility.UrlEncode(Pars[k].ToString()));
                sb.Append(k + "=" + Pars[k].ToString());
            }

            return sb.ToString();
        }

        private static XmlDocument ReadXmlResponse(WebResponse response)
        {
            StreamReader sr = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
            String retXml = sr.ReadToEnd();
            sr.Close();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(retXml);
            return doc;
        }

        private static void AddDelaration(XmlDocument doc)
        {
            XmlDeclaration decl = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.InsertBefore(decl, doc.DocumentElement);
        }

        private static string build_sendxml(string mainphone, string password, string targetnumber, string content)
        {
            //构建发送短信XML（）参数
            string tosend = "";
            string sendpart1 = "<soapenv:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:def=\"http://DefaultNamespace\"><soapenv:Header/><soapenv:Body><def:sendMessages soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\"><mainphone xsi:type=\"xsd:string\">";
            string sendpart2 = mainphone;
            string sendpart3 = "</mainphone><password xsi:type=\"xsd:string\">";
            string sendpart4 = password;
            string sendpart5 = "</password><str xsi:type=\"xsd:string\">1/%/$/";
            string sendpart6 = targetnumber;
            string sendpart7 = "/%/$/1/%/$/";
            string sendpart8 = content;
            string sendpart9 = "/r/n/</str></def:sendMessages></soapenv:Body></soapenv:Envelope>";
            tosend = sendpart1 + sendpart2 + sendpart3 + sendpart4 + sendpart5 + sendpart6 + sendpart7 + sendpart8 + sendpart9;
            return tosend;
        }

        private static string build_receivexml(string mainphone, string password)
        {
            //构建接收短信XML（）参数
            string sendpart1 = "<soapenv:Envelope xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" xmlns:xsd=\"http://www.w3.org/2001/XMLSchema\" xmlns:soapenv=\"http://schemas.xmlsoap.org/soap/envelope/\" xmlns:def=\"http://DefaultNamespace\"><soapenv:Header/><soapenv:Body><def:getMessages soapenv:encodingStyle=\"http://schemas.xmlsoap.org/soap/encoding/\"><mainphone xsi:type=\"xsd:string\">";
            string sendpart2 = mainphone;
            string sendpart3 = "</mainphone><password xsi:type=\"xsd:string\">";
            string sendpart4 = password;
            string sendpart5 = "</password></def:getMessages></soapenv:Body></soapenv:Envelope>";
            string tosend = sendpart1 + sendpart2 + sendpart3 + sendpart4 + sendpart5;
            return tosend;
        }

    }
}
