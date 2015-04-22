using System.Runtime.InteropServices;
using System;
using DareneExpressCabinetClient.Resource;
using DareneExpressCabinetClient.Service.Factory;
using Domain;

namespace DareneExpressCabinetClient.Tools
{
    public class VGuangQR : IDisposable
    {
        //设备状态,DEVICE_VALID(设备有效),DEVICE_INVALID(设备无效)
        public const int DEVICE_VALID = 1;
        public const int DEVICE_INVALID = 2;

        //定义委托，扫码成功时的回调函数
        [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
        public delegate int DecodeCallBack(IntPtr str, int length);
        //定义委托，设备状态变化时的回调函数
        [UnmanagedFunctionPointerAttribute(CallingConvention.StdCall)]
        public delegate void DeviceStatusCallBack(int istatus);

        public static DecodeCallBack decodeCall;
        public static DeviceStatusCallBack deviceStatusCall;

        #region 引用dll_vguang.dll

        private const string dllName = "dll_vguang.dll";

        //打开设备
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void openDevice();
        //关闭设备
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void closeDevice();
        //设置QR引擎状态，true时qr引擎开启；false时qr引擎关闭
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void setQRable(bool bqr);
        //设置DM引擎状态，true时dm引擎开启；false时dm引擎关闭
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void setDMable(bool bdm);
        //设置一维码引擎状态，true时一维码引擎开启；false时一维码引擎关闭
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void setBarcode(bool bbarcode);
        //设置自动休眠状态，true时自动休眠开启；false时自动休眠关闭
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void setAI(bool bai);
        //设置自动休眠灵敏度，1~64，缺省20
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void setAISensitivity(int aiLimit);
        //设置自动休眠开启时关灯时间，单位秒
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void setAIResponseTime(int responseTime);
        //设置解码间隔时间，单位毫秒
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void setDeodeIntervalTime(int intervalTime);
        //设置扬声器状态，true时扬声器(缺省声音)开启；false时扬声器(缺省声音)关闭
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void setBeepable(bool bbeep);
        //扬声器声音，times取值为1,2,3
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void beep(int times);
        //开灯
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void lightOn();
        //关灯
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void lightOff();
        //设置扫码成功时回调
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void setDecodeCallBack(DecodeCallBack _decodeCall);
        //设置设备状态变化时回调
        [DllImport(dllName, CallingConvention = CallingConvention.StdCall)]
        public static extern void setDeviceStatusCallBack(DeviceStatusCallBack _deviceStatusCall);
        #endregion

        public void Load()
        {
            try
            {
                //打开设备
                openDevice();
                //应用设置
                applySetting();
            }
            catch (Exception e)
            {
                CLog4net.LogError(e);
            }
        }

        private void applySetting()
        {
            //设置QR状态
            setQRable(true);
            //设置DM状态
            setDMable(false);
            //设置Bar状态
            setBarcode(false);

            //设置解码间隔时间，单位毫秒
            setDeodeIntervalTime(1000);

            //设置自动休眠状态
            setAI(false);
            //设置自动休眠灵敏度
            setAISensitivity(20);
            // 设置自动休眠响应时间，单位秒
            setAIResponseTime(10);

            //设置扬声器状态
            setBeepable(true);
        }

        public void OpenDevice()
        {
            openDevice();
        }

        public void Dispose()
        {
            //关闭设备
            closeDevice();
        }
    }
}
