using System;
using System.IO;
using AutoUploadFtp.Comm;

namespace AutoUploadFtp.Models
{
    /// <summary>
    /// readonly class
    /// </summary>
    public class FtpModel
    {
        #region Fields
        private const string UsernameConst = "UserName";
        private const string PasswordConst = "Password";
        private const string FtpPathConst = "FtpPath";
        private const string UploadDicConst = "UploadDic";

        #endregion

        #region Attributes
        public string UserName { get;private set; }
        public string Password { get;private set; }
        public string FtpPath { get;private set; }
        public string UploadDic { get; private set; }

        #endregion

        public FtpModel()
        {
            UserName = CommMathod.ReadAppconfig(UsernameConst);
            FtpPath = CommMathod.ReadAppconfig(FtpPathConst);
            Password = CommMathod.ReadAppconfig(PasswordConst);
            UploadDic = CommMathod.ReadAppconfig(UploadDicConst);
        }

        public static FtpModel GetFtpModelByConfig()
        {
            var ftpModel = new FtpModel
            {
                UserName = CommMathod.ReadAppconfig(UsernameConst),
                FtpPath = CommMathod.ReadAppconfig(FtpPathConst),
                Password = CommMathod.ReadAppconfig(PasswordConst),
                UploadDic = CommMathod.ReadAppconfig(UploadDicConst)
            };

            return ftpModel;
        }

        public bool UploadFtp(string filePath)
        {
            try
            {
                //FtpHelper.Instance.Upload(this.UserName, this.Password, filePath,Path.Combine(FtpPath,UploadDic));
                var ftpFactory = new FtpFactory(FtpPath, UploadDic, UserName, Password, 21);

                ftpFactory.PutSingleFiles(filePath);
                ftpFactory.DisConnect();

                return true;
            }
            catch (System.Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }

        public bool UploadFtp(string filePath,Action<string> uploadComplateAction)
        {
            try
            {
                if (UploadFtp(filePath))
                {
                    uploadComplateAction(filePath);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
                return false;
            }
        }
    }
}