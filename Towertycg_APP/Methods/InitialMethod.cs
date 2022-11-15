using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Towertycg_APP.Configuration;

namespace Towertycg_APP.Methods
{
    public class InitialMethod
    {
        /// <summary>
        /// 工作路徑
        /// </summary>
        private static readonly string WorkPath = AppDomain.CurrentDomain.BaseDirectory;
        #region 系統資訊
        /// <summary>
        /// 讀取系統資訊
        /// </summary>
        /// <returns></returns>
        public static SystemSetting System_Load()
        {
            SystemSetting settings = null;
            if (!Directory.Exists($"{WorkPath}\\stf"))
                Directory.CreateDirectory($"{WorkPath}\\stf");
            string setFile = $"{WorkPath}\\stf\\System.json";
            try
            {
                if (File.Exists(setFile))
                {
                    string json = File.ReadAllText(setFile, Encoding.UTF8);
                    settings = JsonConvert.DeserializeObject<SystemSetting>(json);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "讀取系統資訊失敗");
            }
            return settings;
        }
        /// <summary>
        /// 儲存系統資訊
        /// </summary>
        /// <param name="setting"></param>
        public static void System_Save(SystemSetting setting)
        {
            if (!Directory.Exists($"{WorkPath}\\stf"))
                Directory.CreateDirectory($"{WorkPath}\\stf");
            string setFile = $"{WorkPath}\\stf\\System.json";
            string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
            File.WriteAllText(setFile, output);
        }
        #endregion
        #region API資訊
        /// <summary>
        /// 讀取API資訊
        /// </summary>
        /// <returns></returns>
        public static APISetting API_Load()
        {
            APISetting settings = null;
            if (!Directory.Exists($"{WorkPath}\\stf"))
                Directory.CreateDirectory($"{WorkPath}\\stf");
            string setFile = $"{WorkPath}\\stf\\API.json";
            try
            {
                if (File.Exists(setFile))
                {
                    string json = File.ReadAllText(setFile, Encoding.UTF8);
                    settings = JsonConvert.DeserializeObject<APISetting>(json);
                }
                else
                {
                    settings = new APISetting
                    {
                        Flag = true,
                        URL = "https://towertycg-backend.azurewebsites.net/"
                    };
                    string output = JsonConvert.SerializeObject(settings, Formatting.Indented, new JsonSerializerSettings());
                    File.WriteAllText(setFile, output);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "讀取API資訊失敗");
            }
            return settings;
        }
        #endregion
        #region 推播資訊
        /// <summary>
        /// 讀取推播資訊
        /// </summary>
        /// <returns></returns>
        public static List<NotifySetting> Notify_Load()
        {
            List<NotifySetting> setting = null;
            if (!Directory.Exists($"{WorkPath}\\stf"))
                Directory.CreateDirectory($"{WorkPath}\\stf");
            string setFile = $"{WorkPath}\\stf\\Notify.json";
            try
            {
                if (File.Exists(setFile))
                {
                    string json = File.ReadAllText(setFile, Encoding.UTF8);
                    setting = JsonConvert.DeserializeObject<List<NotifySetting>>(json).ToList();
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "讀取推播資訊失敗");
            }
            return setting;
        }
        /// <summary>
        ///  儲存推播資訊
        /// </summary>
        /// <param name="setting"></param>
        public static void Notify_Save(List<NotifySetting> setting)
        {
            if (!Directory.Exists($"{WorkPath}\\stf"))
                Directory.CreateDirectory($"{WorkPath}\\stf");
            string setFile = $"{WorkPath}\\stf\\Notify.json";
            string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
            File.WriteAllText(setFile, output);
        }
        #endregion
        #region 群組資訊
        /// <summary>
        /// 讀取群組資訊
        /// </summary>
        /// <returns></returns>
        public static GroupSetting Group_Load()
        {
            GroupSetting settings = null;
            if (!Directory.Exists($"{WorkPath}\\stf"))
                Directory.CreateDirectory($"{WorkPath}\\stf");
            string setFile = $"{WorkPath}\\stf\\Group.json";
            try
            {
                if (File.Exists(setFile))
                {
                    string json = File.ReadAllText(setFile, Encoding.UTF8);
                    settings = JsonConvert.DeserializeObject<GroupSetting>(json);
                }
            }
            catch (Exception ex)
            {
                Log.Error(ex, "讀取群組資訊失敗");
            }
            return settings;
        }
        /// <summary>
        /// 儲存群組資訊
        /// </summary>
        /// <param name="setting"></param>
        public static void Group_Save(GroupSetting setting)
        {
            if (!Directory.Exists($"{WorkPath}\\stf"))
                Directory.CreateDirectory($"{WorkPath}\\stf");
            string setFile = $"{WorkPath}\\stf\\Group.json";
            string output = JsonConvert.SerializeObject(setting, Formatting.Indented, new JsonSerializerSettings());
            File.WriteAllText(setFile, output);
        }
        #endregion
    }
}
