namespace FreightHepler
{
    using Microsoft.Win32;
    using System;
    using System.Collections.Generic;

    public class AppConfig
    {
        private static ConfigFileUtil config = new ConfigFileUtil(string.Format("{0}.config", System.Windows.Forms.Application.ExecutablePath));

        public static bool IsSetupFramework4()
        {
            bool flag;
            try
            {
                List<string> list = new List<string>();
                RegistryKey key = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\NET Framework Setup\NDP");
                if (key != null)
                {
                    string[] subKeyNames = key.GetSubKeyNames();
                    for (int i = 0; i<subKeyNames.Length; i++)
                    {
                        if (!((!subKeyNames[i].StartsWith("v") || (subKeyNames[i].Length < 2)) || list.Contains(subKeyNames[i])))
                        {
                            string item = subKeyNames[i].Substring(0, 2);
                            if (!list.Contains(item))
                            {
                                list.Add(item);
                            }
                        }
                    }
                    //goto Label_0029;
                }
           
                flag = (list.Contains("v4") || list.Contains("v5")) || list.Contains("v6");
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public static string ReadConfig(string string_0)
        {
            return config.ReadValue(string_0);
        }

        public static void WriteConfig(string string_0, string value)
        {
            config.WriteValue(string_0, value);
        }
    }
}

