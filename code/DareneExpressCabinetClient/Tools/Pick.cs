using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace DareneExpressCabinetClient.Tools
{
    /// <summary>
    /// 一个控制摄像头的类
    /// </summary>
    public class Pick
    {
        private const int WM_USER = 0x400;
        private const int WS_CHILD = 0x40000000;
        private const int WS_VISIBLE = 0x10000000;
        private const int WM_CAP_START = WM_USER;
        private const int WM_CAP_STOP = WM_CAP_START + 68;
        private const int WM_CAP_DRIVER_CONNECT = WM_CAP_START + 10;
        private const int WM_CAP_DRIVER_DISCONNECT = WM_CAP_START + 11;
        private const int WM_CAP_SAVEDIB = WM_CAP_START + 25;
        private const int WM_CAP_GRAB_FRAME = WM_CAP_START + 60;
        private const int WM_CAP_SEQUENCE = WM_CAP_START + 62;
        private const int WM_CAP_FILE_SET_CAPTURE_FILEA = WM_CAP_START + 20;
        private const int WM_CAP_SEQUENCE_NOFILE = WM_CAP_START + 63;
        private const int WM_CAP_SET_OVERLAY = WM_CAP_START + 51;
        private const int WM_CAP_SET_PREVIEW = WM_CAP_START + 50;
        private const int WM_CAP_SET_CALLBACK_VIDEOSTREAM = WM_CAP_START + 6;
        private const int WM_CAP_SET_CALLBACK_ERROR = WM_CAP_START + 2;
        private const int WM_CAP_SET_CALLBACK_STATUSA = WM_CAP_START + 3;
        private const int WM_CAP_SET_CALLBACK_FRAME = WM_CAP_START + 5;
        private const int WM_CAP_SET_SCALE = WM_CAP_START + 53;
        private const int WM_CAP_SET_PREVIEWRATE = WM_CAP_START + 52;
        private IntPtr hWndC;
        private bool bStat = false;
        private IntPtr mControlPtr;
        private int mWidth;
        private int mHeight;
        private int mLeft;
        private int mTop;

        /// <summary>
        /// 初始化摄像头
        /// </summary>
        /// <param name="handle">控件的句柄</param>
        /// <param name="left">开始显示的左边距</param>
        /// <param name="top">开始显示的上边距</param>
        /// <param name="width">要显示的宽度</param>
        /// <param name="height">要显示的长度</param>
        public Pick(IntPtr handle, int left, int top, int width, int height)
        {
            mControlPtr = handle;
            mWidth = width;
            mHeight = height;
            mLeft = left;
            mTop = top;
        }

        [DllImport("avicap32.dll")]
        private static extern IntPtr capCreateCaptureWindowA(byte[] lpszWindowName, int dwStyle, int x, int y, int nWidth, int nHeight, IntPtr hWndParent, int nID);

        [DllImport("avicap32.dll")]
        private static extern int capGetVideoFormat(IntPtr hWnd, IntPtr psVideoFormat, int wSize);

        /// <summary>
        /// 该函数将指定的消息发送到一个或多个窗口
        /// </summary>
        /// <param name="hWnd">其窗口程序将接收消息的窗口的句柄。如果此参数为HWND_BROADCAST，则消息将被发送到系统中所有顶层窗口，包括无效或不可见的非自身拥有的窗口、被覆盖的窗口和弹出式窗口，但消息不被发送到子窗口。</param>
        /// <param name="wMsg">指定被发送的消息。</param>
        /// <param name="wParam">指定附加的消息特定信息。</param>
        /// <param name="lParam">指定附加的消息特定信息。</param>
        /// <returns>返回值指定消息处理的结果，依赖于所发送的消息</returns>
        //[DllImport("User32.dll", CharSet = CharSet.Auto)]
        //private static extern bool SendMessage(IntPtr hWnd, int wMsg, int wParam, long lParam);
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        private static extern bool SendMessage(IntPtr hWnd, int wMsg, IntPtr wParam, IntPtr lParam);

        int i = 0;
        /// <summary>
        /// 开始显示图像
        /// </summary>
        public bool Start()
        {
            if (bStat)
                return false;

            bStat = true;
            byte[] lpszName = new byte[100];

            hWndC = capCreateCaptureWindowA(lpszName, WS_CHILD | WS_VISIBLE, mLeft, mTop, mWidth, mHeight, mControlPtr, 0);

            bool bSendTemp = false;
            if (hWndC.ToInt32() != 0)
            {
                //bSendTemp &= SendMessage(hWndC, WM_CAP_SET_CALLBACK_VIDEOSTREAM, IntPtr.Zero, IntPtr.Zero);
                //bSendTemp &= SendMessage(hWndC, WM_CAP_SET_CALLBACK_ERROR, IntPtr.Zero, IntPtr.Zero);
                //bSendTemp &= SendMessage(hWndC, WM_CAP_SET_CALLBACK_STATUSA, IntPtr.Zero, IntPtr.Zero);

                //bSendTemp &= SendMessage(hWndC, WM_CAP_DRIVER_CONNECT, IntPtr.Zero, IntPtr.Zero);
                //while (bSendTemp == false)
                //{
                //    i++;
                //    bSendTemp = true;
                //    bSendTemp &= SendMessage(hWndC, WM_CAP_DRIVER_CONNECT, IntPtr.Zero, IntPtr.Zero);
                //    if (bSendTemp)
                //        continue;
                //}
                //bSendTemp &= SendMessage(hWndC, WM_CAP_SET_SCALE, new IntPtr(1), IntPtr.Zero);

                //bSendTemp &= SendMessage(hWndC, WM_CAP_SET_SCALE, new IntPtr(1), IntPtr.Zero);

                //bSendTemp &= SendMessage(hWndC, WM_CAP_SET_PREVIEWRATE, new IntPtr(66), IntPtr.Zero);
                //bSendTemp &= SendMessage(hWndC, WM_CAP_SET_OVERLAY, new IntPtr(1), IntPtr.Zero);
                //bSendTemp &= SendMessage(hWndC, WM_CAP_SET_PREVIEW, new IntPtr(1), IntPtr.Zero);

                while (bSendTemp == false)
                {
                    i++;
                    bSendTemp = true;
                    bSendTemp &= SendMessage(hWndC, WM_CAP_SET_CALLBACK_VIDEOSTREAM, IntPtr.Zero, IntPtr.Zero);
                    bSendTemp &= SendMessage(hWndC, WM_CAP_SET_CALLBACK_ERROR, IntPtr.Zero, IntPtr.Zero);
                    bSendTemp &= SendMessage(hWndC, WM_CAP_SET_CALLBACK_STATUSA, IntPtr.Zero, IntPtr.Zero);
                    bSendTemp &= SendMessage(hWndC, WM_CAP_DRIVER_CONNECT, IntPtr.Zero, IntPtr.Zero);

                    if (i > 10)
                    {
                        return false;
                    }

                    if (bSendTemp)
                    {
                        continue;
                    }
                }
                //bSendTemp &= SendMessage(hWndC, WM_CAP_SET_SCALE, new IntPtr(1), IntPtr.Zero);

                bSendTemp &= SendMessage(hWndC, WM_CAP_SET_SCALE, new IntPtr(1), IntPtr.Zero);

                bSendTemp &= SendMessage(hWndC, WM_CAP_SET_PREVIEWRATE, new IntPtr(66), IntPtr.Zero);
                bSendTemp &= SendMessage(hWndC, WM_CAP_SET_OVERLAY, new IntPtr(1), IntPtr.Zero);
                bSendTemp &= SendMessage(hWndC, WM_CAP_SET_PREVIEW, new IntPtr(1), IntPtr.Zero);
            }

            return bSendTemp;


        }

        /// <summary>
        /// 停止显示
        /// </summary>
        public void Stop()
        {
            SendMessage(hWndC, WM_CAP_DRIVER_DISCONNECT, IntPtr.Zero, IntPtr.Zero);
            bStat = false;
        }

        /// <summary>
        /// 抓图
        /// </summary>
        /// <param name="path">要保存bmp文件的路径</param>
        public void GrabImage(string path)
        {

            IntPtr hBmp = Marshal.StringToHGlobalAnsi(path);
            bool susccess = false;
            susccess=SendMessage(hWndC, WM_CAP_SAVEDIB, IntPtr.Zero, new IntPtr(hBmp.ToInt64()));

        }

        /// <summary>
        /// 录像
        /// </summary>
        /// <param name="path">要保存avi文件的路径</param>
        public void Kinescope(string path)
        {
            IntPtr hBmp = Marshal.StringToHGlobalAnsi(path);
            SendMessage(hWndC, WM_CAP_FILE_SET_CAPTURE_FILEA, IntPtr.Zero, new IntPtr(hBmp.ToInt64()));
            SendMessage(hWndC, WM_CAP_SEQUENCE, IntPtr.Zero, IntPtr.Zero);
        }

        /// <summary>
        /// 停止录像
        /// </summary>
        public void StopKinescope()
        {
            SendMessage(hWndC, WM_CAP_STOP, IntPtr.Zero, IntPtr.Zero);
        }

    }
}
