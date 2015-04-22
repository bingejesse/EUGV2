using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using DareneExpressCabinetClient.Tools;
using DareneExpressCabinetClient.Resource;

namespace DareneExpressCabinetClient.Service
{
    class BoxControlServiceImplByHttp : BoxControlService
    {
        #region BoxControlService 成员
        private const int delayTime = 20;
        public bool Open(int code)
        {
            ELock eLock = ELocksManager.GetInstance().GetLock(code);
            if (eLock==null||eLock.BoxCode==0)
            {
                return false;
            }

            #region 调试用
            return true;
            #endregion

            string loginUrl = string.Format("http://{0}/gpio/ts/{1}?ac={2}&delay={3}", eLock.Address, eLock.Value, eLock.Password, delayTime);
            CookieCollection cookies = new CookieCollection();//如何从response.Headers["Set-Cookie"];中获取并设置CookieCollection的代码略  
            HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(loginUrl, null, null, cookies);

            if (response == null)
            {
                return false;
            }

            string result = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }
  
            string targetResult = "{\"v\":" + delayTime + "}";
            if (result == targetResult)
            {
                return true;
            }

            return false;
        }

        public bool Close(int code)
        {
            #region 调试用
            //return true;
            #endregion

            ELock eLock = ELocksManager.GetInstance().GetLock(code);
            if (eLock == null || eLock.BoxCode == 0)
            {
                return false;
            }

            string loginUrl = string.Format("http://{0}/gpio/ts/{1}?ac={2}&delay={3}", eLock.Address, eLock.Value, eLock.Password, delayTime);
            CookieCollection cookies = new CookieCollection();//如何从response.Headers["Set-Cookie"];中获取并设置CookieCollection的代码略  
            HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(loginUrl, null, null, cookies);

            if (response == null)
            {
                return false;
            }
            string result = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            string targetResult = string.Format("{\"v\":{0}}", delayTime);

            if (result == targetResult)
            {
                return true;
            }

            return false;
        }

        public Box.State GetCurrentState(int code)
        {
            #region 调试用
            //return Box.State.Close;
            #endregion

            ELock eLock = ELocksManager.GetInstance().GetLock(code); ;
            if (eLock == null || eLock.BoxCode == 0)
            {
                return Box.State.Close;
            }

            string loginUrl = string.Format("http://{0}/coils/{1}?ac={2}", eLock.Address, eLock.Value, eLock.Password);
            CookieCollection cookies = new CookieCollection();//如何从response.Headers["Set-Cookie"];中获取并设置CookieCollection的代码略  
            HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(loginUrl, null, null, cookies);
            if (response == null)
            {
                return Box.State.Close;
            }
            string result = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }

            if (result.Equals("{\"v\":1}"))
            {
                return Box.State.Open;
            }
            else if (result.Equals("{\"v\":0}"))
            {
                return Box.State.Close;
            }
            return Box.State.Close;
        }

        #endregion

        public void Dispose()
        {
        }

        public bool Init()
        {
            return true;
        }
    }
}
