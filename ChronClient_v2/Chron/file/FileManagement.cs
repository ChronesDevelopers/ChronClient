using ChronClient.Data;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.AccessControl;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ChronClient.File
{
    public static class FileManagement
    {
        public static bool HasRequiredAccessForData()
        {
            try
            {
                if (Directory.Exists(FileData.DataDirectory))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(FileData.DataDirectory);
                    WindowsIdentity id = WindowsIdentity.GetCurrent();
                    var currentUser = id.Name;
                    var sid = new SecurityIdentifier(WellKnownSidType.AccountDomainUsersSid, id.User.AccountDomainSid);
                    var dirSecurity = directoryInfo.GetAccessControl();
                    AuthorizationRuleCollection rules = dirSecurity.GetAccessRules(true, true, typeof(NTAccount));
                    bool ret = false;
                    foreach (AuthorizationRule rule in rules)
                    {
                        if (rule.GetType() == typeof(FileSystemAccessRule))
                        {
                            if (((FileSystemAccessRule)rule).IdentityReference == sid)
                            {
                                if (((FileSystemAccessRule)rule).FileSystemRights == FileSystemRights.FullControl)
                                {
                                    if (((FileSystemAccessRule)rule).AccessControlType == AccessControlType.Allow)
                                    {
                                        ret = true;
                                    }
                                }
                            
                            }
                            Debug.WriteLine("ID: " + ((FileSystemAccessRule)rule).IdentityReference);
                        }
                    }
                    if (ret == false)
                    {
                        using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
                        {
                            WindowsPrincipal principal = new WindowsPrincipal(identity);
                            if (principal.IsInRole(WindowsBuiltInRole.Administrator))
                            {
                                var new_rule = new FileSystemAccessRule(sid, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow);
                                dirSecurity.AddAccessRule(new_rule);
                                directoryInfo.SetAccessControl(dirSecurity);
                                if (!ret) ret = true;
                            }
                            else
                            {

                            }
                        }
                    }
                    return ret;
                }
                else
                {
                    using (WindowsIdentity identity = WindowsIdentity.GetCurrent())
                    {
                        WindowsPrincipal principal = new WindowsPrincipal(identity);
                        if (principal.IsInRole(WindowsBuiltInRole.Administrator))
                        {
                            Directory.CreateDirectory(FileData.DataDirectory);
                            DirectoryInfo directoryInfo = new DirectoryInfo(FileData.DataDirectory);
                            WindowsIdentity id = WindowsIdentity.GetCurrent();
                            var sid = new SecurityIdentifier(WellKnownSidType.AccountDomainUsersSid, id.User.AccountDomainSid);
                            var dirSecurity = directoryInfo.GetAccessControl();
                            var rule = new FileSystemAccessRule(sid, FileSystemRights.FullControl, InheritanceFlags.ContainerInherit | InheritanceFlags.ObjectInherit, PropagationFlags.None, AccessControlType.Allow);
                            dirSecurity.AddAccessRule(rule);
                            directoryInfo.SetAccessControl(dirSecurity);
                            return true;
                        } else
                        {
                            return false;
                        }
                    }
                }
            } catch
            {
                return false;
            }
        }
    }
}
