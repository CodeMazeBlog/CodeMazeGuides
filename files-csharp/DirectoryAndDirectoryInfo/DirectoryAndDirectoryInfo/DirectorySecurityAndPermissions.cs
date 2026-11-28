using System.Runtime.Versioning;
using System.Security.AccessControl;

namespace DirectoryAndDirectoryInfo
{
    public class DirectorySecurityAndPermissions
    {
        [SupportedOSPlatform("windows")]
        public void GrantFullControl(string directoryPath, string identity)
        {
            var directoryInfo = new DirectoryInfo(directoryPath);

            DirectorySecurity directorySecurity = directoryInfo.GetAccessControl();

            directorySecurity.AddAccessRule(new FileSystemAccessRule(
                identity,
                FileSystemRights.FullControl,
                AccessControlType.Allow));

            directoryInfo.SetAccessControl(directorySecurity);
        }
    }
}
