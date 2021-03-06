﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xsgl.DAL;

namespace xsgl.View
{
    public partial class Login : Form
    {
        private UserDAL userDAL = new UserDAL();
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (userDAL.validate(textBox1.Text, textBox2.Text))
            {
                this.Close();
            }
            else {
                MessageBox.Show("用户名或密码错误", "信息");
                textBox1.Focus();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
