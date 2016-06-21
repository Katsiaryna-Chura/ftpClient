using System;

namespace Ftp
{
    public class HelpCommand : Command
    {
        public override void Execute()
        {
            Console.WriteLine("back               -  changes working directory to its parent directory");
            Console.WriteLine("connect [url_name] -  connects to URL defined by url_name. By default connects to 'ftp.man.lodz.pl'");
            Console.WriteLine("download file_name -  downloads the file defined by file_name");
            Console.WriteLine("help               -  provides help information existing commands");
            Console.WriteLine("list [dir_name]    -  displays the list of directories and files in the directory");
        }
    }
}
