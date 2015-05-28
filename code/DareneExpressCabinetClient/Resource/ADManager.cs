using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using DareneExpressCabinetClient.Service;
using DareneExpressCabinetClient.Resource;
using Domain;

namespace DareneExpressCabinetClient
{
    public class ADManager
    {
        private const string ADResourceFile = "ADResource";
        private ServerService serverService;
        private About about;
        private string adFile;

        private static ADManager instance;
        /// <summary>
        /// 获得单例
        /// </summary>
        /// <returns></returns>
        public static ADManager GetInstance()
        {
            if (instance == null)
            {
                instance = new ADManager();
            }

            return instance;
        }

        /// <summary>
        /// 启动加载
        /// </summary>
        public void Load()
        {
            serverService = Service.Factory.ServicesFactory.GetInstance().GetServerService();
            about = AboutConfig.GetInstance().GetAbout();
            adFile = Environment.CurrentDirectory + "\\" + ADResourceFile;
            adImages = new List<Image>();

            UpdateAdImages();//必须先更新，再加载
            adImages = this.GetADImages();
        }

        private List<Image> adImages;
        /// <summary>
        /// 广告列表
        /// </summary>
        public List<Image> AdImages
        {
            get { return adImages; }
        }

        /// <summary>
        /// 更新广告图库
        /// </summary>
        private void UpdateAdImages()
        {
            ServerCallback4 sc4 = serverService.GetAdImageNames(about);
            List<string> newImages=sc4.Files;
            if (newImages.Count == 0)
            {
                return;
            }
            RemoveOldImages(newImages);
            DownloadNewImages(newImages);
        }

        /// <summary>
        /// 下载未在本地的图片
        /// </summary>
        /// <param name="images"></param>
        private void DownloadNewImages(List<string> images)
        {
            try
            {
                bool[] pass = new bool[images.Count];

                for (int i = 0; i < images.Count; i++)
                {
                    DirectoryInfo TheFolder = new DirectoryInfo(adFile);
                    FileInfo[] files = TheFolder.GetFiles();

                    for (int j = 0; j < files.Length; j++)
                    {
                        if (files[j].Name == images[i])
                        {
                            pass[i] = true;
                            continue;
                        }
                    }
                }

                for (int k = 0; k < pass.Length; k++)
                {
                    if (pass[k] == false)
                    {
                        Image image = serverService.DownloadImage(about, images[k]);

                        image.Save(adFile + "\\" + images[k]);
                    }
                }
            }
            catch (Exception e)
            {
                CLog4net.LogError("DownloadNewImages " + e);
            }
        }

        /// <summary>
        /// 移除不在目录中图片
        /// </summary>
        /// <param name="images"></param>
        private void RemoveOldImages(List<string> images)
        {
            try
            {

                bool over = false;
                while (over == false)
                {
                    DirectoryInfo TheFolder = new DirectoryInfo(adFile);
                    FileInfo[] files = TheFolder.GetFiles();

                    if (files.Length == 0)
                    {
                        over = true;
                        break;
                    }

                    bool[] pass = new bool[files.Length];
                    for (int i = 0; i < files.Length; i++)
                    {
                        for (int j = 0; j < images.Count; j++)
                        {
                            if (files[i].Name == images[j])
                            {
                                pass[i] = true;
                                continue;
                            }
                        }
                    }

                    bool resutl = true;
                    for (int k = 0; k < pass.Length; k++)
                    {
                        if (pass[k] == false)
                        {
                            files[k].Delete();
                        }

                        resutl = resutl & pass[k];
                    }

                    over = resutl;
                }
            }
            catch(Exception e)
            {
                CLog4net.LogError("RemoveOldImages " + e);
            }
        }


        private List<Image> GetADImages()
        {
            try
            {
                List<Image> images = null;
                DirectoryInfo TheFolder = new DirectoryInfo(adFile);
                foreach (FileInfo NextFile in TheFolder.GetFiles())
                {
                    if (images == null)
                    {
                        images = new List<Image>();
                    }
                    images.Add(Image.FromFile(NextFile.DirectoryName + "\\" + NextFile.Name));
                }
                return images;
            }
            catch (Exception e)
            {
                CLog4net.LogError("GetADImages " + e);
                return null;
            }
        }
    }
}
