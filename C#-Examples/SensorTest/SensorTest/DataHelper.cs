using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Threading;
using System.IO;
using System.Web;
using Newtonsoft.Json.Linq;

namespace SensorTest
{
    class DataHelper
    {
        public delegate void UpdateDataDelegate(string url,string jsonStr);
        public UpdateDataDelegate mainThread;
        public void getData(){
            HttpListener listerner = new HttpListener();
            listerner.AuthenticationSchemes = AuthenticationSchemes.Anonymous;//指定身份验证 Anonymous匿名访问
            listerner.Prefixes.Add("http://192.168.100.102:58080/");
            listerner.Start();
            Console.WriteLine("WebServer Start Successed.......");
            while (true)
            {
                //等待请求连接
                //没有请求则GetContext处于阻塞状态
                HttpListenerContext ctx = listerner.GetContext();
                ctx.Response.StatusCode = 200;//设置返回给客服端http状态代码
                StreamReader sr = new StreamReader(ctx.Request.InputStream);
                StringBuilder sb = new StringBuilder();
                string line = null;
                while ((line = sr.ReadLine()) != null)
                {
                    sb.Append(line);
                }
                mainThread(ctx.Request.Url.ToString(), sb.ToString());
                Console.WriteLine("请求地址:"+ctx.Request.Url.ToString()+",数据:"+sb.ToString());     
                //使用Writer输出http响应代码
                using (StreamWriter writer = new StreamWriter(ctx.Response.OutputStream))
                {
                    writer.WriteLine(200);
                    writer.Close();
                }
            }
            //listerner.Stop();
        }
       
    }
}
