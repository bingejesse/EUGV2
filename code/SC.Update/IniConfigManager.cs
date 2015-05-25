using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SC.Update
{
    public class IniConfigManager
    {
        private IniFileController iniFileController;
        private const string appName = "SCSystem";

        public IniConfigManager()
        {
            string path = Environment.CurrentDirectory + "\\" + appName + ".ini";
            iniFileController = new IniFileController(path);
        }

        public string GetSCSystemVersion()
        {
            string result = "";
            try
            {
                result = this.iniFileController.IniReadValue(appName, "Version");
            }
            catch (Exception e)
            {
                result = "1.0.0.0";
            }

            return result;
        }

        public string GetSCSystemPath()
        {
            string result = "";
            try
            {
                result = this.iniFileController.IniReadValue(appName, "Path");
            }
            catch (Exception e)
            {

            }

            return result;
        }

        public string GetServerUpdateURL()
        {
            string result = "";
            try
            {
                result = this.iniFileController.IniReadValue(appName, "UpdateURL");
            }
            catch (Exception e)
            {
                result = "http://darene.cn/dareneApi/baimitong/update.xml";
            }

            return result;
        }
    }
}
