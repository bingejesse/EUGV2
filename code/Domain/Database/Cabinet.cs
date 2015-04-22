using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    class Cabinet
    {
        public virtual int ID{get;set;}

        public virtual int Key { get; set; }

        public virtual bool Idle { get; set; }

        public virtual byte Size { get; set; }

        public virtual int localtionX { get; set; }

        public virtual int localtionY { get; set; }

        public virtual string remark { get; set; }
    }
}
