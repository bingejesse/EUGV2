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
        private static string appName = "SC.View2";
        private static string eugText = "D:/SCUpdate/SCSystem.txt";

        static void Main(string[] args)
        {
            try
            {
                string parm = Convert.ToString(args[0]);
                Console.WriteLine("1 " + parm);
                eugText = parm.Split(';')[0];
                appName = parm.Split(';')[1];
                Console.WriteLine("2");
                bool success = false;
                SystemController sc = new SystemController();

                string filePath = sc.ReadEUGText(eugText);
                //string updatePackage = filePath + "_" + appName + ".zip";
                //Console.WriteLine("3 " + filePath + " " + updatePackage);
                //if (filePath != "")
                //{
                //    if (CloseApp())
                //    {
                //        string targetPath = filePath;
                //        Directory.SetCurrentDirectory(Directory.GetParent(targetPath).FullName);
                //        targetPath = Directory.GetCurrentDirectory();

                //        if (System.IO.File.Exists(updatePackage))
                //        {
                //            success = ZipFileController.UNZipFile(updatePackage, targetPath);
                //        }
                //    }
                //}

                //if (success)
                //{
                //    StartApp(filePath);
                //}

                StartApp(filePath);

                Console.WriteLine("update is success:" + success);
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
            Console.WriteLine("4 " + appName);
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
                cmd.StandardInput.WriteLine(appName + ".exe");

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
