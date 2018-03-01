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
    public partial class EditStudent : Form
    {
        private StudentDAL studentDAL = new StudentDAL();
        public EditStudent(string studNo)
        {
            InitializeComponent();
            Student student = studentDAL.FindStudent(studNo);
            textBox1.Text = student.StudNo;
            textBox2.Text = student.StudName;
            radioButton1.Checked = student.StudSex == '男' ? true : false;
            dateTimePicker1.Value = student.StudBirthDate;
            comboBox1.Text = student.StudMajor;
            checkBox1.Checked = student.StudIsMember;
            if (student.StudPic != null) {
                MemoryStream ms = new MemoryStream(student.StudPic);
                pictureBox1.Image = Image.FromStream(ms);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student student = new Student();
            student.StudNo = textBox1.Text;
            student.StudName = textBox2.Text;
            student.StudSex = radioButton1.Checked ? '男' : '女';
            student.StudBirthDate = dateTimePicker1.Value;
            student.StudMajor = comboBox1.Text;
            student.StudIsMember = checkBox1.Checked;
            if (pictureBox1.Image != null)
            {
                MemoryStream ms = new MemoryStream();
                pictureBox1.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                student.StudPic = ms.GetBuffer();
                ms.Close();
            }
            if (studentDAL.EditStudent(student) >= 0)
            {
                MessageBox.Show("修改成功！");
                Dispose();
            }
            else {
                MessageBox.Show("修改失败！");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
