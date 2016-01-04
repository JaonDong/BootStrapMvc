using AutoUploadFtp.Comm;

namespace AutoUploadFtp.Models
{
    public class FilePathModel
    {
        public string MonitorPath { get;private set; }
        /// <summary>
        /// 备份目录，备份目录不进行检测
        /// </summary>
        public string BackupPath { get; private set; }

        public int IntervalTime { get; private set; }

        public static FilePathModel GetFilePathModelByConfig()
        {
            var model = new FilePathModel()
            {
                MonitorPath = CommMathod.ReadAppconfig("MonitorPath"),
                BackupPath = CommMathod.ReadAppconfig("BackupPath"),
                IntervalTime = int.Parse(CommMathod.ReadAppconfig("IntervalTime")) 
            };

            return model;
        }
    }
}