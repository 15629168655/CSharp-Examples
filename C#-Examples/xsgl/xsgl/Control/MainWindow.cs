using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using xsgl.View;

namespace xsgl.Control
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            View.Login login = new View.Login();
            login.ShowDialog(this);
        }

        private void 学生管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ManageStudent manageStudent = new ManageStudent();
            manageStudent.ShowDialog();
        }

        private void 课程管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CourseManage courseManage = new CourseManage();
            courseManage.ShowDialog();
        }

        private void 成绩管理ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScoreManage scoreManage = new ScoreManage();
            scoreManage.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            ManageStudent manageStudent = new ManageStudent();
            manageStudent.ShowDialog();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            CourseManage courseManage = new CourseManage();
            courseManage.ShowDialog();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            ScoreManage scoreManage = new ScoreManage();
            scoreManage.ShowDialog();
        }

        private void 退出XToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
