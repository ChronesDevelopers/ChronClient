using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChronClient.File
{
    public static class Profile
    {
        public static ProfileClass GetCurrentProfileClass()
        {
            ProfileClass profile = new ProfileClass();
            profile.Name = "%CURRENT%";
            profile.VERSION = 0;
            profile.Tags = new string[] { "test" };
            ProfileClassSettingsCollection profile_modules = new ProfileClassSettingsCollection();
            ProfileClassSettingsCollection profile_keybinds = new ProfileClassSettingsCollection();

            profile_modules.Name = "Modules";
            profile_keybinds.Name = "Keybinds";

            profile_modules.Settings = GetCurrentProfileClass_Modules();
            profile_keybinds.Settings = GetCurrentProfileClass_Keybinds();

            profile.ProfileSettings = new ProfileClassSettingsCollection[] { profile_modules, profile_keybinds };

            return profile;
        }
        private static ProfileClassSetting[] GetCurrentProfileClass_Modules()
        {
            /// MODULES ///

            List<ProfileClassSetting> settings = new List<ProfileClassSetting>();
            settings.AddRange(Module.Airjump.Profile.GetSettings());
            settings.AddRange(Module.AirWalk.Profile.GetSettings());
            settings.AddRange(Module.Antivoid.Profile.GetSettings());
            settings.AddRange(Module.BlockReach.Profile.GetSettings());
            settings.AddRange(Module.ClickTp.Profile.GetSettings());

            return settings.ToArray();
        }
        private static ProfileClassSetting[] GetCurrentProfileClass_Keybinds()
        {
            /// KEYBINDS ///

            return null;
        }
        public static string GetCurrentProfileClassJson()
        {
            return JsonConvert.SerializeObject(GetCurrentProfileClass(), Formatting.Indented);
        }
        public static string GetCurrentProfileClassJsonSmall()
        {
            return JsonConvert.SerializeObject(GetCurrentProfileClass(), Formatting.None);
        }

        public static string GetProfileInfo(ProfileClass profile)
        {
            string ret = "";
            ret += $"Profile Info\n";
            ret +=  "{\n";
            ret += $"\tProfileName: {profile.Name}\n";
            ret += $"\tProfileVersion: {profile.VERSION}\n";
            //ret += $"\tProfileTags: {profile.Tags}\n";
            ret += $"\tProfileSettings\n";
            ret += "\t{\n";
            foreach (ProfileClassSettingsCollection obj001 in profile.ProfileSettings)
            {
                if (obj001.Settings != null)
                {
                    ret += $"\t\t{obj001.Name}\n";
                    ret += "\t\t{\n";
                    foreach (ProfileClassSetting obj002 in obj001.Settings)
                    {
                        if (obj002.Name != null)
                        {
                            if (obj002.Value != null)
                            {
                                ret += $"\t\t\t{obj002.Name}: {obj002.Value}\n";
                            } else {
                                ret += $"\t\t\t{obj002.Name}: null\n";
                            }
                        }
                    }
                    ret += "\t\t}\n";
                } else
                {
                    ret += $"\t\t{obj001.Name}: null\n";
                }
            }
            ret += "\t}\n";
            ret += "}\n";
            return ret;
        }
    }
}
