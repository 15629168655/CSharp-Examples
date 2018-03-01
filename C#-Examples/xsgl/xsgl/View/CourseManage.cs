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
    public partial class CourseManage : Form
    {
        private CourseDAL courseDAL = new CourseDAL();
        private string mode;
        public CourseManage()
        {
            InitializeComponent();
            IList<Course> list = courseDAL.findCourses();
            bindingSource1.DataSource = list;
            bindingSource1.AllowNew = true;
            bindingSource1.Position = 0;
            bindingSource1.PositionChanged += new EventHandler(changePosition);
            dataGridView1.DataSource = bindingSource1;
            textBox1.DataBindings.Add("Text", bindingSource1, "CourseNo");
            textBox2.DataBindings.Add("Text", bindingSource1, "CourseName");
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;
            setPageButtonState();
        }
        private void changePosition(object sender, EventArgs e) {
            groupBox1.Text = (bindingSource1.Position + 1) + "of" + bindingSource1.Count;
        }
        private void setPageButtonState() {
            button7.Enabled = true;
            button8.Enabled = true;
            button9.Enabled = true;
            button10.Enabled = true;
            if (bindingSource1.Position == 0) {
                button7.Enabled = false;
                button8.Enabled = false;
            }
            if (bindingSource1.Position == bindingSource1.Count - 1) {
                button9.Enabled = false;
                button10.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.Enabled = false; button2.Enabled = false;
            button3.Enabled = true; button4.Enabled = true;
            button5.Enabled = false; button6.Enabled = false;
            button7.Enabled = false; button8.Enabled = false;
            button9.Enabled = false; button10.Enabled = false;
            textBox2.ReadOnly = false;
            bindingSource1.AddNew();
            textBox2.Focus();
            mode = "add";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button1.Enabled = false; button2.Enabled = false;
            button3.Enabled = true; button4.Enabled = true;
            button5.Enabled = false; button6.Enabled = false;
            button7.Enabled = false; button8.Enabled = false;
            button9.Enabled = false; button10.Enabled = false;
            textBox2.ReadOnly = false;
            textBox2.Focus();
            mode = "edit";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button1.Enabled = true; button2.Enabled = true;
            button3.Enabled = false; button4.Enabled = false;
            button5.Enabled = true; button6.Enabled = true;
            button7.Enabled = true; button8.Enabled = true;
            button9.Enabled = true; button10.Enabled = true;
            textBox2.ReadOnly = true;
            this.Validate();
            Course c = (Course)bindingSource1.Current;
            bindingSource1.EndEdit();
            if (mode == "add")
            {
                if (courseDAL.addCourse(c) == 0)
                {
                    MessageBox.Show("添加失败！");
                }
            }
            else {
                if (courseDAL.editCourse(c) == 0) {
                    MessageBox.Show("修改失败！");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button1.Enabled = true; button2.Enabled = true;
            button3.Enabled = false; button4.Enabled = false;
            button5.Enabled = true; button6.Enabled = true;
            button7.Enabled = true; button8.Enabled = true;
            button9.Enabled = true; button10.Enabled = true;
            textBox2.ReadOnly = true;
            bindingSource1.CancelEdit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (courseDAL.deleteCourse(((Course)bindingSource1.Current).CourseNo) > 0)
            {
                bindingSource1.RemoveCurrent();
            }
            else {
                MessageBox.Show("删除失败！");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveFirst();
            setPageButtonState();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            bindingSource1.MovePrevious();
            setPageButtonState();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveNext();
            setPageButtonState();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            bindingSource1.MoveLast();
            setPageButtonState();
        }
    }
}
