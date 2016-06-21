using System;

namespace Ftp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string sCommand = null;
            Command command = null;
            do
            {
                if (Command.CurrentPath == null || Command.CurrentPath.Equals(""))
                {
                    Console.Write("Enter a command: ");
                }
                else
                {
                    Console.Write(Command.CurrentPath + " > ");
                }
                sCommand = Console.ReadLine();
                Console.WriteLine();
                command = Command.ParseCommand(sCommand);
                command.Execute();
                if ((command.Result != null) && (!command.Result.Equals("")))
                {
                    Console.WriteLine(command.Result);
                }
                Console.WriteLine();
            } while (!sCommand.Equals("exit", StringComparison.OrdinalIgnoreCase));
        }
    }    
}
