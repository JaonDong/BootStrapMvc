using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Text;
using System.Threading;


namespace OpenAnother
{
    public delegate void ActionDelegate();
    class Program
    {
        private static string _fileName = null;

        static void Main(string[] args)
        {
            SetCycle(() =>
              {
                   ConsoleWriteLine("starting application...");
                    _fileName = ReadAppconfig("fileName");

                   if (_fileName != null)
                   {
                       ConsoleWriteLine(OpenAppliction(_fileName) ? "execution to complete" : "start failure!");
                    }
                    else
                    {
                        ConsoleWriteLine("config read failure!");
                     }
              }
            );

        }
        #region Mathods
        /// <summary>
        /// 启动文件
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="isWait"></param>
        /// <returns></returns>
        private static bool OpenAppliction(string fileName, bool isWait = true)
        {
            try
            {
                var pro = new Process { StartInfo = { FileName = fileName } };
                var result = pro.Start();

                if (result)
                {
                    ConsoleWriteLine("started");
                    if (isWait)
                        pro.WaitForExit();
                }
                return result;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        /// <summary>
        /// 读取配置
        /// </summary>
        /// <returns></returns>
        private static string ReadAppconfig(string key)
        {
            try
            {
                return ConfigurationManager.AppSettings[key];
            }
            catch (Exception ex)
            {
                return null;
            }

        }
        /// <summary>
        /// 周期运行
        /// </summary>
        /// <param name="cycleAction"></param>
        private static void SetCycle(ActionDelegate cycleAction)
        {
            var thread = new Thread(() =>
            {
                try
                {
                    var intervalTime = int.Parse(ReadAppconfig("IntervalTime"));

                    while (true)
                    {
                        cycleAction();
                        var intervalSecond = intervalTime*60;
                        ConsoleWriteLine("Waiting.....，interval time is "+intervalSecond+"s");
                        Thread.Sleep(intervalSecond*1000);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }

            });

            thread.Start();
        }

        private static void ConsoleWriteLine(string msg)
        {
            Console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss")+"   "+msg);
        }

        #endregion
    }
}
