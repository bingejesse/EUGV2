using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ICSharpCode.SharpZipLib.Zip;

namespace SC.Update
{
    class ZipFileController
    {
        /// <summary>
        /// 解压缩以后的文件名和路径，压缩前的路径
        /// </summary>
        /// <param name="FileToZip"></param>
        /// <param name="ZipedFile"></param>
        /// <returns></returns>
        public static Boolean UNZipFile(string FileToZip, string ZipedFile)
        {
            try
            {
                FastZip fastZip = new FastZip();
                fastZip.ExtractZip(FileToZip, ZipedFile, "");
                return true;
            }
            catch
            {
                return false;
            }

        }


        public static Boolean ZipFile(string FileToZip, string ZipedFile)
        {
            try
            {
                FastZip fastZip = new FastZip();

                bool recurse = true;

                //压缩后的文件名，压缩目录 ，是否递归 

                fastZip.CreateZip(FileToZip, ZipedFile, recurse, "");
                return true;
            }
            catch
            {
                return false;
            }

        }

    }
}
