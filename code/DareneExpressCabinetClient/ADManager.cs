using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;

namespace DareneExpressCabinetClient
{
    public class ADManager
    {

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
