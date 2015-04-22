using System.Collections.Generic;
using System.Collections;

namespace DareneExpressCabinetClient.Tools
{
    class DataFilter
    {
        private List<IFilter> filter = new List<IFilter>();

        public void AddFilter(IFilter item)
        {
            if (!this.filter.Contains(item))
            {
                this.filter.Add(item);
            }
        }

        public void DelFilter(IFilter item)
        {
            if (this.filter.Contains(item))
            {
                this.filter.Remove(item);
            }
        }

        /// <summary>
        /// 返回为true表示数据已经被截取过滤
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public bool DoJob(object obj)
        {
            bool isFilter = false;
            IEnumerator em = this.filter.GetEnumerator();

            while (em.MoveNext())
            {
                IFilter item = (IFilter)em.Current;
                isFilter = item.Filter(obj);
                if (isFilter)
                {
                    break;
                }
            }

            return isFilter;
        }
    }
}
