using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HalconDotNet;


namespace HQ
{
    class PLCBit
    {
        //Bit PLC
        public HTuple bitTriger { get; set; }
        public HTuple bitHaneye{ get; set; }
        public HTuple bitCalib { get; set; }
        public HTuple bitCompleteHandeye { get; set; }
        public HTuple bitCompleteCalib { get; set; }
        public HTuple bitComandGo { get; set; }
        public HTuple bitCompleteAlign { get; set; }

        //Device PLC
        public HTuple deviceTriger { get; set; }
        public HTuple deviceHaneye { get; set; }
        public HTuple deviceCalib { get; set; }
        public HTuple deviceComplete { get; set; }
        public HTuple deviceComandGo { get; set; }
        public HTuple deviceSendX { get; set; }
        public HTuple deviceSendY { get; set; }
        public HTuple deviceSendTheta { get; set; }
    }
}
