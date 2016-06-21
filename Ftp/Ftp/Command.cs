using System;
using System.Net.FtpClient;
using System.Text.RegularExpressions;

namespace Ftp
{
    public class Command
    {
        protected string name = null;
        protected string param = null;
        protected string result = null;
        protected static FtpClient ftpClient = null;
        protected static FtpListItem[] list = null;
        private static string currentPath = null;

        public Command() { }

        public Command(string cName)
        {
            name = cName;
        }

        public Command(string cName, string cParam)
        {
            name = cName;
            param = cParam;
        }
        
        public static string CurrentPath
        {
            get
            {
                return currentPath;
            }
            set
            {
                currentPath = value;
            }
        }

        public string Name
        {
            get
            {
                return name;
            }
            set
            {
                name = value;
            }
        }

        public string Param
        {
            get
            {
                return param;
            }
            set
            {
                param = value;
            }
        }

        public string Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
            }
        }

        public virtual void Execute()
        {
            if (name.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                result = "";
            }
            else
            {
                result = "There is no such command. Enter 'help' to see the list of existing commands.";
            }
        }

        public static Command ParseCommand(string sCommand)
        {
            Command command;
            CommandsManager commandsMgr = CommandsManager.GetInstance();
            sCommand = sCommand.Trim();
            if (sCommand.IndexOf(" ") < 0)
            {
                command = commandsMgr.CreateCommand(sCommand);
            }
            else
            {
                string[] parts = Regex.Split(sCommand, @"\s+");
                command = commandsMgr.CreateCommand(parts[0]);
                if (parts.Length > 1)
                {
                    command.Param = parts[1];
                }
            }
            return command;
        }
    }
}
