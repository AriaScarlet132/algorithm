using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Rcbi.AspNetCore.Helper
{
    public class LogHelper
    {
        private static object obj = new object();
        /// <summary>
        /// 记录系统日志
        /// </summary>
        public static void RecordLog(string fileName, string Msg, string Type)
        {
            try
            {
                lock (obj)
                {
                    string filePath = Directory.GetCurrentDirectory() + "\\Log\\" + Type + "\\";
                    if (!Directory.Exists(filePath))
                    {
                        Directory.CreateDirectory(filePath);
                    }
                    string path = filePath + fileName + ".txt";
                    if (!File.Exists(path))
                    {
                        FileInfo myfile = new FileInfo(path);
                        FileStream fs = myfile.Create();
                        fs.Close();
                    }
                    StreamWriter sw = File.AppendText(path);
                    sw.WriteLine(Msg);
                    sw.Flush();
                    sw.Close();
                }
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// 普通日志
        /// </summary>
        /// <param name="Msg"></param>
        public static void Info(string Msg)
        {
            Task.Run(() =>
            {
                string fileName = DateTime.Now.ToString("yyyyMMdd");
                RecordLog(fileName, Msg, "Info");
            });

        }

        /// <summary>
        /// 错误日志
        /// </summary>
        /// <param name="Msg"></param>
        public static void Error(string Msg)
        {
            Task.Run(() =>
            {
                string fileName = DateTime.Now.ToString("yyyyMMdd");
                RecordLog(fileName, Msg, "Error");
            });

        }

        /// <summary>
        /// 模型任务日志
        /// </summary>
        public static void TaskInfo(string task_no, string model_type, string title, string data)
        {
            string text =
                  "title:" + title + "\r\n"
                + "date:"+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"\r\n"
                + "model_type:" + model_type + "\r\n"
                + "task_no:" + task_no + "\r\n"
                + "data:" + data + "\r\n";
            Info(text);
        }

    }
}
