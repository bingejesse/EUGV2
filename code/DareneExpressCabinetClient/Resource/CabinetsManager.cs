using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace DareneExpressCabinetClient.Resource
{
    public class CabinetsManager
    {
        /// <summary>
        /// 0:S,1:M,2:L,3:XL,4:XLL
        /// </summary>
        private int[] availableCabCount = new int[5];
        /// <summary>
        /// 不同型号可用柜子数量
        /// </summary>
        public int[] AvailableCabCount
        {
            get { return availableCabCount; }
            set { availableCabCount = value; }
        }

        public CabinetsManager()
        {
            this.Initialize();
        }

        private static CabinetsManager instance;

        public static CabinetsManager GetInstance()
        {
            if (instance == null)
            {
                instance = new CabinetsManager();
            }

            return instance;
        }


        public Dictionary<int, Cabinet> CabinetsDictionary = new Dictionary<int, Cabinet>();

        /// <summary>
        /// 初始化操作
        /// </summary>
        private void Initialize()
        {
            /**
             * 从数据库表中建立柜子模型
             * */
        }

        /// <summary>
        /// 根据id查找柜子
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Cabinet Find(int id)
        {
            Cabinet obj = CabinetsDictionary[id];
            return obj;
        }

        /// <summary>
        /// 根据size寻找一个空闲有用的柜子
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public Cabinet Find(Cabinet.Size size)
        {
            IEnumerator enu = CabinetsDictionary.GetEnumerator();

            if (enu.MoveNext())
            {
                Cabinet cab = (Cabinet)enu.Current;

                if (cab.IsIdle && cab.ThisSize.Equals(size) && !cab.CurrentState.Equals(Cabinet.State.Fault))
                {
                    return cab;
                }
            }

            return null;
        }

        /// <summary>
        /// 添加柜子
        /// </summary>
        /// <param name="obj"></param>
        private void Add(Cabinet obj)
        {
            this.CabinetsDictionary.Add(obj.Id, obj);
            if (!obj.CurrentState.Equals(Cabinet.State.Fault))
            {
                this.availableCabCount[Convert.ToInt32(obj.ThisSize)] += 1;
            }
        }

        /// <summary>
        /// 柜子总数
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return CabinetsDictionary.Count;
        }
    }
}
