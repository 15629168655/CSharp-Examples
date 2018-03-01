using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using AForge.Video;
using System.Drawing.Imaging;
using AForge.Video.FFMPEG;
using System.IO;

namespace DirectShowDemo
{
    public partial class frmCapture : Form
    {
        public frmCapture()
        {
            InitializeComponent();
        }
        private void video_NewFrame(object sender,
                NewFrameEventArgs eventArgs)
        {
            // get new frame
            Bitmap bitmap = eventArgs.Frame;
            //image.SetPixel(i % width, i % height, Color.Red);
            writer.WriteVideoFrame(bitmap, timer.Elapsed);

        }

        VideoFileWriter writer = new VideoFileWriter();
        VideoCaptureDevice videoSource = null;
        System.Diagnostics.Stopwatch timer = null;
        private void btnStart_Click(object sender, EventArgs e)
        {
            VideoCaptureDeviceForm videoSettings = new VideoCaptureDeviceForm();
            var result =  videoSettings.ShowDialog(this);
            if (result == System.Windows.Forms.DialogResult.Cancel)
            {
                return;
            }

            // create video source
            videoSource = videoSettings.VideoDevice;
            // set NewFrame event handler
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            // start the video source
            videoSource.Start();


            var fileName = string.Format(@"C:\temp\capv\{0}.flv", Guid.NewGuid().ToString());
            FileInfo fInfo = new FileInfo(fileName);
            if (!Directory.Exists(fInfo.DirectoryName))
            {
                Directory.CreateDirectory(fInfo.DirectoryName);
            }

            // create new video file
            writer.Open(fileName, 640, 480, 30, VideoCodec.FLV1);

            //start a timer to sync the video timeline
            timer = System.Diagnostics.Stopwatch.StartNew();

            ShowCurrentStatus("running");
        }

        private void ShowCurrentStatus(string status)
        {
            if (status == "running")
            {
                this.btnStart.Enabled = false;
                lblMessage.Text = "Recording......";
                this.btnStop.Enabled = true;
            }
            if (status == "stop")
            {
                this.btnStop.Enabled = false;
                lblMessage.Text = "Press start button to record...";
                this.btnStart.Enabled = true;
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            videoSource.SignalToStop();
            videoSource.WaitForStop();
            writer.Close();
            ShowCurrentStatus("stop");
        }

        private void frmCapture_Load(object sender, EventArgs e)
        {
            this.btnStop.Enabled = false;
        }
    }
}
