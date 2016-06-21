using System;
using System.Net;
using System.Net.FtpClient;

namespace Ftp
{
    public class ConnectCommand : Command
    {
        public override void Execute()
        {
            try
            {
                ftpClient = new FtpClient();
                if (param == null || param.Equals(""))
                {
                    ftpClient.Host = "ftp.man.lodz.pl";
                }
                else
                {
                    ftpClient.Host = param;
                }
                ftpClient.Credentials = new NetworkCredential("Anonymous", "Anonymous");
                ftpClient.Connect();
                CurrentPath = ftpClient.Host + ftpClient.GetWorkingDirectory();
                result = "The connection is established";
            }
            catch (ObjectDisposedException ex)
            {
                result = "Exception occured. The connection cannot be established";
            }
            catch (System.Net.Sockets.SocketException ex)
            {
                result = "Cannot find such ftp server. The connection cannot be established";
            }
        }
    }
}
