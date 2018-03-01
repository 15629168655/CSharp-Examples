using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Net;
using System.Threading;
using System.IO;
using System.Web;
using Newtonsoft.Json.Linq;

namespace SensorTest
{
    public partial class Form1 : Form
    {

        private DataHelper dataHelper = null;
        private Thread sensorThread = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataHelper = new DataHelper();
            dataHelper.mainThread = new DataHelper.UpdateDataDelegate(refreshData);
            sensorThread = new Thread(new ThreadStart(dataHelper.getData));
            sensorThread.IsBackground = true;
            sensorThread.Start();
        }

        private void refreshData(string url,string jsonStr) {
            if (this.txt_T.InvokeRequired || this.txt_H.InvokeRequired||this.textBox1.InvokeRequired)
            {
                DataHelper dh = new DataHelper();
                dh.mainThread = new DataHelper.UpdateDataDelegate(refreshData);
                this.Invoke(dh.mainThread, new object[] { url,jsonStr });
            }
            else {
                textBox1.AppendText("请求地址:" + url + ",数据:" + jsonStr+"\n");
                textBox1.AppendText("\n");
                if (url.EndsWith("gateway/itemGroup/register"))
                {
                    
                }
                else if (url.EndsWith("gateway/item/register"))
                {
                    
                }
                else if (url.EndsWith("gateway/realtime/upload"))
                {
                    JObject jobj = JObject.Parse(jsonStr);
                    DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Local));
                    DateTime dt = startTime.AddSeconds(long.Parse(jobj["collectionTime"].ToString()));
                    txt_CollectionTime.Text = dt.ToString();
                    JArray jar = JArray.Parse(jobj["th802"].ToString());
                    txt_T.Text = jar[0]["t"].ToString();
                    txt_H.Text = jar[0]["h"].ToString();
                }
                else if (url.EndsWith("gateway/itemGroup/heartbeat"))
                {

                }
                else if (url.EndsWith("gateway/item/updateStatus"))
                {

                }
                else if (url.EndsWith("gateway/history/upload"))
                {

                }
                
            }
        }
        
    }
}
