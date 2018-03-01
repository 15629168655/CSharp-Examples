using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using camera.Util;

namespace camera
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
            //FileCompressUtil.ZipFile("C:\\Users\\THINKPAD\\Desktop\\camera\\camera\\bin\\Debug\\FILE\\20171111101011.MP4", "C:\\Users\\THINKPAD\\Desktop\\camera\\camera\\bin\\Debug\\FILE", "aaa", 9, 2048, true);
            //FileCompressUtil.UnZip("C:\\Users\\THINKPAD\\Desktop\\camera\\camera\\bin\\Debug\\FILE\\aaa.zip", "C:\\Users\\THINKPAD\\Desktop\\camera\\camera\\bin\\Debug\\FILE\\","123",true);
            //FileCompressUtil.ZipDirectory("C:\\Users\\THINKPAD\\Desktop\\2312", "C:\\Users\\THINKPAD\\Desktop\\","2312", true);
            //FileCompress FileCompress = new FileCompress();
            //FileCompress.ZipDir("C:\\Users\\THINKPAD\\Desktop\\2312", "C:\\Users\\THINKPAD\\Desktop\\2312", 9);       
        }
    }
}
