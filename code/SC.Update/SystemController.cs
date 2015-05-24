using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace SC.Update
{
    class SystemController
    {
        //private static string filePath = "d:/eug.txt";

        public string ReadEUGText(string filePath)
        {
            string text = "";

            try
            {
                if (File.Exists(filePath))
                {
                    StreamReader sr = new StreamReader(filePath);
                    text = sr.ReadToEnd();
                }
            }
            catch
            {

            }

            return text;
        }


    }
}
