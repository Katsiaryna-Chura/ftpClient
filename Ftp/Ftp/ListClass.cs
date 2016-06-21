using System;
using System.Net.FtpClient;

namespace Ftp
{
    public class ListCommand : Command
    {
        public override void Execute()
        {
            if (ftpClient == null)
            {
                result = "You haven't connected to a ftp server yet.";
                return;
            }
            if (param == null || param.Equals(""))
            {
                list = ftpClient.GetListing();
                if (list.Length == 0)
                {
                    result = "The directory is empty";
                }
                else
                {
                    foreach (FtpListItem str in list)
                    {
                        Console.WriteLine(str.Name);
                    }
                    result = "";
                }
            }
            else if (!ftpClient.DirectoryExists(param))
            {
                result = "The directory doesn't exist.";
            }
            else
            {
                list = ftpClient.GetListing(param);
                if (list.Length == 0)
                {
                    result = "The directory is empty";
                }
                else
                {
                    foreach (FtpListItem str in list)
                    {
                        Console.WriteLine(str.Name);
                    }
                    ftpClient.SetWorkingDirectory(param);
                    result = "";
                }
            }
            CurrentPath = ftpClient.Host + ftpClient.GetWorkingDirectory();
        }
    }
}
