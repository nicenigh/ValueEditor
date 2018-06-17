using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Configuration;

namespace valueEditor
{
    public static class Configuration
    {

        public static void GetAppConfig()
        {
            Setting s = Setting.getHandler();
            string splitstr = GetConfig("splitkw");
            if (splitstr != null)
            {
                s.splitkw.Clear();
                foreach (string kw in splitstr.Split(new char[] { '|' }))
                {
                    s.splitkw.Add(kw);
                }
                if (splitstr.IndexOf("|||") > -1)
                    s.splitkw.Add("|");
            }
            string nodestr = GetConfig("nodekw");
            if (nodestr != null)
            {
                s.nodekw.Clear();
                foreach (string kw in nodestr.Split(new char[] { '|' }))
                {
                    s.nodekw.Add(kw);
                }
                if (nodestr.IndexOf("|||") > -1)
                    s.nodekw.Add("|");
            }

        }


        public static void UpdateAppConfig()
        {
            Setting s = Setting.getHandler();
            string splitstr = "";
            foreach (string kw in s.splitkw)
            {
                splitstr += kw + "|";
            }
            UpdateConfig("splitkw", splitstr);
            string nodestr = "";
            foreach (string kw in s.nodekw)
            {
                nodestr += kw + "|";
            }
            UpdateConfig("nodekw", nodestr);
        }

        ///<summary> 
        ///返回*.exe.config文件中appSettings配置节的value项  
        ///</summary> 
        ///<param name="key"></param> 
        ///<returns></returns> 
        public static string GetConfig(string key)
        {
            string file = System.Windows.Forms.Application.ExecutablePath;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            if (config.AppSettings.Settings.AllKeys.Contains(key))
                return config.AppSettings.Settings[key].Value.ToString();
            else
                return null;
        }

        ///<summary>  
        ///在*.exe.config文件中appSettings配置节增加一对键值对  
        ///</summary>  
        ///<param name="key"></param>  
        ///<param name="value"></param>  
        public static void UpdateConfig(string key, string value)
        {
            string file = System.Windows.Forms.Application.ExecutablePath;
            System.Configuration.Configuration config = ConfigurationManager.OpenExeConfiguration(file);
            if (config.AppSettings.Settings.AllKeys.Contains(key))
                config.AppSettings.Settings.Remove(key);
            config.AppSettings.Settings.Add(key, value);
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }

    }
}
