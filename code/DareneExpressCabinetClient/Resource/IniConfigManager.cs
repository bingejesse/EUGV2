using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using DareneExpressCabinetClient.Tools;

namespace DareneExpressCabinetClient.Resource
{
    public class IniConfigManager
    {
        private IniFileController iniFileController;

        public IniConfigManager()
        {
            string path = Environment.CurrentDirectory + "\\configInfo\\config.ini";
            iniFileController = new IniFileController(path);
        }

        #region About
        public string GetAboutTel()
        {
            string result = "";
            try
            {
                result=this.iniFileController.IniReadValue("About", "Tel");
            }
            catch (Exception e)
            {
                CLog4net.LogError(e);
            }

            return result;
        }

        public string GetAboutUrl()
        {
            string result = "";
            try
            {
                result = this.iniFileController.IniReadValue("About", "Url");
            }
            catch (Exception e)
            {
                CLog4net.LogError(e);
            }

            return result;
        }

        public string GetAboutVersion()
        {
            string result = "";
            try
            {
                result = this.iniFileController.IniReadValue("About", "Version");
            }
            catch (Exception e)
            {
                result = "1.0.0";
                CLog4net.LogError(e);
            }

            return result;
        }

        public string GetAboutCommissioningData()
        {
            string result = "";
            try
            {
                result = this.iniFileController.IniReadValue("About", "CommissioningData");
            }
            catch (Exception e)
            {
                CLog4net.LogError(e);
            }

            return result;
        }
        #endregion

        #region Adv
        public string GetAdvPath()
        {
            string result = "";
            try
            {
                result = this.iniFileController.IniReadValue("Adv", "Path");
            }
            catch (Exception e)
            {
                CLog4net.LogError(e);
            }

            return result;
        }
        #endregion

        #region Photo
        public string GetPhotoLength()
        {
            string result = "";
            try
            {
                result = this.iniFileController.IniReadValue("Photo", "Length");
            }
            catch (Exception e)
            {
                CLog4net.LogError(e);
            }

            return result;
        }

        #endregion

        #region Database
        public string GetDatabaseIp()
        {
            string result = "";
            try
            {
                result = this.iniFileController.IniReadValue("Database", "Ip");
            }
            catch (Exception e)
            {
                CLog4net.LogError(e);
            }

            return result;
        }

        public string GetDatabaseUsername()
        {
            string result = "";
            try
            {
                result = this.iniFileController.IniReadValue("Database", "Username");
            }
            catch (Exception e)
            {
                CLog4net.LogError(e);
            }

            return result;
        }

        public string GetDatabasePassword()
        {
            string result = "";
            try
            {
                result = this.iniFileController.IniReadValue("Database", "Password");
            }
            catch (Exception e)
            {
                CLog4net.LogError(e);
            }

            return result;
        }

        public string GetDatabaseName()
        {
            string result = "";
            try
            {
                result = this.iniFileController.IniReadValue("Database", "Name");
            }
            catch (Exception e)
            {
                CLog4net.LogError(e);
            }

            return result;
        }
        #endregion

        #region Server
        public string GetServerTimeup()
        {
            string result = "";
            try
            {
                result = this.iniFileController.IniReadValue("Server", "Timeup");
            }
            catch (Exception e)
            {
                CLog4net.LogError(e);
            }

            return result;
        }

        public string GetServerUpdateURL()
        {
            string result = "";
            try
            {
                result = this.iniFileController.IniReadValue("Server", "UpdateURL");
            }
            catch (Exception e)
            {
                result = "http://darene.cn/dareneApi/baimitong/update.xml";
                CLog4net.LogError(e);
            }

            return result;
        }
        #endregion

        #region can
        public string GetCanTimeout()
        {
            string result = "";
            try
            {
                result = this.iniFileController.IniReadValue("Can", "Timeout");
            }
            catch (Exception e)
            {
                result = "100";
                CLog4net.LogError(e);
            }

            return result;
        }

        public string GetCanDebug()
        {
            string result = "";
            try
            {
                result = this.iniFileController.IniReadValue("Can", "Debug");
            }
            catch (Exception e)
            {
                result = "false";
                CLog4net.LogError(e);
            }

            return result;
        }
        #endregion

        #region UpdateApp
        public string GetUpdateAppPath()
        {
            string result = "";
            try
            {
                result = this.iniFileController.IniReadValue("UpdateApp", "Path");
            }
            catch (Exception e)
            {
                CLog4net.LogError(e);
            }

            return result;
        }

        public string GetUpdateAppName()
        {
            string result = "";
            try
            {
                result = this.iniFileController.IniReadValue("UpdateApp", "Name");
            }
            catch (Exception e)
            {
                CLog4net.LogError(e);
            }

            return result;
        }
        #endregion
    }
}
