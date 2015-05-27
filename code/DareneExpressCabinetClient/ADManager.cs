using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using DareneExpressCabinetClient.Service;
using DareneExpressCabinetClient.Resource;

namespace DareneExpressCabinetClient
{
    public class ADManager
    {

        private ServerService serverService;
        private About about;

        public void Load()
        {
            serverService = Service.Factory.ServicesFactory.GetInstance().GetServerService();
            about = AboutConfig.GetInstance().GetAbout();
        }

        private List<string> imageNames = new List<string>();
        /// <summary>
        /// 广告列表
        /// </summary>
        public List<string> ImageNames
        {
            get { return imageNames; }
            set { imageNames = value; }
        }

        public void UpdateAdImages()
        {
            ServerCallback4 sc4 = serverService.GetAdImageNames(about);
            List<string> newImages=sc4.Files;
            if (newImages.Count == 0)
            {
                return;
            }

            List<Image> oldImages = GetADImages();

            for (int i = 0; i < newImages.Count; i++)
            {
                for (int j = 0; j < oldImages.Count; j++)
                {
                    //if(oldImages[j].
                }
            }

        }


        public static List<Image> GetADImages()
        {
            List<Image> images = null;
            DirectoryInfo TheFolder = new DirectoryInfo(Environment.CurrentDirectory + "\\ADResource");
            foreach (FileInfo NextFile in TheFolder.GetFiles())
            {
                if (images == null)
                {
                    images = new List<Image>();
                }
                images.Add(Image.FromFile(NextFile.DirectoryName+"\\"+NextFile.Name));
            }

            return images;
        }
    }
}
