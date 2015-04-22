using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DareneExpressCabinetClient.Tools;
using System.Windows.Forms;
using System.IO;
using DareneExpressCabinetClient.Resource;
using Domain;

namespace DareneExpressCabinetClient.Service.Imple
{
    class CameraServiceImpl : CameraService
    {
        private Pick myPick;
        private Panel panelCamera;
        private string sPath;
        private const bool debug = true;
        private int photoCountLimit;

        private void InitCamera()
        {
            try
            {
                sPath = string.Format(@"{0}\DataResources\ImageData", GetPath.GetStartupPath());
                if (!Directory.Exists(sPath))
                {
                    Directory.CreateDirectory(sPath);
                }
                IniConfigManager iniManager = new IniConfigManager();
                try
                {
                    this.photoCountLimit = Convert.ToInt32(iniManager.GetPhotoLength());
                }
                catch(Exception e)
                {
                    CLog4net.LogError(e);
                }

                this.panelCamera = new Panel();
                // 
                // panelCamera
                // 
                this.panelCamera.BackColor = System.Drawing.Color.SlateGray;
                //this.panelCamera.Location = new System.Drawing.Point(320, 9);
                this.panelCamera.Name = "panelCamera";
                this.panelCamera.Size = new System.Drawing.Size(400, 300);

                myPick = new Pick(this.panelCamera.Handle, 0 + 5, 0 + 5, this.panelCamera.Width - 10, this.panelCamera.Height - 10);

                this.myPick.Start();
            }
            catch
            {
                System.Windows.Forms.MessageBox.Show("Camera Module Fault");
            }
        }

        public CameraServiceImpl()
        {
            //#if debug
            InitCamera();
            //#endif
        }

        #region CameraService 成员

        public bool TakePicture()
        {
            //#if debug
            //this.myPick.Start();

            System.Threading.Timer timer = new System.Threading.Timer(new System.Threading.TimerCallback(TimerProc1));
            timer.Change(1000, System.Threading.Timeout.Infinite);

            return false;
            //#endif
            //return true;
        }

        #endregion

        private void TimerProc1(object state)
        {
            System.Threading.Timer t = (System.Threading.Timer)state;
            //释放定时器资源
            t.Dispose();

            //执行流程1
            //
            //
            GrabImageAndSave();
            //this.myPick.Stop();

            Console.WriteLine("拍照结束");
        }

        void wait_Tick(object sender, EventArgs e)
        {
            GrabImageAndSave();
            this.myPick.Stop();
        }

        /// <summary>
        /// 抓图并保存
        /// </summary>
        private void GrabImageAndSave()
        {
            int beginTime = Environment.TickCount;
            string imageIndex = UnixTime.ConvertDateTimeToUnixTime(DateTime.Now).ToString();
            string grabImagePath = string.Format(@"{0}\DataResources\ImageData\{1}.jpg", GetPath.GetStartupPath(), imageIndex);
            this.myPick.GrabImage(grabImagePath);
            //System.Threading.Thread.Sleep(2000);

            this.ControlPhotoCount();

            Console.WriteLine("GrabImageAndSave Time Spaned: " + (Environment.TickCount-beginTime)+"ms");
        }

        private void ControlPhotoCount()
        {
            if (!Directory.Exists(sPath))
            {
                return;
            }
            string[] files = Directory.GetFiles(this.sPath);
            if (files.Length > this.photoCountLimit)
            {
                FileInfo fi = new FileInfo(files[0]);
                fi.Delete();
            }
        }


        public bool Open()
        {
            return true;
        }

        public void Close()
        {
            
        }
    }
}
