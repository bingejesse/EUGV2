using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace IEC.UI
{
    class UserControlsManager
    {
        private static UserControlsManager instance;
        public static UserControlsManager GetInsance()
        {
            if (instance == null)
            {
                instance = new UserControlsManager();
            }
            return instance;
        }

        //public List<IMyUC> userControl = new List<IMyUC>();

        public Dictionary<string, IMyUC> userControl = new Dictionary<string, IMyUC>();

        public void Add(string key,IMyUC uc)
        {
            if (!userControl.ContainsKey(key))
            {
                this.userControl.Add(key,uc);
            }
        }

        public void Remove(string key, IMyUC uc)
        {
            if (userControl.ContainsKey(key))
            {
                this.userControl.Remove(key);
            }
        }


    }
}
