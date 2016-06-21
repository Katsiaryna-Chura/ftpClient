namespace Ftp
{
    public class GoToParentDirectoryCommand : Command
    {
        public override void Execute()
        {
            if (ftpClient == null)
            {
                result = "You haven't connected to a ftp server yet.";
            }
            else
            {
                ftpClient.SetWorkingDirectory(GetParentDirectory());
                CurrentPath = ftpClient.Host + ftpClient.GetWorkingDirectory();
            }
        }

        public string GetParentDirectory()
        {
            string old_path = ftpClient.GetWorkingDirectory();
            return old_path.Substring(0, old_path.LastIndexOf("/") + 1);
        }
    }
}
