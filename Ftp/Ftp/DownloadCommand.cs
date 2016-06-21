using System;
using System.IO;

namespace Ftp
{
    public class DownloadCommand : Command
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
                result = "You haven't entered the name of the file to download.";
                return;
            }
            if (ftpClient.FileExists(param))
            {
                int index = -1;
                for (int i = 0; i < list.Length; i++)
                {
                    if ((list[i].Type.ToString().Equals("File")) && (list[i].Name.Equals(param)))
                    {
                        index = i;
                        break;
                    }
                }

                var destinationDirectory = Directory.GetCurrentDirectory();
                var destinationPath = string.Format(@"{0}\{1}", destinationDirectory, list[index].Name);
                
                using (var ftpStream = ftpClient.OpenRead(list[index].FullName))
                using (var fileStream = File.Create(destinationPath, (int)ftpStream.Length))
                {
                    var buffer = new byte[4096];//4KB is the default value for buffer size used by .net framework                   
                    int count;
                    while ((count = ftpStream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fileStream.Write(buffer, 0, count);
                    }
                }
                result = "File is downloaded.";
            }
            else
            {
                result = "There is no such file.";
            }
        }
    }
}
