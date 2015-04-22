using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DareneExpressCabinetClient.Service;
using DareneExpressCabinetClient.Tools;
using DareneExpressCabinetClient.Service.Factory;
using Domain;

namespace DareneExpressCabinetClient.Resource
{
    public class BoxsManager:IDisposable
    {
        private DatabaseService databaseService;
        private BoxControlService boxControlService;

        /// <summary>
        /// 获得当前各个型号可用柜子数量
        /// </summary>
        /// <returns></returns>
        public int[] GetAvailableBoxCount()
        {
            #region 方法1
            //try
            //{
            //    int[] availableBoxCount = new int[5];
            //    IDictionaryEnumerator enu = BoxsDictionary.GetEnumerator();

            //    while (enu.MoveNext())
            //    {
            //        Box cab = (Box)(enu.Entry.Value);

            //        if (cab.IsIdle && !cab.CurrentState.Equals(Box.State.Fault))
            //        {
            //            availableBoxCount[Convert.ToInt32(cab.ThisSize)] += 1;
            //        }
            //    }

            //    return availableBoxCount;
            //}
            //catch (Exception e)
            //{
            //    CLog4net.LogError("GetAvailableBoxCount:" + e);
            //    return null;
            //}
            #endregion

            #region 方法2
            try
            {
                int[] availableBoxCount = new int[5];

                foreach (Box.Size item in Enum.GetValues(typeof(Box.Size)))
                {
                    availableBoxCount[Convert.ToInt32(item)] = databaseService.GetIdleBoxCount(item);
                }

                return availableBoxCount;
            }
            catch (Exception e)
            {
                CLog4net.LogError("GetAvailableBoxCount:" + e);
                return null;
            }
            #endregion
        }

        public void Load()
        {
            this.Initialize();
            this.boxControlService = ServicesFactory.GetInstance().GetBoxControlService();
            this.boxControlService.Init();

            CLog4net.LogInfo("BoxsManager is Loaded");
        }

        private static BoxsManager instance;
        /// <summary>
        /// 获得单例
        /// </summary>
        /// <returns></returns>
        public static BoxsManager GetInstance()
        {
            if (instance == null)
            {
                instance = new BoxsManager();
            }

            return instance;
        }


        public Dictionary<int, Box> BoxsDictionary = new Dictionary<int, Box>();

        /// <summary>
        /// 初始化操作
        /// </summary>
        private void Initialize()
        {
            /**
             * 从数据库表中建立柜子模型
             * */
            databaseService = Service.Factory.ServicesFactory.GetInstance().GetDatabaseService();
            List<Box> boxes = databaseService.GetBoxs();

            if (boxes != null)
            {
                foreach (Box d in boxes)
                {
                    this.Add(d);
                }
            }
        }

        /// <summary>
        /// 根据编号查找储物箱
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Box Find(int code)
        {
            Box obj = BoxsDictionary[code];
            return obj;
        }

        /// <summary>
        /// 根据size随机寻找一个空闲有用的柜子
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public Box Find(Box.Size size)
        {
            #region 方法1
            //try
            //{
            //    List<Box> boxs = new List<Box>();
            //    IDictionaryEnumerator enu = BoxsDictionary.GetEnumerator();

            //    while (enu.MoveNext())
            //    {
            //        Box cab = (Box)(enu.Entry.Value);

            //        if (cab.IsIdle && cab.ThisSize.Equals(size) && !cab.CurrentState.Equals(Box.State.Fault))
            //        {
            //            boxs.Add(cab);
            //        }
            //    }

            //    if (boxs.Count == 0)
            //    {
            //        CLog4net.LogError("根据size随机寻找一个空闲有用的柜子失败:"+size.ToString());
            //        return null;
            //    }
            //    int index = new Random().Next(boxs.Count);

            //    return this.BoxsDictionary[boxs[index].Code];
            //}
            //catch (Exception e)
            //{
            //    CLog4net.LogError("Box Find:" + e);
            //    return null;
            //}
            #endregion

            #region 方法2
            try
            {
                Box box = databaseService.GetIdleBoxBySize(size);
                return box;
            }
            catch (Exception e)
            {
                CLog4net.LogError("Box Find:" + e);
                return null;
            }
            #endregion

        }

        /// <summary>
        /// 添加可用柜子
        /// </summary>
        /// <param name="obj"></param>
        private void Add(Box obj)
        {
            if (this.BoxsDictionary.ContainsKey(obj.Code))
            {
                return;
            }

            this.BoxsDictionary.Add(obj.Code, obj);
        }

        /// <summary>
        /// 柜子总数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return BoxsDictionary.Count;
        }
        /// <summary>
        /// 停用柜子
        /// </summary>
        /// <param name="code"></param>
        public void DisableBox(int code)
        {
            Box box = Find(code);
            box.CurrentState = Box.State.Fault;
            databaseService.UpdateBox(box);
        }
        /// <summary>
        /// 启用柜子
        /// </summary>
        /// <param name="code"></param>
        public void EnableBox(int code)
        {
            Box box = Find(code);
            box.CurrentState = Box.State.Close;
            databaseService.UpdateBox(box);
        }

        /// <summary>
        /// 清空柜子
        /// </summary>
        /// <param name="code"></param>
        public void ClearBox(int code)
        {
            Box box = Find(code);
            if (box == null)
            {
                CLog4net.LogInfo("未找到箱子：" + code);
                return;
            }
            box.IsIdle = true;
            bool sucess = databaseService.UpdateBox(box);
            CLog4net.LogInfo("清空箱子：" + code + " " + sucess);
        }

        /// <summary>
        /// 使用箱子
        /// </summary>
        /// <param name="code"></param>
        public void UserBox(int code)
        {
            Box box = Find(code);
            if (box == null)
            {
                CLog4net.LogError("未找到箱子：" + code);
                return;
            }
            box.IsIdle = false;
            bool sucess = databaseService.UpdateBox(box);
            CLog4net.LogInfo("使用箱子：" + code + " " + sucess);
        }

        public void Dispose()
        {
            this.boxControlService.Dispose();
        }
    }
}
