using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json.Linq;

namespace Relang
{
    /// <summary>
    /// Represents a language.
    /// </summary>
    public class Lang
    {
        #region Properties
        /// <summary>
        /// Gets or sets the name of language.
        /// <remarks>It's a path of JSON filename before extension.</remarks>
        /// </summary>
        [XmlElement(ElementName="Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets of sets caption.
        /// </summary>
        [XmlElement(ElementName = "Caption")]
        public string Caption { get; set; }

        /// <summary>
        /// Gets or sets visibility in DataGridView.
        /// </summary>
        [XmlElement(ElementName = "Visible")]
        public bool Visible { get; set; }

        /// <summary>
        /// Gets or sets key-value pairs.
        /// </summary>
        [XmlIgnore]
        public Dictionary<string, string> Items { get; set; }

        /// <summary>
        /// Gets path to JSON which was loaded.
        /// </summary>
        [XmlIgnore]
        public string LangPath { get; private set; }
        #endregion

        #region Public members
        public Lang()
        {
            Items = new Dictionary<string, string>();
        }

        /// <summary>
        /// Load key-value pairs from JSON to current object
        /// </summary>
        /// <param name="path">Directory that contains JSON</param>
        public void Load(string path)
        {
            path = path.TrimEnd('\\') + "\\" + Name + ".json";
            LangPath = path;
            Items.Clear();

            if (!File.Exists(path))
            {
                var file = File.CreateText(LangPath);
                file.WriteLine("{}");
                file.Close();
            }

            Encoding currentEncoding = DetectEncoding(LangPath);
            JObject obj = JObject.Parse(File.ReadAllText(path, currentEncoding));
            ParseJson(Items, obj);
        }

        /// <summary>
        /// Detect encoding for input file.
        /// </summary>
        /// <param name="path">Path to input file</param>
        /// <returns>Encoding of file (UTF8 or windows-1251)</returns>
        private Encoding DetectEncoding(string path)
        {
            BinaryReader instr = new BinaryReader(File.OpenRead(path));
            //byte[] data = instr.ReadBytes((int)instr.BaseStream.Length);
            byte[] data = instr.ReadBytes(3);
            instr.Close();

            // определяем BOM (EF BB BF)
            if (data.Length > 2 && data[0] == 0xef && data[1] == 0xbb && data[2] == 0xbf)
                return Encoding.UTF8;
            return Encoding.GetEncoding(1251);
        }

        /// <summary>
        /// Returns specified value by key from this.Items.
        /// <remarks>If key doesn't exists, returns empty string.</remarks>
        /// </summary>
        /// <param name="key">Indicates key for searching.</param>
        /// <returns></returns>
        public string GetValue(string key)
        {
            if (!Items.ContainsKey(key))
                return "";
            return Items[key];
        }

        /// <summary>
        /// Save this.Items into this.LangPath.
        /// <remarks>this.Items transform to JSON before saving.</remarks>
        /// </summary>
        public void Save()
        {
            JObject jObject = new JObject();
            foreach (var item in Items.Keys)
                CreateJson(jObject, item, Items[item]);
            if (LangPath != null)
                File.WriteAllText(LangPath, jObject.ToString(), Encoding.UTF8);
        }

        /// <summary>
        /// Changes value by key in this.Items.
        /// <remarks>If key doesn't exists, then key and value will be added to the this.Items</remarks>
        /// </summary>
        /// <param name="key">Indicates key for searching.</param>
        /// <param name="value">New value for specified key.</param>
        public void ChangeValue(string key, string value)
        {
            Items[key] = value;
        }
        #endregion

        #region Private members
        /// <summary>
        /// Adds key-value into JObject.
        /// <remarks>Recursive function.</remarks>
        /// </summary>
        /// <param name="obj">JObject to which is added the key-value</param>
        /// <param name="path">Dot separated key path for added value, such as key1.key2.key3</param>
        /// <param name="value">Value of added key</param>
        private static void CreateJson(JObject obj, string path, string value)
        {
            if (value == "") return; //if value is empty, then doesn't add this key into JObject
            if (path.Split('.').Length == 1) //if path contains one key, add them value into JObject
            {
                obj.Add(new JProperty(path, value));
                return;
            }
            string fpath = path.Split('.').First(); // returns first key from path (key1.key2.key3 => fpath = key1)
            string lpath = path.Remove(0, fpath.Length + 1); // returns path without first key (key1.key2.key3 => lpath = key2.key3)
            JToken temp = obj.SelectToken(fpath);

            if (temp != null)
                CreateJson((JObject)temp, lpath, value); // recursive function call
            else
                obj.Add(CreateToken(path, value)); // if fpath token doesn't exist in JObject, then create by recursive function
        }

        /// <summary>
        /// Returns JToken.
        /// <remarks>Recursive function.</remarks>
        /// </summary>
        /// <param name="path">Dot separated key path for added value, such as key1.key2.key3</param>
        /// <param name="value">Value of added key</param>
        /// <returns></returns>
        private static JProperty CreateToken(string path, string value)
        {
            if (path.Split('.').Length == 1)
            {
                return new JProperty(path, value); // exit from recursive cycle
            }
            string fpath = path.Split('.').First(); // returns first key from path (key1.key2.key3 => fpath = key1)
            string lpath = path.Remove(0, fpath.Length + 1); // returns path without first key (key1.key2.key3 => lpath = key2.key3)
            return new JProperty(fpath, new JObject(CreateToken(lpath, value))); // recursive function call, until path contains more than one key
        }

        /// <summary>
        /// Creates Dictionary from input JObject.
        /// <remarks>Recursive function.</remarks>
        /// </summary>
        /// <param name="items">Output Collection, where each key is full path to json-value</param>
        /// <param name="obj">Input JObject</param>
        private void ParseJson(Dictionary<string, string> items, JObject obj)
        {
            foreach (var item in obj)
            {
                if (item.Value.HasValues)
                    ParseJson(items, (JObject)item.Value);
                else
                    items.Add(item.Value.Path, item.Value.ToString());
            }
        }
#endregion
    }
}
