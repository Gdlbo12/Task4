using System;
using System.IO;
using System.Text.Json;

namespace AvaloniaApp.Properties
{
    public sealed class Settings
    {
        private static Lazy<Settings> _default = new Lazy<Settings>(() => Load());
        public static Settings Default => _default.Value;

        private string _savedText = "";
        public string SavedText
        {
            get => _savedText;
            set
            {
                _savedText = value;
                Save();
            }
        }

        private static string SettingsFile => "appsettings.json";

        private static Settings Load()
        {
            try
            {
                if (File.Exists(SettingsFile))
                {
                    string json = File.ReadAllText(SettingsFile);
                    return JsonSerializer.Deserialize<Settings>(json) ?? new Settings();
                }
            }
            catch { }
            return new Settings();
        }

        public void Save()
        {
            try
            {
                string json = JsonSerializer.Serialize(this, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(SettingsFile, json);
            }
            catch { }
        }
    }
}
