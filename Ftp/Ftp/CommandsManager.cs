namespace Ftp
{
    public class CommandsManager
    {
        private static CommandsManager instance = null;

        private CommandsManager() { }

        public Command CreateCommand(string name)
        {
            Command command = null;
            switch (name)
            {
                case "connect":
                    command = new ConnectCommand();
                    break;
                case "list":
                    command = new ListCommand();
                    break;
                case "download":
                    command = new DownloadCommand();
                    break;
                case "help":
                    command = new HelpCommand();
                    break;
                case "back":
                    command = new GoToParentDirectoryCommand();
                    break;
                default:
                    command = new Command();
                    break;
            }
            command.Name = name;
            return command;
        }

        public static CommandsManager GetInstance()
        {
            if (instance == null)
            {
                instance = new CommandsManager();
            }
            return instance;
        }
    }

}
