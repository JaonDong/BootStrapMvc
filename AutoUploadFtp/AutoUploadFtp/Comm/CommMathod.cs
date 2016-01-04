using System;
using System.Configuration;

namespace AutoUploadFtp.Comm
{
    public static class CommMathod
    {
        /// <summary>
        /// 读取配置
        /// </summary>
        /// <returns></returns>
        public static string ReadAppconfig(string key)
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

        public static void ConsonleWriteLine(string msg)
        {
            Console.WriteLine(new DateTime().ToString("yyyy-MM-dd hh:mm:ss")+"\t\t["+msg+"]");
        }
    }
}