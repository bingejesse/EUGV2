using System.Collections;
using System.IO;
using System;

namespace DareneExpressCabinetClient.Tools
{
    /// <summary>
    /// 控制照片数量
    /// </summary>
    class ImageCountControl
    {
        /// <summary>
        /// 返回图像存储的文件夹
        /// </summary>
        /// <returns></returns>
        public static String FilePath()
        {
            string grabImagePath = string.Format(@"{0}\DataResources\ImageData\", GetPath.GetStartupPath());

            if (!Directory.Exists(grabImagePath))
            {
                Directory.CreateDirectory(grabImagePath);
            }
            return grabImagePath;
        }

        private static FileInfo[] GetFiles(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            FileInfo[] files = di.GetFiles();
            FileComparer fc = new FileComparer();
            Array.Sort(files, fc);
            return files;
        }


        /// <summary>
        /// 检测当前照片存储目录，文件数量超过count，删除最早一个
        /// </summary>
        /// <param name="count"></param>
        public static void FileCountControl(int count)
        {
            FileInfo[] files = GetFiles(FilePath());
            if (files.Length==0)
            {
                return;
            }
            else if (files.Length > count)
            {
                files[0].Delete();
            }
        }
        
}

    class FileComparer : IComparer
    {
        int IComparer.Compare(Object o1, Object o2)
        {
            FileInfo fi1 = o1 as FileInfo;
            FileInfo fi2 = o2 as FileInfo;
            return fi1.CreationTime.CompareTo(fi2.CreationTime);
        }
    }
}
