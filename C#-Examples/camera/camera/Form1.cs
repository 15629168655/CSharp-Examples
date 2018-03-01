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
using System.IO;
using System.Drawing.Imaging;
using camera.Util;

namespace camera
{
    public partial class Form1 : Form
    {
        private string dirc = System.AppDomain.CurrentDomain.BaseDirectory + "FILE"; //文件保存根目录
        private string videoName = null; //视频名称
        private delegate void MyDelegateUI(); //多线程问题
        private FilterInfoCollection videoDevices; //摄像头设备  
        private VideoCaptureDevice videoSource; //视频的来源选择  
        private VideoFileWriter videoWriter = null; //写入到视频
        private bool is_record_video = false; //是否开始录像
        private System.Diagnostics.Stopwatch timer = null;

        System.Timers.Timer timer_count;
        int width = 640;    //录制视频的宽度
        int height = 480;   //录制视频的高度
        int fps = 30;        //正常速率，fps越大速率越快，相当于快进

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //应用皮肤
            skinEngine1.SkinFile = System.Environment.CurrentDirectory + @"\skins" + @"\MSN.ssk";
            //初始化按钮状态
            this.btnClose.Enabled = false;
            this.btnPhotograph.Enabled = false;
            this.btnStarVideo.Enabled = false;
            this.btnPuaseVideo.Enabled = false;
            this.btnStopVideo.Enabled = false;
            if (!Directory.Exists(dirc)) {
                Directory.CreateDirectory(dirc);
            }
            try
            {
                // 枚举所有视频输入设备
                videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                if (videoDevices.Count == 0) 
                    throw new ApplicationException();
                foreach (FilterInfo device in videoDevices)
                {
                    int i = 1;
                    comboBox1.Items.Add(device.Name);
                    textBox1.AppendText("摄像头" + i + "初始化完毕..." + "\n");
                    textBox1.ScrollToCaret();
                    i++;
                }
                comboBox1.SelectedIndex = 0;
            }
            catch (ApplicationException)
            {
                comboBox1.Items.Add("No local capture devices!");
                videoDevices = null;
            }
            //秒表
            timer_count = new System.Timers.Timer();   //实例化Timer类，设置间隔时间为1000毫秒；
            timer_count.Elapsed += new System.Timers.ElapsedEventHandler(tick_count);   //到达时间的时候执行事件；
            timer_count.AutoReset = true;   //设置是执行一次（false）还是一直执行(true)；
            timer_count.Interval = 500; //每半秒钟刷新时间
        }

        //计时器响应函数
        public void tick_count(object source, System.Timers.ElapsedEventArgs e)
        {
            int hour = timer.Elapsed.Hours;
            int min = timer.Elapsed.Minutes;
            int sec = timer.Elapsed.Seconds;
            String tick = hour.ToString() + "：" + min.ToString() + "：" + sec.ToString();
            MyDelegateUI d = delegate
            {
                this.labelTime.Text = tick;
            };
            this.labelTime.Invoke(d);
        }


        private void CameraConn()
        {
            /* 视频输入设置界面
            VideoCaptureDeviceForm videoSettings = new VideoCaptureDeviceForm();
            var result = videoSettings.ShowDialog(this);
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            // create video source
            videoSource = videoSettings.VideoDevice;
             */
            videoSource = new VideoCaptureDevice(videoDevices[comboBox1.SelectedIndex].MonikerString);
            //videoSource.DesiredFrameSize = new System.Drawing.Size(320, 240);
            //videoSource.DesiredFrameRate = 1;
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoSource.Start();
            videoSourcePlayer1.VideoSource = videoSource;
            videoSourcePlayer1.Start();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            CameraConn();
            this.btnClose.Enabled = true;
            this.btnPhotograph.Enabled = true;
            this.btnStarVideo.Enabled = true;
            this.btnConnect.Enabled = false;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            videoSourcePlayer1.SignalToStop();
            videoSourcePlayer1.WaitForStop();
            this.btnClose.Enabled = false;
            this.btnPhotograph.Enabled = false;
            this.btnStarVideo.Enabled = false;
            this.btnPuaseVideo.Enabled = false;
            this.btnStopVideo.Enabled = false;
            this.btnConnect.Enabled = true;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            btnClose_Click(null, null);
        }

        private void btnPhotograph_Click(object sender, EventArgs e)
        {
            if (videoSource.IsRunning && videoSourcePlayer1.IsRunning)
            {
                Bitmap bitmap = videoSourcePlayer1.GetCurrentVideoFrame();
                string imgUrl = dirc + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg";//照片路径
                bitmap.Save(imgUrl);
                textBox1.AppendText("拍照成功！保存路径" + imgUrl + "\n");
                textBox1.ScrollToCaret();
            }
            else {
                MessageBox.Show("请先连接摄像头！");
            }
        }

        private void video_NewFrame(object sender, NewFrameEventArgs e) {
            Bitmap bitmap = e.Frame; 
            if (is_record_video) {  //录像
                videoWriter.WriteVideoFrame(bitmap,timer.Elapsed);
            }
        }

        //退出按钮
        private void btnExit_Click(object sender, EventArgs e)
        {
            //拍照完成后关摄像头并刷新,同时关窗体
            if (videoSourcePlayer1 != null && videoSourcePlayer1.IsRunning) {
                videoSourcePlayer1.SignalToStop();
                videoSourcePlayer1.WaitForStop();
            }
            this.Close();
        }

        private void btnStarVideo_Click(object sender, EventArgs e)
        {

            try
            {
                //创建一个视频文件ss
                videoName = dirc + "\\" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".MP4";//视频路径
                videoWriter = new VideoFileWriter();
                timer_count.Enabled = true;//是否执行System.Timers.Timer.Elapsed事件；
                this.is_record_video = true;
                this.labelTime.Visible = true;
                textBox1.AppendText("录制中...\n");
                if (videoSourcePlayer1.IsRunning && videoSource.IsRunning)
                {
                    videoWriter.Open(videoName, width, height, fps, VideoCodec.MPEG4);
                    //start a timer to sync the video timeline
                    timer = System.Diagnostics.Stopwatch.StartNew();
                    this.labelTime.Text = 0 + "：" + 0 + "：" + 0;
                    this.btnStarVideo.Enabled = false;
                    this.btnPuaseVideo.Enabled = true;
                    this.btnStopVideo.Enabled = true;
                }
                else
                {
                    MessageBox.Show("没有视频源输入，无法录制视频。", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                
                MessageBox.Show("摄像头异常：" + ex.Message);
            }
        }

        private void btnPuaseVideo_Click(object sender, EventArgs e)
        {
            if (this.btnPuaseVideo.Text.Trim() == "暂停录像")
            {
                is_record_video = false;
                this.btnPuaseVideo.Text = "恢复录像";
                timer.Stop();
                timer_count.Enabled = false;    //暂停计时
                return;
            }
            if (this.btnPuaseVideo.Text.Trim() == "恢复录像")
            {
                is_record_video = true;
                this.btnPuaseVideo.Text = "暂停录像";
                timer.Start();
                timer_count.Enabled = true;     //恢复计时
            }
        }

        private void btnStopVideo_Click(object sender, EventArgs e)
        {
            this.is_record_video = false;
            this.videoWriter.Close();
            this.btnStarVideo.Enabled = true;
            this.btnPuaseVideo.Enabled = false;
            this.btnStopVideo.Enabled = false;
            this.timer_count.Enabled = false;
            this.labelTime.Visible = false;
            textBox1.AppendText("录制停止!\n"+"保存路径："+videoName+"\n");
            textBox1.ScrollToCaret();
            videoName = null;
        }
    }
}
