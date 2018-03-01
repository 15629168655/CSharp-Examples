using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SwitchTest
{
    class Oid
    {
        #region baseinfo1
        public static string deviceNamePDU1 = ".1.3.6.1.4.1.42578.1.1.1.0";  //设备名称 get/set

        public static string outletNumberPDU1 = ".1.3.6.1.4.1.42578.1.1.2.0";  //插座数量 get

        public static string temperature1PDU1 = ".1.3.6.1.4.1.42578.1.1.3.0";  //get

        public static string humidity1PDU1 = ".1.3.6.1.4.1.42578.1.1.4.0";  //get

        public static string door1 = ".1.3.6.1.4.1.42578.10.1.5.0";  //get

        public static string door2 = ".1.3.6.1.4.1.42578.10.1.6.0";  //get

        public static string water = ".1.3.6.1.4.1.42578.1.1.7.0";  //get

        public static string smoke = ".1.3.6.1.4.1.42578.1.1.8.0";  //get
        #endregion

        #region inputPDU1
        public static string currentL1 = ".1.3.6.1.4.1.42578.1.2.1.0";  //L1电流 get

        public static string currentL2 = ".1.3.6.1.4.1.42578.1.2.2.0";

        public static string currentL3 = ".1.3.6.1.4.1.42578.1.2.3.0";

        public static string voltageL1 = ".1.3.6.1.4.1.42578.1.2.4.0";  //L1电压 get

        public static string voltageL2 = ".1.3.6.1.4.1.42578.1.2.5.0";

        public static string voltageL3 = ".1.3.6.1.4.1.42578.1.2.6.0";

        public static string pfL1 = ".1.3.6.1.4.1.42578.1.2.7.0";  //L1功率因素 get

        public static string pfL2 = ".1.3.6.1.4.1.42578.1.2.8.0";

        public static string pfL3 = ".1.3.6.1.4.1.42578.1.2.9.0";

        public static string powerL1 = ".1.3.6.1.4.1.42578.1.2.10.0";  //L1功率 get

        public static string powerL2 = ".1.3.6.1.4.1.42578.1.2.11.0";

        public static string powerL3 = ".1.3.6.1.4.1.42578.1.2.12.0";

        public static string energyL1 = ".1.3.6.1.4.1.42578.1.2.13.0";  //L1电能 get

        public static string energyL2 = ".1.3.6.1.4.1.42578.1.2.14.0";

        public static string energyL3 = ".1.3.6.1.4.1.42578.1.2.15.0"; 
        #endregion

        #region outletinfo1
        public static string name1PDU1 = ".1.3.6.1.4.1.42578.1.3.1.0";  //1号插位名称 get/set

        public static string name2PDU1 = ".1.3.6.1.4.1.42578.1.3.2.0";

        public static string name3PDU1 = ".1.3.6.1.4.1.42578.1.3.3.0";

        public static string name4PDU1 = ".1.3.6.1.4.1.42578.1.3.4.0";

        public static string name5PDU1 = ".1.3.6.1.4.1.42578.1.3.5.0";

        public static string name6PDU1 = ".1.3.6.1.4.1.42578.1.3.6.0";

        public static string name7PDU1 = ".1.3.6.1.4.1.42578.1.3.7.0";

        public static string name8PDU1 = ".1.3.6.1.4.1.42578.1.3.8.0";

        public static string name9PDU1 = ".1.3.6.1.4.1.42578.1.3.9.0";

        public static string name10PDU1 = ".1.3.6.1.4.1.42578.1.3.10.0";

        public static string name11PDU1 = ".1.3.6.1.4.1.42578.1.3.11.0";

        public static string name12PDU1 = ".1.3.6.1.4.1.42578.1.3.12.0"; 
        #endregion

        #region currentPDU1
        public static string current1 = ".1.3.6.1.4.1.42578.1.4.1.0";  //1号插位电流 get

        public static string current2 = ".1.3.6.1.4.1.42578.1.4.2.0";

        public static string current3 = ".1.3.6.1.4.1.42578.1.4.3.0";

        public static string current4 = ".1.3.6.1.4.1.42578.1.4.4.0";

        public static string current5 = ".1.3.6.1.4.1.42578.1.4.5.0";

        public static string current6 = ".1.3.6.1.4.1.42578.1.4.6.0";

        public static string current7 = ".1.3.6.1.4.1.42578.1.4.7.0";

        public static string current8 = ".1.3.6.1.4.1.42578.1.4.8.0";

        public static string current9 = ".1.3.6.1.4.1.42578.1.4.9.0";

        public static string current10 = ".1.3.6.1.4.1.42578.1.4.10.0";

        public static string current11 = ".1.3.6.1.4.1.42578.1.4.11.0";

        public static string current12 = ".1.3.6.1.4.1.42578.1.4.12.0"; 
        #endregion

        #region energyPDU1
        public static string energy1 = ".1.3.6.1.4.1.42578.1.5.1.0";  //1号插位电能 get

        public static string energy2 = ".1.3.6.1.4.1.42578.1.5.2.0";

        public static string energy3 = ".1.3.6.1.4.1.42578.1.5.3.0";

        public static string energy4 = ".1.3.6.1.4.1.42578.1.5.4.0";

        public static string energy5 = ".1.3.6.1.4.1.42578.1.5.5.0";

        public static string energy6 = ".1.3.6.1.4.1.42578.1.5.6.0";

        public static string energy7 = ".1.3.6.1.4.1.42578.1.5.7.0";

        public static string energy8 = ".1.3.6.1.4.1.42578.1.5.8.0";

        public static string energy9 = ".1.3.6.1.4.1.42578.1.5.9.0";

        public static string energy10 = ".1.3.6.1.4.1.42578.1.5.10.0";

        public static string energy11 = ".1.3.6.1.4.1.42578.1.5.11.0";

        public static string energy12 = ".1.3.6.1.4.1.42578.1.5.12.0"; 
        #endregion

        #region switchPDU1
        public static string switch1PDU1 = ".1.3.6.1.4.1.42578.1.6.1.0";  //1号插位开关 get/set  

        public static string switch2PDU1 = ".1.3.6.1.4.1.42578.1.6.2.0";

        public static string switch3PDU1 = ".1.3.6.1.4.1.42578.1.6.3.0";

        public static string switch4PDU1 = ".1.3.6.1.4.1.42578.1.6.4.0";

        public static string switch5PDU1 = ".1.3.6.1.4.1.42578.1.6.5.0";

        public static string switch6PDU1 = ".1.3.6.1.4.1.42578.1.6.6.0";

        public static string switch7PDU1 = ".1.3.6.1.4.1.42578.1.6.7.0";

        public static string switch8PDU1 = ".1.3.6.1.4.1.42578.1.6.8.0";

        public static string switch9PDU1 = ".1.3.6.1.4.1.42578.1.6.9.0";

        public static string switch10PDU1 = ".1.3.6.1.4.1.42578.1.6.10.0";

        public static string switch11PDU1 = ".1.3.6.1.4.1.42578.1.6.11.0";

        public static string switch12PDU1 = ".1.3.6.1.4.1.42578.1.6.12.0"; 
        #endregion
    }
}
