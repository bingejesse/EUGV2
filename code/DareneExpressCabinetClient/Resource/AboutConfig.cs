using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DareneExpressCabinetClient.Service;
using System.IO;
using Domain;
using DareneExpressCabinetClient.Tools;

namespace DareneExpressCabinetClient.Resource
{
    public class AboutConfig
    {
        private static AboutConfig instance;

        private AboutConfig()
        {
        }

        public void Load()
        {
            this.service = Service.Factory.ServicesFactory.GetInstance().GetServerService();
            this.about = Service.Factory.ServicesFactory.GetInstance().GetDatabaseService().GetAbout();
            if (this.about == null)
            {
                CLog4net.LogError("AboutConfig null");
            }
            this.WriteConfig();

            CLog4net.LogInfo("AboutConfig is loaded");
        }

        /// <summary>
        /// 本套快递柜信息
        /// </summary>
        private About about;

        private ServerService service;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static AboutConfig GetInstance()
        {
            if (instance == null)
            {
                instance = new AboutConfig();
            }
            return instance;
        }

        public About GetAbout()
        {
            return about;
        }

        /// <summary>
        /// 写配置文件(彭秋生要求：为广告屏请求数据用)
        /// </summary>
        private void WriteConfig()
        {
            try
            {
                IniConfigManager ini = new IniConfigManager();
                string configFile = ini.GetAdvPath();
                if (!File.Exists(configFile))
                {
                    FileStream fs = new FileStream(configFile, FileMode.Create, FileAccess.Write);//创建写入文件 
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(this.about.CabinetCode);//开始写入值
                    sw.Close();
                    fs.Close();
                }
                else
                {
                    File.WriteAllText(configFile, string.Empty);
                    FileStream fs = new FileStream(configFile, FileMode.Open, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs);
                    sw.WriteLine(this.about.CabinetCode);//开始写入值
                    sw.Close();
                    fs.Close();
                }
            }
            catch (Exception e)
            {
                CLog4net.LogError("WriteConfig:" + e);
            }
        }

        /// <summary>
        /// 从服务器获取快递柜序号
        /// </summary>
        /// <returns></returns>
        public string GetCabinetCode()
        {
            if (this.about.CabinetCode == "")
            {
                try
                {
                    ServerCallback dic = this.service.CabinetConfig(this.about);
                    if (!dic.Success)
                    {
                        return "";
                    }

                    this.about.CabinetCode = Convert.ToString(dic.CabinetCode);
                }                
                catch(Exception e)
                {
                    CLog4net.LogError(e);
                    return "";
                }
            }

            return this.about.CabinetCode;
        }

        public bool Analysis()
        {
            string key = "ABCDEFGHIJKLMNOP";
            string result = CryptoHelper.Decrypt(this.about.Remark, key);

            if (result.Length != 12)
            {
                return false;
            }

            try
            {
                string tempDate = result.Substring(0, 10);
                DateTime tempTime = UnixTime.ConverUnixTimeToDateTime(Convert.ToInt32(tempDate));
                string tempDay = result.Remove(0, 10);

               int timespan = (int)DateTime.Now.Subtract(tempTime).TotalDays;
               if (timespan >Convert.ToInt32(tempDay))
               {
                   return false;
               }
            }
            catch (Exception e)
            {
                CLog4net.LogError(e.ToString());
                return false;
            }

            return true;
        }

        /// <summary>
        /// 配置快递柜信息
        /// </summary>
        public void SaveConfig()
        {

        }
        
    }
}
