using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DareneExpressCabinetClient.Service.Imple;
using Domain;

namespace DareneExpressCabinetClient.Service.Factory
{
    public class ServicesFactory
    {
        private static ServicesFactory instance;

        public static ServicesFactory GetInstance()
        {
            if (instance==null)
            {
                instance = new ServicesFactory();
                CLog4net.LogInfo("服务工厂启动");
            }

            return instance;
        }

        BoxControlService boxControlService;
        CameraService cameraService;
        VoiceService voiceService;
        DatabaseService databaseService;
        ServerService serverService;

        public BoxControlService GetBoxControlService()
        {
            //boxControlService = new BoxControlServiceImplByHttp();//等待实现
            boxControlService = new BoxControlServiceImplByCan();//等待实现
            return boxControlService;
        }


        public CourierService GetCourierService()
        {
            CourierService courierService = null;//等待实现
            return courierService;
        }

        public CameraService GetCameraService()
        {
            //cameraService = new CameraServiceImpl();//等待实现
            cameraService = new CameraServiceImplByAforge();
            return cameraService;
        }

        public VoiceService GetVoicService()
        {
            voiceService = new VoiceServiceImpl();
            //voiceService = new VoiceServiceImplByDotNetSpeech();
            return voiceService;
        }

        public DatabaseService GetDatabaseService()
        {
            databaseService = new DatabaseServiceImpl();
            return databaseService;
        }

        public ServerService GetServerService()
        {
            serverService = new ServerServiceImpl();
            return serverService;
        }
    }
}
