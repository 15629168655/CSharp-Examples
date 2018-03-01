using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using SnmpSharpNet;
using System.Security.Cryptography;
using System.Net;
using System.Net.Sockets;

namespace snmpTest
{
    class Snmp
    { 
        public Snmp(){}
        public string getSnmp(string oid, string host, int port )
        {
            string hostIP;
            int Port;
            string Oid;
            string get = "";

            Oid = oid;
            hostIP = host;
            Port = port;

            //共同体类型
            OctetString community = new OctetString("public");
            AgentParameters param = new AgentParameters(community);      
            
            //设置snmp版本             
            param.Version = (int)SnmpVersion.Ver1;                       
            IpAddress agent = new IpAddress(hostIP);            
            
            //构建目标            
            UdpTarget target = new UdpTarget((IPAddress)agent, port, 2000, 1);
 
            
                      
            Pdu pdu = new Pdu(PduType.Get);
            pdu.VbList.Add(Oid);

            //发送snmp请求
            SnmpV1Packet result = (SnmpV1Packet)target.Request(pdu, param);

            get = result.Pdu.VbList[0].Value.ToString();

            return get;

            
        }

         public void setSnmp(string oid, string host, int port, string value)
        {
            string hostIP;
            int Port;
            string Oid;
            string Value;

            Oid = oid;
            hostIP = host;
            Port = port;
            Value = value;

            //共同体类型
            OctetString community = new OctetString("private");
            AgentParameters param = new AgentParameters(community);      
            
            //设置snmp版本
            param.Version = (int)SnmpVersion.Ver1;                       
            IpAddress agent = new IpAddress(hostIP);            
            
            //构建目标            
            UdpTarget target = new UdpTarget((IPAddress)agent, port, 2000, 1);
 
            
                      
            Pdu pdu = new Pdu(PduType.Set);
            pdu.VbList.Add(new SnmpSharpNet.Oid(Oid), new OctetString(Value));

            //发送snmp请求
            SnmpV1Packet result = (SnmpV1Packet)target.Request(pdu, param);

        }
    }
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
