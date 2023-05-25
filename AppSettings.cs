using System.IO;
using System.Xml.Serialization;

namespace AssetsView
{
    public class AppSettings
    {
        public bool IsThemeRadioButtonChecked1 { get; set; }
        public bool IsThemeRadioButtonChecked2 { get; set; }
        public bool IsLanguageRadioButtonChecked1 { get; set; }
        public bool IsLanguageRadioButtonChecked2 { get; set; }
        public bool IsResolutionRadioButtonChecked1 { get; set; }
        public bool IsResolutionRadioButtonChecked2 { get; set; }
        public bool IsResolutionRadioButtonChecked3 { get; set; }
    }

    public static class ConfigManager
    {
        private static readonly string ConfigFilePath = "config.xml";

        public static void SaveSettings(AppSettings settings)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
            using (TextWriter writer = new StreamWriter(ConfigFilePath))
            {
                serializer.Serialize(writer, settings);
            }
        }

        public static AppSettings LoadSettings()
        {
            if (File.Exists(ConfigFilePath))
            {
                XmlSerializer serializer = new XmlSerializer(typeof(AppSettings));
                using (TextReader reader = new StreamReader(ConfigFilePath))
                {
                    return (AppSettings)serializer.Deserialize(reader);
                }
            }
            else
            {
                return new AppSettings();
            }
        }
    }
}
