using System.IO;
using System.Xml.Serialization;

namespace AssetsView
{
    public class ConfigModel
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
        public static void SaveConfig(ConfigModel config, string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ConfigModel));
            using (TextWriter writer = new StreamWriter(filePath))
            {
                serializer.Serialize(writer, config);
            }
        }

        public static ConfigModel LoadConfig(string filePath)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ConfigModel));
            using (TextReader reader = new StreamReader(filePath))
            {
                return (ConfigModel)serializer.Deserialize(reader);
            }
        }
    }
}
