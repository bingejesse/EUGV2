using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain
{
    class Customer
    {
        public virtual int ID { get; set; }

        public virtual string Address { get; set; }

        public virtual string Name { get; set; }

        override public string ToString()
        {
            return string.Format("Customer Name: {0}, Address: {1}", this.Name, this.Address);
        }
    }
}
