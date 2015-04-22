using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    public class Persion
    {
        private string id;
        private string name;
        private string description;
        private string remark;

        public virtual string Id { get { return id; } set { id = value; } }
        public virtual string Name { get { return name; } set { name = value; } }
        public virtual string Description { get { return description; } set { description = value; } }
        public virtual string Remark { get { return remark; } set { remark = value; } }
    }
}
