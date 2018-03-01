using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xsgl.DAL;
using xsgl.Model;

namespace xsgl.View
{
    public partial class ManageStudent : Form
    {
        private StudentDAL studentDAL = new StudentDAL();
        public ManageStudent()
        {
            InitializeComponent();
            getData();
        }
        private void getData() {
            IList<Student> list = studentDAL.FindStudents(textBox1.Text);
            this.dataGridView1.DataSource = list;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            getData();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            (new AddStudent()).ShowDialog();
            getData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            if (row >= 0)
            {
                string studNo = dataGridView1.Rows[row].Cells[0].Value.ToString();
                (new EditStudent(studNo)).ShowDialog();
                getData();
            }
            else {
                MessageBox.Show("请先选择学生！");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int row = dataGridView1.CurrentRow.Index;
            if (row >= 0)
            {
                string syudNo = dataGridView1.Rows[row].Cells[0].Value.ToString();
                if (studentDAL.DeleteStudent(syudNo) > 0)
                {
                    getData();
                }
                else {
                    MessageBox.Show("删除失败！");
                }
            }
            else
            {
                MessageBox.Show("请先选择学生！");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Dispose();
        }
    }
}
