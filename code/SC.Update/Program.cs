using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace SC.Update
{
    class Program
    {
        private static string appName = "SCSystem";
        private static string appExe = "SC.View2";

        static void Main(string[] args)
        {
            try
            {
                IniConfigManager ini = new IniConfigManager();
                string appPath = ini.GetSCSystemPath();
                string appVersion = ini.GetSCSystemVersion();
                string serverUpdateURL = ini.GetServerUpdateURL();
                SoftUpdateManager sofrUpdateManager = new SoftUpdateManager(appPath, appName, serverUpdateURL, appVersion);
                if (sofrUpdateManager.IsUpdate == false)
                {
                    Console.WriteLine("App is the last version");
                    return;
                }

                bool success = false;
                Console.WriteLine("App is't the last version");
                Console.WriteLine("zip file is downloading......");
                sofrUpdateManager.Update();
                Console.WriteLine("download success");
                string updatePackage = Path.GetDirectoryName(appPath) + "\\" + appName + ".zip";
                if (System.IO.File.Exists(updatePackage))
                {
                    success = ZipFileController.UNZipFile(updatePackage, Path.GetDirectoryName(appPath));
                    Console.WriteLine("uncompress zip file : "+ success);
                }

                StartApp(appPath);

                Console.WriteLine("update is finished");
                Console.Read();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        /// <summary>
        /// 关闭进程中的任务
        /// </summary>
        /// <returns></returns>
        private static bool CloseApp()
        {
            Process[] pProcess;
            pProcess = Process.GetProcesses();
            for (int i = 1; i <= pProcess.Length - 1; i++)
            {
                Console.WriteLine(pProcess[i].ProcessName);
                if (pProcess[i].ProcessName.ToLower() == appName.ToLower() || pProcess[i].ProcessName.ToLower() == appName.ToLower() + ".vshost")
                {
                    bool result= pProcess[i].CloseMainWindow();
                    return result;
                }
            }
            return false;
        }

        /// <summary>
        /// 用cmd启动应用程序
        /// </summary>
        /// <param name="appPath"></param>
        private static void StartApp(string appPath)
        {
            try
            {
                Process cmd = new Process();
                cmd.StartInfo.FileName = "cmd";
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;

                cmd.Start();
                cmd.StandardInput.WriteLine("cd " + appPath);
                cmd.StandardInput.WriteLine(appExe + ".exe");

                cmd.Close();
                Console.WriteLine("cmd close");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

    }
}
