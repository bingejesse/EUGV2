using System.Windows.Forms;
using DareneExpressCabinetClient.Tools;
using DareneExpressCabinetClient.Service;
using DareneExpressCabinetClient.Resource;
using System.Security.Cryptography;
using Newtonsoft.Json.Linq;
using System.Net;
using System.IO;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System;
using Domain;

namespace DareneExpressCabinetClient
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private string result;
        private void button1_Click(object sender, EventArgs e)
        {
            //HttpWebResponseUtility.TestGetHttp();
            //HttpWebResponseUtility.TestPostHttp();
            //WebServiceCall.TestGet();

            //CameraService service = Service.Factory.ServicesFactory.GetInstance().GetCameraService();
            //service.TakePicture();

            InitCamera();

            if (this.button1.Text == "启动")
            {
                this.myPick.Start();
                this.button1.Text = "关闭";
            }
            else if (this.button1.Text == "关闭")
            {
                this.myPick.Stop();
                this.button1.Text = "启动";
            }
        }

        private Pick myPick;
        private void InitCamera()
        {
            try
            {
                myPick = new Pick(this.panelCamera.Handle, 0 + 5, 0 + 5, this.panelCamera.Width - 10, this.panelCamera.Height - 10);
                //this.myPick.Start();
                //this.button1.Text = "关闭";
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("打开摄像头失败");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CameraService service = Service.Factory.ServicesFactory.GetInstance().GetCameraService();
            service.TakePicture();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            VoiceService service = Service.Factory.ServicesFactory.GetInstance().GetVoicService();
            service.BroadcastOnce("习近平表示，尊敬的菲德尔同志，很高兴再次同你见面。2011年我访问古巴时拜访了你，我们进行了长时间交谈。今天看到你精神矍铄，我感到十分欣慰");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DatabaseService service = Service.Factory.ServicesFactory.GetInstance().GetDatabaseService();
            About a = service.GetAbout();
            a.ManagerName = "qwe";
            a.ManagerPassword = "8888";
            service.SaveAbout(a);
        }

        private void button5_Click(object sender, EventArgs e)
        {

            //string targetResult = string.Format("{\"v\":{0}}", 20);

            //string datetime = "1408202160";
            //string password = "1";
            //string temp = password + datetime;
            //string taken = CMD5.UserMd5(password + datetime);

            string clearText = UnixTime.ConvertDateTimeToUnixTime(new DateTime(2014, 9, 1)).ToString() + "30";
            string key = "ABCDEFGHIJKLMNOP";
            CryptoHelper helper = new CryptoHelper(key);
            string encryptedText = helper.Encrypt(clearText);
            Console.WriteLine(encryptedText);

            //string clearText1 = CryptoHelper.Decrypt(encryptedText, key);
            //string tempDate = clearText1.Substring(0, 10);
            //DateTime tempTime = UnixTime.ConverUnixTimeToDateTime(Convert.ToInt32(tempDate));
            //string tempDay = clearText1.Remove(0, 10);
            //Console.WriteLine(clearText1);

            //string source = temp;
            //using (MD5 md5Hash = MD5.Create())
            //{
            //    string hash = CMD5.GetMd5Hash(md5Hash, source);

            //    Console.WriteLine("The MD5 hash of " + source + " is: " + hash + ".");

            //    Console.WriteLine("Verifying the hash...");

            //    if (CMD5.VerifyMd5Hash(md5Hash, source, hash))
            //    {
            //        Console.WriteLine("The hashes are the same.");
            //    }
            //    else
            //    {
            //        Console.WriteLine("The hashes are not same.");
            //    }

            //    //taken = hash;

            //}


            //if (taken == "2b4109904540e7f1a858a70f99c76dad")
            //{
            //    Console.WriteLine("true");
            //}

            //HttpWebResponseUtility.TestJson();
            //HttpWebResponseUtility.TestPostHttps();
            //HttpWebResponseUtility.TestPostHttp();
            //WebServiceCall.TestGet();
        }

        private void button7_Click(object sender, EventArgs e)
        {

            //double time = UnixTime.ConvertDateTimeInt(DateTime.Now);
            DateTime begin = DateTime.Now;
            int timeInt = UnixTime.ConvertDateTimeToUnixTime(begin);
            DateTime dateTime = UnixTime.ConverUnixTimeToDateTime(timeInt);

            CLog4net.LogInfo(dateTime.ToShortTimeString());
        }

        private void TestJson(string jsonString)
        {
            var jsonVals = JArray.Parse(jsonString);
            foreach (JObject album in jsonVals)
            {
                Console.WriteLine(album["AlbumName"] + " (" + album["YearReleased"] + ")");
                foreach (JObject song in (JArray)album["Songs"])
                {
                    Console.WriteLine("\t" + song["SongName"]);
                }
            }
            Console.WriteLine(jsonVals[0]["AlbumName"]);
        }

        private const int delayTime = 20;
        private void button8_Click(object sender, EventArgs e)
        {
            ELock eLock = new ELock();
            eLock.Address = "192.168.1.25";
            eLock.Value = "2";
            eLock.Password = "123456";
            eLock.BoxCode = 1;
            string loginUrl = string.Format("http://{0}/gpio/ts/{1}?ac={2}&delay={3}", eLock.Address, eLock.Value, eLock.Password, delayTime);
            CookieCollection cookies = new CookieCollection();//如何从response.Headers["Set-Cookie"];中获取并设置CookieCollection的代码略  
            HttpWebResponse response = HttpWebResponseUtility.CreateGetHttpResponse(loginUrl, null, null, cookies);

            if (response == null)
            {
                return;
            }

            string result = "";
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.UTF8))
            {
                result = reader.ReadToEnd();
            }


            JsonReader readerjson = new JsonTextReader(new StringReader(result));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("要重新启动嘛？", "提示", MessageBoxButtons.YesNoCancel,
  MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //System.Diagnostics.Process.Start(System.Reflection.Assembly.GetExecutingAssembly().Location);
                //Application.Restart();
                chongqi();
            }
        }

        //------------关机方法
        public void guanji()
        {
            try
            {
                //启动本地程序并执行命令
                Process.Start("Shutdown.exe", " -s -t 0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        //----------重启重启
        public void chongqi()
        {
            try
            {
                //启动本地程序并执行命令
                Process.Start("shutdown.exe", " -r -t 0");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        //赠送一个使用win32API函数注销的

        //===================================================================================注销 函数 声明
        [DllImport("user32.dll", EntryPoint = "ExitWindowsEx", CharSet = CharSet.Ansi)]
        //ExitWindowsEx 函数
        private static extern int ExitWindowsEx(int uFlags, int dwReserved);
        //======================================================================================
        public void zhuxiao() //注销
        {
            ExitWindowsEx(0, 0);
        }

        private void button10_Click(object sender, EventArgs e)
        {

        }

        private void button11_Click(object sender, EventArgs e)
        {
            string path = "d:/deleteItems.xml";
            XmlHelper.Init(path);
            XmlHelper.Insert(path, "Items", "package", "sn", "12345");
            XmlHelper.Insert(path, "package", "timer", "", "1234567788");
        }
    }
}
