using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace snmpTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            this.label1.Text = "";
            this.label2.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string hostIP;
            int port = 161;
            string oid;

            Form3 form = new Form3();
            form.ShowDialog();
            hostIP = form.Get();
            oid = form.Get1();

            Snmp snmp = new Snmp();

            string get;
            get = snmp.getSnmp(oid, hostIP, port);


            this.label1.Text = "get到的值为：" + get;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string hostIP;
            int port = 161;
            string oid;
            string value;
            //.1.3.6.1.4.1.17409.1.3.1.1.0

            Form2 form2 = new Form2();
            form2.ShowDialog();
            hostIP = form2.Get();
            oid = form2.Get1();
            value = form2.Get2();


            Snmp snmp = new Snmp();

            snmp.setSnmp(oid, hostIP, port, value);

            this.label2.Text = "已将 " + oid + "的值修改为：" + value;
        }

    }
}
