namespace FreightHepler
{
    using Newtonsoft.Json;
    using System;
    using System.Collections;
    using System.IO;
    using System.IO.Compression;
    using System.Text;
    using System.Xml;

    public class XmlUtil
    {
        private static XmlNode CreateXmlNode(XmlNode parent, string xpath)
        {
            XmlNode node = parent;
            foreach (string str in xpath.Trim(new char[] { '/', '\\' }).Trim().Split(new char[] { '/', '\\' }))
            {
                bool flag = false;
                if (node.HasChildNodes)
                {
                    //using (IEnumerator enumerator = node.ChildNodes.GetEnumerator())
                    IEnumerator enumerator = node.ChildNodes.GetEnumerator();
                    {
                        XmlNode current;
                        while (enumerator.MoveNext())
                        {
                            current = (XmlNode) enumerator.Current;
                            if (current.Name == str)
                            {
                                goto Label_008D;
                            }
                        }
                        goto Label_00AD;
                    Label_008D:
                        node = current;
                        flag = true;
                    }
                }
            Label_00AD:
                if (!flag)
                {
                    node = node.AppendChild(node.OwnerDocument.CreateElement(str));
                }
            }
            return node;
        }

        public static XmlDocument FromJsonText(string jsonText)
        {
            try
            {
                return JsonConvert.DeserializeXmlNode(jsonText, "Root");
            }
            catch
            {
                return new XmlDocument();
            }
        }

        public static string GetNodeAttributeValue(XmlNode node, string attributeName)
        {
            XmlAttribute attribute = node.Attributes[attributeName];
            if (attribute != null)
            {
                return attribute.InnerText;
            }
            return string.Empty;
        }

        public static string GetNodeAttributeValue(XmlDocument xmlDocument_0, string xpath, string attributeName)
        {
            XmlNode node = xmlDocument_0.SelectSingleNode(xpath);
            if (node != null)
            {
                return GetNodeAttributeValue(node, attributeName);
            }
            return string.Empty;
        }

        public static string GetNodeInnerText(XmlDocument xmlDocument_0, string xpath)
        {
            try
            {
                XmlNode node = xmlDocument_0.SelectSingleNode(xpath);
                if (node != null)
                {
                    return node.InnerText;
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static string GetNodeInnerText(XmlNode node, string xpath)
        {
            try
            {
                XmlNode node2 = node.SelectSingleNode(xpath);
                if (node2 != null)
                {
                    return node2.InnerText;
                }
                return string.Empty;
            }
            catch
            {
                return string.Empty;
            }
        }

        public static byte[] RunGZip(XmlDocument xmlDocument_0)
        {
            byte[] buffer2;
            MemoryStream stream = new MemoryStream();
            GZipStream stream2 = null;
            try
            {
                stream2 = new GZipStream(stream, CompressionMode.Compress, true);
                byte[] bytes = Encoding.UTF8.GetBytes(xmlDocument_0.InnerXml);
                stream2.Write(bytes, 0, bytes.Length);
                stream2.Flush();
                stream2.Close();
                buffer2 = stream.ToArray();
            }
            catch (Exception exception)
            {
                throw new Exception("xml to zip stream faild", exception);
            }
            finally
            {
                stream.Close();
                if (stream2 != null)
                {
                    stream2.Close();
                }
            }
            return buffer2;
        }

        public static void SetNodeInnerText(XmlDocument xmlDocument_0, string xpath, string value)
        {
            XmlNode node = xmlDocument_0.SelectSingleNode(xpath);
            if (node != null)
            {
                node.InnerText = value;
            }
        }

        public static void SetNodeInnerText(XmlNode node, string xpath, string value)
        {
            XmlNode node2 = node.SelectSingleNode(xpath);
            if (node2 != null)
            {
                node2.InnerText = value;
            }
        }
    }
}

