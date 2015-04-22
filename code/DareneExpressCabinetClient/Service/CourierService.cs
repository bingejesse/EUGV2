using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DareneExpressCabinetClient.Service
{
    public interface CourierService
    {
        bool IsRegister(int id,string password);
    }
}
