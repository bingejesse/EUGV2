using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DareneExpressCabinetClient.Tools
{
    public class TimeTest
    {
        private DateTime beginTime;

        public void BeginTest()
        {
            this.beginTime = System.DateTime.Now;
        }

        public double SpanTime()
        {
            DateTime endTime = System.DateTime.Now;
            TimeSpan span = endTime - this.beginTime;
            return span.TotalMilliseconds;
        }
    }
}
