using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DareneExpressCabinetClient.Tools
{
    interface IFilter
    {
        bool Filter(object obj);
    }
}
