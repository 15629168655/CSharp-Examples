using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using AForge;
using AForge.Controls;
using AForge.Imaging;
using AForge.Video;
using AForge.Video.FFMPEG;
using AForge.Video.DirectShow;

namespace camera
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.windowsMediaPlayer1.URL = @"C:\Users\THINKPAD\Desktop\camera\camera\bin\Debug\FILE\20171111101011.MP4";
        
        }
    }
}
