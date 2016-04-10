using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Xml.Serialization;

namespace Relang
{
    /// <summary>
    /// Provides instance methods for the displaying, modifying, saving languages.
    /// </summary>
    public class Translator
    {
        /// <summary>
        /// Gets or sets directory where JSON can be found.
        /// </summary>
        [XmlElement(ElementName="Path")]
        public string Path { get; set; }

        /// <summary>
        /// Gets or sets folder name which contains JSON.
        /// </summary>
        [XmlElement(ElementName = "Folder")]
        public string Folder { get; set; }

        /// <summary>
        /// Gets or sets languages collection.
        /// </summary>
        public List<Lang> Langs { get; set; }

        /// <summary>
        /// Gets or sets directory with JSON which was loaded.
        /// </summary>
        [XmlIgnore]
        public string CurrentPath { get; set; }

        public Translator()
        {
            Langs = new List<Lang>();
        }

        /// <summary>
        /// Load languages into translator object.
        /// </summary>
        /// <param name="currentPath">Directory with JSON.</param>
        public void LoadLangs(string currentPath)
        {
            CurrentPath = currentPath;
            foreach(var lang in Langs)
            {
                lang.Load(CurrentPath);
            }
        }

        /// <summary>
        /// Creates translator object by default configuration file.
        /// </summary>
        /// <returns></returns>
        public static Translator LoadConfig()
        {
            return LoadConfig("RelangConfig.xml");
        }

        /// <summary>
        /// Creates translator object by specified configuration file.
        /// </summary>
        /// <param name="configFilePath">Configuration filename</param>
        /// <returns></returns>
        public static Translator LoadConfig(string configFilePath)
        {
            XmlSerializer xer = new XmlSerializer(typeof(Translator));
            if (File.Exists(configFilePath))
            {
                using (var stream = File.OpenRead(configFilePath))
                {
                    Translator tr = (Translator)xer.Deserialize(stream);
                    return tr;
                }
            }
            else
                return null;
        }

        /// <summary>
        /// Returns collection of containing languages caption.
        /// </summary>
        /// <returns></returns>
        public string[] GetCaptions()
        {
            string[] header = new string[Langs.Count];
            for (int i = 0; i < header.Length; i++)
            {
                header[i] = Langs[i].Caption;
            }
                return header;
        }

        /// <summary>
        /// Returns collection of unique keys from all languages.
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllKeys()
        {
            List<string> allKeys = new List<string>();
            foreach(var lang in Langs)
            {
                List<string> temp = lang.Items.Keys.ToList().Except(allKeys).ToList();
                allKeys.AddRange(temp);
            }
            return allKeys;
        }

        /// <summary>
        /// Returns value by key for specified language.
        /// </summary>
        /// <param name="key">Indicates key for searching.</param>
        /// <param name="langName">Language name (Lang.Name property).</param>
        /// <returns></returns>
        public string GetValue(string key, string langName)
        {
            string result = Langs.Single(l => l.Name.Equals(langName)).GetValue(key);

            return result;
        }

        /// <summary>
        /// Returns collection of languages which visibility is true.
        /// </summary>
        /// <returns></returns>
        public Lang[] GetLangs()
        {
            var list = Langs.Where(l => l.Visible).Select(l => l).ToList();
            return list.ToArray();
        }

        /// <summary>
        /// Renames key with name oldKey to newKey, but corresponding value not changed.
        /// </summary>
        /// <param name="oldKey">Indicates key which should be renamed.</param>
        /// <param name="newKey">Indicates new name of key.</param>
        public void RenameKey(string oldKey, string newKey)
        {
            if (GetAllKeys().Contains(newKey))
                return;
            foreach(var lang in Langs)
            {
                if (lang.Items.ContainsKey(oldKey))
                {
                    lang.Items.Add(newKey, lang.Items[oldKey]);
                    lang.Items.Remove(oldKey);
                }
            }
        }

        /// <summary>
        /// Changes the value for specified languages by key.
        /// </summary>
        /// <param name="langName">Language name (Lang.Name property).</param>
        /// <param name="key">Indicates key which value should be changed.</param>
        /// <param name="newValue">Indicates new value for key</param>
        public void ChangeLangValue(string langName, string key, string newValue)
        {
            var lang = Langs.Single(l => l.Name == langName);
            lang.ChangeValue(key, newValue);
        }

        /// <summary>
        /// Removes the key from all languages.
        /// </summary>
        /// <param name="key">Indicates key which should be removed.</param>
        public void RemoveKey(string key)
        {
            foreach(var lang in Langs)
            {
                lang.Items.Remove(key);
            }
        }

        /// <summary>
        /// Saves all languages to JSON files.
        /// </summary>
        public void Save()
        {
            foreach (var lang in Langs)
                lang.Save();
        }

        /// <summary>
        /// Saves translator settings to default configuration file.
        /// </summary>
        public void SaveConfig()
        {
            SaveConfig("RelangConfig.xml");
        }

        /// <summary>
        /// Saves translator settings to specified configuration file.
        /// </summary>
        /// <param name="configFilename">Configuration filename.</param>
        public void SaveConfig(string configFilename)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Translator));
            using (var stream = File.Create(configFilename))
            {
                serializer.Serialize(stream, this);
            }
        }
    }
}
