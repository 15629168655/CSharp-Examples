using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SnmpSharpNet;
using System.Net;

namespace SwitchTest
{
    public partial class Form1 : Form
    {
        private string host = "192.168.100.192";
        private int port = 161;
        public Form1()
        {
            InitializeComponent();
        }

        //SNMP get方法
        private string getSnmp(string oid, string host, int port)
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
            param.Version = SnmpVersion.Ver2;
            IpAddress agent = new IpAddress(hostIP);

            //构建目标            
            UdpTarget target = new UdpTarget((IPAddress)agent, port, 2000, 1);

            Pdu pdu = new Pdu(PduType.Get);
            pdu.VbList.Add(Oid);

            //发送snmp请求
            SnmpV2Packet result = (SnmpV2Packet)target.Request(pdu, param);

            if (result != null)
            {
                // ErrorStatus other then 0 is an error returned by   
                // the Agent - see SnmpConstants for error definitions 
                if (result.Pdu.ErrorStatus != 0)
                {
                    // agent reported an error with the request  
                    this.textBox1.Text += string.Format("Error in SNMP reply. Error {0} index {1} \r\n", result.Pdu.ErrorStatus, result.Pdu.ErrorIndex);
                }
                else
                {
                    // Reply variables are returned in the same order as they were added  
                    //  to the VbList
                    //result.Pdu.VbList[0].Oid.ToString()
                    //SnmpConstants.GetTypeName(result.Pdu.VbList[0].Value.Type)
                    //result.Pdu.VbList[0].Value.ToString())
                    get = result.Pdu.VbList[0].Value.ToString();
                }
                target.Dispose();
            }
            return get;

        }

        //SNMP set方法
        private void setSnmp(string oid, string host, int port, string value)
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
            param.Version = SnmpVersion.Ver2;
            IpAddress agent = new IpAddress(hostIP);

            //构建目标            
            UdpTarget target = new UdpTarget((IPAddress)agent, port, 2000, 1);

            Pdu pdu = new Pdu(PduType.Set);
            pdu.VbList.Add(new SnmpSharpNet.Oid(Oid), new OctetString(Value));

            //发送snmp请求
            SnmpV2Packet result = (SnmpV2Packet)target.Request(pdu, param);

        }

        private void Form1_Load(object sender, EventArgs e)
        {      

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (getSnmp(Oid.switch1PDU1, host, port) == "ON")
            {
                setSnmp(Oid.switch1PDU1, host, port, "OFF");
            }
            else {
                setSnmp(Oid.switch1PDU1, host, port, "ON");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (getSnmp(Oid.switch2PDU1, host, port) == "ON")
            {
                setSnmp(Oid.switch2PDU1, host, port, "OFF");
            }
            else
            {
                setSnmp(Oid.switch2PDU1, host, port, "ON");
            }
        }        

        private void button3_Click(object sender, EventArgs e)
        {
            if (getSnmp(Oid.switch3PDU1, host, port) == "ON")
            {
                setSnmp(Oid.switch3PDU1, host, port, "OFF");
            }
            else
            {
                setSnmp(Oid.switch3PDU1, host, port, "ON");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (getSnmp(Oid.switch4PDU1, host, port) == "ON")
            {
                setSnmp(Oid.switch4PDU1, host, port, "OFF");
            }
            else
            {
                setSnmp(Oid.switch4PDU1, host, port, "ON");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (getSnmp(Oid.switch5PDU1, host, port) == "ON")
            {
                setSnmp(Oid.switch5PDU1, host, port, "OFF");
            }
            else
            {
                setSnmp(Oid.switch5PDU1, host, port, "ON");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (getSnmp(Oid.switch6PDU1, host, port) == "ON")
            {
                setSnmp(Oid.switch6PDU1, host, port, "OFF");
            }
            else
            {
                setSnmp(Oid.switch6PDU1, host, port, "ON");
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (getSnmp(Oid.switch7PDU1, host, port) == "ON")
            {
                setSnmp(Oid.switch7PDU1, host, port, "OFF");
            }
            else
            {
                setSnmp(Oid.switch7PDU1, host, port, "ON");
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (getSnmp(Oid.switch8PDU1, host, port) == "ON")
            {
                setSnmp(Oid.switch8PDU1, host, port, "OFF");
            }
            else
            {
                setSnmp(Oid.switch8PDU1, host, port, "ON");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (getSnmp(Oid.switch9PDU1, host, port) == "ON")
            {
                setSnmp(Oid.switch9PDU1, host, port, "OFF");
            }
            else
            {
                setSnmp(Oid.switch9PDU1, host, port, "ON");
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (getSnmp(Oid.switch10PDU1, host, port) == "ON")
            {
                setSnmp(Oid.switch10PDU1, host, port, "OFF");
            }
            else
            {
                setSnmp(Oid.switch10PDU1, host, port, "ON");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if (getSnmp(Oid.switch11PDU1, host, port) == "ON")
            {
                setSnmp(Oid.switch11PDU1, host, port, "OFF");
            }
            else
            {
                setSnmp(Oid.switch11PDU1, host, port, "ON");
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            if (getSnmp(Oid.switch12PDU1, host, port) == "ON")
            {
                setSnmp(Oid.switch12PDU1, host, port, "OFF");
            }
            else
            {
                setSnmp(Oid.switch12PDU1, host, port, "ON");
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            textBox1.AppendText("设备名称：" + getSnmp(Oid.deviceNamePDU1, host, port) + "\n");
            textBox1.AppendText("插座数量：" + getSnmp(Oid.outletNumberPDU1, host, port) + "\n");
            textBox1.AppendText("L1电流：" + (Double.Parse(getSnmp(Oid.currentL1, host, port)) / 10).ToString("0.0") + " A\n");
            textBox1.AppendText("L1电压：" + getSnmp(Oid.voltageL1, host, port) + " V\n");
            textBox1.AppendText("L1功率：" + getSnmp(Oid.powerL1, host, port) + " W\n");
            textBox1.AppendText("L1功率因素：" + (Double.Parse(getSnmp(Oid.pfL1, host, port))/100).ToString("0.00") + "\n");
            textBox1.AppendText("L1电能：" + Double.Parse(getSnmp(Oid.energyL1, host, port))/10 + " kwh\n");
            textBox1.AppendText("1号插位名称：" + getSnmp(Oid.name1PDU1, host, port) + "\n");
            textBox1.AppendText("1号插位电流：" + (Double.Parse(getSnmp(Oid.current1, host, port))/10).ToString("0.0") + " A\n");
            textBox1.AppendText("1号插位电能：" + (StringUtils.strToDouble(getSnmp(Oid.energy1, host, port))/10).ToString("0.0") + " kwh\n");
            textBox1.AppendText("3号插位名称：" + StringUtils.UnHex(getSnmp(Oid.name3PDU1, host, port),"utf-8") + "\n");
        }
    }
}
