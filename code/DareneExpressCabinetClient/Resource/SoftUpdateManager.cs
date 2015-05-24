using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.IO;
using System.Net;
using System.Xml;
using DareneExpressCabinetClient.Tools;
using Domain;

namespace DareneExpressCabinetClient.Resource
{
    /// <summary>
    /// 更新完成触发的事件
    /// </summary>
    public delegate void UpdateState();
    /// <summary>
    /// 程序更新
    /// </summary>
    public class SoftUpdateManager
    {

        private string download;
        private string updateUrl;

        #region 构造函数
        public SoftUpdateManager()
        {
            IniConfigManager ini = new IniConfigManager();
            updateUrl=ini.GetServerUpdateURL();
        }

        /// <summary>
        /// 程序更新
        /// </summary>
        /// <param name="file">要更新的文件</param>
        public SoftUpdateManager(string file, string softName):this()
        {
            this.LoadFile = file;
            this.SoftName = softName;
        }
        #endregion

        #region 属性
        private string loadFile;
        private string newVerson;
        private string softName;
        private bool isUpdate;

        /// <summary>
        /// 或取是否需要更新
        /// </summary>
        public bool IsUpdate
        {
            get
            {
                CheckUpdate();
                return isUpdate;
            }
        }

        /// <summary>
        /// 要检查更新的文件
        /// </summary>
        public string LoadFile
        {
            get { return loadFile; }
            set { loadFile = value; }
        }

        /// <summary>
        /// 程序集新版本
        /// </summary>
        public string NewVerson
        {
            get { return newVerson; }
        }

        /// <summary>
        /// 升级的名称
        /// </summary>
        public string SoftName
        {
            get { return softName; }
            set { softName = value; }
        }

        #endregion

        /// <summary>
        /// 更新完成时触发的事件
        /// </summary>
        public event UpdateState UpdateFinish;
        private void isFinish()
        {
            if (UpdateFinish != null)
                UpdateFinish();
        }

        /// <summary>
        /// 下载更新
        /// </summary>
        public void Update()
        {
            try
            {
                if (!isUpdate)
                    return;

                WebClient wc = new WebClient();

                string filename = "";
                string exten = download.Substring(download.LastIndexOf("."));
                if (loadFile.IndexOf(@"\") == -1)
                    filename = "Update_" + Path.GetFileNameWithoutExtension(loadFile) + exten;
                else
                    filename = Path.GetDirectoryName(loadFile) + "_" + Path.GetFileNameWithoutExtension(loadFile) + exten;

                //IniConfigManager ini = new IniConfigManager();
                //filename = ini.GetUpdateAppPath() + "/" + Path.GetFileNameWithoutExtension(loadFile) + exten;

                wc.DownloadFile(download, filename);
                wc.Dispose();
                isFinish();
            }
            catch(Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("下载更新出现错误，请确认网络连接无误后重试！");
                CLog4net.LogError("下载更新出现错误" + ex);
            }
        }

        /// <summary>
        /// 检查是否需要更新
        /// </summary>
        public void CheckUpdate()
        {
            try
            {
                WebClient wc = new WebClient();
                Stream stream = wc.OpenRead(updateUrl);
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(stream);
                XmlNode list = xmlDoc.SelectSingleNode("Update");
                foreach (XmlNode node in list)
                {
                    if (node.Name == "Soft" && node.Attributes["Name"].Value.ToLower() == SoftName.ToLower())
                    {
                        foreach (XmlNode xml in node)
                        {
                            if (xml.Name == "Verson")
                                newVerson = xml.InnerText;
                            else
                                download = xml.InnerText;
                        }
                    }
                }

                Version ver = new Version(newVerson);
                Version verson = Assembly.LoadFrom(loadFile).GetName().Version;
                int tm = verson.CompareTo(ver);

                if (tm >= 0)
                    isUpdate = false;
                else
                    isUpdate = true;
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("检测更新出现错误，请确认网络连接无误后重试！");
                CLog4net.LogError("检测更新出现错误" + ex);
            }
        }

        /// <summary>
        /// 获取要更新的文件
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return this.loadFile;
        }
    }
}
