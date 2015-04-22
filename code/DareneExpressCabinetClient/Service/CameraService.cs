using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DareneExpressCabinetClient.Service
{
    public interface CameraService
    {
        bool Open();

        bool TakePicture();

        void Close();
    }
}
