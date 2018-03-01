using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace xsgl.Control
{
    public partial class Start : Form
    {
        public Start()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (this.Opacity < 1)
            {
                this.Opacity += 0.01;
                progressBar1.Value = (int)(this.Opacity * 100);
            }
            else
            {
                timer1.Enabled = false;
                Dispose(false);
                (new MainWindow()).Show();
            }
        }
    }
}
