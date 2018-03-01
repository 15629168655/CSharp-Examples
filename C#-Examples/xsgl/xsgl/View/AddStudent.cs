using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xsgl.Model;
using xsgl.DAL;
using System.IO;

namespace xsgl.View
{
    public partial class AddStudent : Form
    {
        private StudentDAL studentDAL = new StudentDAL();
        public AddStudent()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog(); //打开文件对话框
            openFileDialog1.InitialDirectory = "c:\\"; //初始路径
            openFileDialog1.Filter = "jpg files(*.jpg)|*.jpg";
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {
                pictureBox1.Tag = openFileDialog1.FileName;
                pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);

            }
            else {
                pictureBox1.Tag = null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.StudNo = textBox1.Text;
            student.StudName = textBox2.Text;
            student.StudSex = radioButton1.Checked?'男':'女';
            student.StudBirthDate = dateTimePicker1.Value;
            student.StudMajor = comboBox1.Text;
            student.StudIsMember = checkBox1.Checked;
            if (pictureBox1.Image != null) {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms,System.Drawing.Imaging.ImageFormat.Jpeg);
                student.StudPic = ms.GetBuffer();
                ms.Close();
            }
            if (studentDAL.AddStudent(student) >= 0)
            {
                MessageBox.Show("添加成功！");
                Dispose();
            }
            else {
                MessageBox.Show("添加失败！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
