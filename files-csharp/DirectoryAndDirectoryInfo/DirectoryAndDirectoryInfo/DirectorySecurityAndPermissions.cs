using System.Security.AccessControl;

namespace DirectoryAndDirectoryInfo
{
    public class DirectorySecurityAndPermissions
    {
        public void GetSetAccessControl()
        {
            var directoryPath = @"C:\Users\Public\CM-Demos";
            var directoryInfo = new DirectoryInfo(directoryPath);

            DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();

            directorySecurity.AddAccessRule(new FileSystemAccessRule("UserName", FileSystemRights.FullControl, AccessControlType.Allow));

            directoryInfo.SetAccessControl(directorySecurity);
        }
    }
}
