using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace DareneExpressCabinetClient.Tools
{
    class GetPath
    {
        /// <summary>
        /// 获取当前应用程序所在目录的路径，最后不包含“\”
        /// </summary>
        /// <returns></returns>
        public static string GetStartupPath()
        {
            string temp = Application.StartupPath;
            return temp;
        }

        /// <summary>
        /// 获取当前应用程序文件的路径，包含文件的名称
        /// </summary>
        /// <returns></returns>
        public static string GetExecutablePath()
        {
            string temp = Application.ExecutablePath;
            return temp;
        }

        /// <summary>
        /// 获取当前应用程序的路径，最后不包含“\”
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentDirectory()
        {
            string temp = Environment.CurrentDirectory;
            return temp;
        }
    }
}
