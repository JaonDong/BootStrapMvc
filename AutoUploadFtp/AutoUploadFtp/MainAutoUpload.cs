using System;
using System.IO;
using System.Linq;
using System.Threading;
using AutoUploadFtp.Comm;
using AutoUploadFtp.Models;

namespace AutoUploadFtp
{
    public class MainAutoUpload
    {
        public void Start()
        {
            var filePathModel = FilePathModel.GetFilePathModelByConfig();
            //初始化
            var ftpModel = new FtpModel();

            for (; ; )
            {
                MoniterDirectory(filePathModel, (filepath) =>
                {
                    ftpModel.UploadFtp(filepath, (paths) =>
                    {
                        CommMathod.ConsonleWriteLine(string.Format("The File 【{0}】 has been uploaded", filepath));
                        MoveFile(paths, filePathModel.BackupPath);
                    });
                });
                //间隔时间为分钟
                Thread.Sleep(filePathModel.IntervalTime * 60 * 1000);
            }
        }

        public void MoniterDirectory(FilePathModel model, Action<string> actionBack)
        {
            var files = Directory.GetFiles(model.MonitorPath);

            if (files.Any())
            {
                //有需要上传并备份的文件
                foreach (var filePath in files)
                {
                    if (FileStatus.FileIsOpen(filePath) == 0)
                    {
                        CommMathod.ConsonleWriteLine(String.Format("Detected 【{0}】 file need to be uploaded", filePath));
                        actionBack(filePath);
                    }
                }
            }
        }

        public void MoveFile(string filePath, string backupPath)
        {

            var file = new FileInfo(filePath);
            file.MoveTo(Path.Combine(backupPath, file.Name));

            CommMathod.ConsonleWriteLine(String.Format("Move file【{0}】 to completed", file.Name));
        }
    }
}