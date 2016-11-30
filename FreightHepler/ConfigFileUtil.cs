namespace FreightHepler
{
    using System;
    using System.IO;
    using System.Xml;

    public class ConfigFileUtil
    {
        private string fileName;

        public ConfigFileUtil(string fileName)
        {
            this.fileName = fileName;
        }

        public string ReadValue(string keyName)
        {
            if (File.Exists(this.fileName))
            {
                XmlDocument document = new XmlDocument();
                document.Load(this.fileName);
                XmlNode node = document.SelectSingleNode("//add[@key='" + keyName + "']");
                if (node != null)
                {
                    return node.Attributes["value"].Value;
                }
            }
            return "";
        }

        public void WriteValue(string keyName, string keyValue)
        {
            XmlDocument document = new XmlDocument();
            if (File.Exists(this.fileName))
            {
                document.Load(this.fileName);
            }
            else
            {
                document.AppendChild(document.CreateXmlDeclaration("1.0", "utf-8", null));
                document.AppendChild(document.CreateElement("configuration")).AppendChild(document.CreateElement("appSettings"));
            }
            XmlNode node = document.SelectSingleNode("//add[@key='" + keyName + "']");
            if (node != null)
            {
                ((XmlElement) node).SetAttribute("value", keyValue);
            }
            else
            {
                node = document.SelectSingleNode("//configuration/appSettings").AppendChild(document.CreateElement("add"));
                node.Attributes.Append(document.CreateAttribute("key")).Value = keyName;
                node.Attributes.Append(document.CreateAttribute("value")).Value = keyValue;
            }
            document.Save(this.fileName);
        }
    }
}

