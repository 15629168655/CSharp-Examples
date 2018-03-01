using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ThreadTest
{
    public partial class Form1 : Form
    {
        private TestClass testClass = null;
        private Thread thread = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            testClass = new TestClass();

            //在testclass对象的mainThread(委托)对象上搭载两个方法，在线程中调用mainThread对象时相当于调用了这两个方法。
            testClass.mainThread = new TestClass.testDelegate(refreshLabMessage1);
            testClass.mainThread += new TestClass.testDelegate(refreshLabMessage2);

            //创建一个无参数的线程,这个线程执行TestClass类中的testFunction方法。
            thread = new Thread(new ThreadStart(testClass.testFunction));
            //后台进程
            thread.IsBackground = true;
            //启动线程，启动之后线程才开始执行
            thread.Start();
        }

        private void refreshLabMessage1(long i)
        {
            //判断该方法是否被主线程调用，也就是创建labMessage1控件的线程，当控件的InvokeRequired属性为ture时，说明是被主线程以外的线程调用。如果不加判断，会造成异常
            if (this.label1.InvokeRequired)
            {
                testClass = new TestClass();
                testClass.mainThread = new TestClass.testDelegate(refreshLabMessage1);
                //this指窗体，在这调用窗体的Invoke方法，也就是用窗体的创建线程来执行mainThread对象委托的方法，再加上需要的参数(i)
                this.Invoke(testClass.mainThread, new object[] { i });
            }
            else
            {
                label1.Text = i.ToString();
            }
        }

        private void refreshLabMessage2(long i)
        {
            if (this.label2.InvokeRequired)
            {
                testClass = new TestClass();
                testClass.mainThread = new TestClass.testDelegate(refreshLabMessage2);
                this.Invoke(testClass.mainThread, new object[] { i });
            }
            else
            {
                label2.Text = i.ToString();
            }
        }

       
    }
}
