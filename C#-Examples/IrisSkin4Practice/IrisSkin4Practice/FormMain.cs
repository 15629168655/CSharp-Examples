using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace IrisSkin4Practice
{
    public partial class FormMain : Form
    {
        string[] skinFiles;

        public FormMain()
        {
            InitializeComponent();
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            skinFiles = Directory.GetFiles(System.Environment.CurrentDirectory + @"\skins");
            for (int i = 0; i < skinFiles.Length; i++)
            {
                string str = skinFiles[i];
                str = str.Replace(System.Environment.CurrentDirectory + @"\", "");
                str = str.Replace(".ssk", "");
                listBox1.Items.Add(str);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex > -1)
            {
                skinEngine1.SkinFile = skinFiles[listBox1.SelectedIndex];
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            { 
            
            }
        }
    }
}
