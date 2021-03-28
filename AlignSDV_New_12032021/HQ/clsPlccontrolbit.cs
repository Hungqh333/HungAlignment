using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;

namespace HQ
{
    class clsPlccontrol
    {
        // OK send  bit 0, ng send bit 1
        public HTuple plc_device_HEB { get; set; }
        public HTuple plc_device_HE { get; set; }
        public HTuple plc_device_HEE { get; set; }
        public int plc_device_TT { get; set; }
        public int plc_device_XT { get; set; }
    }

    class clsVisioncontrol
    {
        // OK send  bit 0, ng send bit 1
        public HTuple vs_device_HE { get; set; }
        public HTuple vs_device_HEE { get; set; }
        public HTuple vs_device_TT { get; set; }
        public HTuple vs_device_XT { get; set; }
    }
}
