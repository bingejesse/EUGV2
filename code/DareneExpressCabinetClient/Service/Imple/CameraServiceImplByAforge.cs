using AForge.Video.DirectShow;
using System;
using DareneExpressCabinetClient.Tools;
using System.Drawing;
using AForge.Video;
using System.IO;
using DareneExpressCabinetClient.Resource;
using Domain;

namespace DareneExpressCabinetClient.Service.Imple
{
    class CameraServiceImplByAforge:CameraService
    {
        private FilterInfoCollection videoDevices;
        private VideoCaptureDevice videoSource;
        private Bitmap bitmapBuffer;
        private string sPath;
        private int photoCountLimit;

        public CameraServiceImplByAforge()
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
            catch (Exception e)
            {
                CLog4net.LogError(e);
            }

            try
            {
                // 枚举所有视频输入设备
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);

                if (videoDevices.Count == 0)
                {
                    CemmberData.Instance.IsCameraConnectFail = true;
                    CLog4net.LogError("未检测到摄像头");
                }
                else
                {
                    CemmberData.Instance.IsCameraConnectFail = false;
                }
            }
            catch (ApplicationException)
            {
                CemmberData.Instance.IsCameraConnectFail = true;
                CLog4net.LogError("No local capture devices");
                videoDevices = null;
            }
        }

        public bool Open()
        {
            if (videoDevices == null)
            {
                return false;
            }
            else if (videoDevices.Count == 0)
            {
                return false;
            }

            if (videoSource == null)
            {
                try
                {
                    videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                    videoSource.DesiredFrameSize = new Size(320, 240);
                    videoSource.DesiredFrameRate = 1;
                    videoSource.NewFrame += new NewFrameEventHandler(myCaptureDevice_NewFrame);
                    videoSource.Start();
                }
                catch (Exception e)
                {
                    CLog4net.LogError("Camera faile" + e);
                    return false;
                }

                return true;
            }

            return false;
        }

        private void myCaptureDevice_NewFrame(object sender, NewFrameEventArgs eventArgs)//帧处理程序
        {
            bitmapBuffer = (Bitmap)eventArgs.Frame.Clone();
        }

        /// <summary>
        /// 抓图并保存
        /// </summary>
        private bool GrabImageAndSave()
        {
            if (videoDevices == null)
            {
                return false;
            }

            if (this.bitmapBuffer == null)
            {
                return false;
            }
            int beginTime = Environment.TickCount;
            string imageIndex = UnixTime.ConvertDateTimeToUnixTime(DateTime.Now).ToString();
            string grabImagePath = string.Format(@"{0}\DataResources\ImageData\{1}.jpg", GetPath.GetStartupPath(), imageIndex);
            this.bitmapBuffer.Save(grabImagePath);

            this.ControlPhotoCount();

            Console.WriteLine("GrabImageAndSave Time Spaned: " + (Environment.TickCount - beginTime) + "ms");

            return true;
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

        public bool TakePicture()
        {
            return GrabImageAndSave();
        }

        public void Close()
        {
            if (videoSource != null)
            {
                if (videoSource.IsRunning)
                {
                    videoSource.SignalToStop();
                    videoSource = null;
                }
            }
        }
    }
}
