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
    public partial class Form2 : Form
    {
        public string str = "";
        public string str1 = "";
        public string str2 = "";
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "")
            {
                str = textBox1.Text;
                str1 = textBox2.Text;
                str2 = textBox3.Text;
                //this.label1.Text = "将 " + oid + "的值修改为：" + value;
                this.Close();
            }
            else
            {
                MessageBox.Show("输入有误！");
            }
        }
        public string Get()
        {
            return str;
        }
        public string Get1()
        {
            return str1;
        }
        public string Get2()
        {
            return str2;
        }

        private void pressEnter(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                button1_Click(sender, e);
            }
        }

    }
}
