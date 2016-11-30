namespace FreightHepler
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.IO.Compression;
    using System.Runtime.Serialization.Formatters.Binary;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    public class SerializableTool
    {
        public static object BytesToObject(byte[] data)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream serializationStream = new MemoryStream();
                serializationStream.Write(data, 0, data.Length);
                serializationStream.Position = 0L;
                return formatter.Deserialize(serializationStream);
            }
            catch
            {
                return null;
            }
        }

        public static string Compress(string strSource)
        {
            if (!string.IsNullOrEmpty(strSource))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(strSource);
                using (MemoryStream stream = new MemoryStream())
                {
                    using (GZipStream stream2 = new GZipStream(stream, CompressionMode.Compress, true))
                    {
                        stream2.Write(bytes, 0, bytes.Length);
                    }
                    stream.Position = 0L;
                    byte[] dst = new byte[stream.Length + 4L];
                    Buffer.BlockCopy(stream.ToArray(), 0, dst, 4, Convert.ToInt32(stream.Length));
                    Buffer.BlockCopy(BitConverter.GetBytes(bytes.Length), 0, dst, 0, 4);
                    return Convert.ToBase64String(dst);
                }
            }
            return string.Empty;
        }

        public static string Decompress(string strSource)
        {
            if (!string.IsNullOrEmpty(strSource))
            {
                byte[] buffer = Convert.FromBase64String(strSource);
                using (MemoryStream stream = new MemoryStream())
                {
                    int num = BitConverter.ToInt32(buffer, 0);
                    stream.Write(buffer, 4, buffer.Length - 4);
                    byte[] buffer2 = new byte[num];
                    stream.Position = 0L;
                    using (GZipStream stream2 = new GZipStream(stream, CompressionMode.Decompress))
                    {
                        stream2.Read(buffer2, 0, buffer2.Length);
                    }
                    return Encoding.UTF8.GetString(buffer2);
                }
            }
            return string.Empty;
        }

        public static T DeserializeJsonObject<T>(string jsonText)
        {
            try
            {
                return JsonConvert.DeserializeObject<T>(jsonText);
            }
            catch
            {
                return default(T);
            }
        }

        public static object FileToObject(string file)
        {
            try
            {
                FileStream serializationStream = new FileStream(file, FileMode.Open);
                object obj2 = new BinaryFormatter().Deserialize(serializationStream);
                serializationStream.Close();
                return obj2;
            }
            catch
            {
                return null;
            }
        }

        public static byte[] ObjectToBytes(object object_0)
        {
            try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                MemoryStream serializationStream = new MemoryStream();
                formatter.Serialize(serializationStream, object_0);
                serializationStream.Position = 0L;
                byte[] buffer = new byte[(int) serializationStream.Length];
                serializationStream.Read(buffer, 0, buffer.Length);
                return buffer;
            }
            catch
            {
                return null;
            }
        }

        public static bool ObjectToFile(object object_0, string file)
        {
            try
            {               
                FileUtil.Delete(file);
                byte[] buffer = ObjectToBytes(object_0);
                FileStream stream = new FileStream(file, FileMode.Create, FileAccess.ReadWrite);
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
                stream.Close();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string ObjectToText(object object_0)
        {
            byte[] bytes = ObjectToBytes(object_0);
            if (bytes != null)
            {
                return Encoding.UTF8.GetString(bytes);
            }
            return null;
        }

        public static object TextToObject(string text)
        {
            try
            {
                MemoryStream serializationStream = new MemoryStream();
                byte[] bytes = Encoding.UTF8.GetBytes(text);
                serializationStream.Write(bytes, 0, bytes.Length);
                object obj2 = new BinaryFormatter().Deserialize(serializationStream);
                serializationStream.Close();
                return obj2;
            }
            catch
            {
                return null;
            }
        }

        public static T XMLDeserialize<T>(string string_0)
        {
            T local;
            try
            {
                string str = Decompress(string_0);
                XmlDocument document = new XmlDocument {
                    InnerXml = str
                };
                XmlNode node = document.SelectSingleNode("//CutterTemplateModel");
                if (node != null)
                {
                    XmlNode oldChild = node.SelectSingleNode("FormernonameinfoBean");
                    if (oldChild != null)
                    {
                        node.RemoveChild(oldChild);
                    }
                }
                using (StringReader reader = new StringReader(document.InnerXml))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(T));
                    local = (T) serializer.Deserialize(reader);
                }
            }
            catch
            {
                local = default(T);
            }
            return local;
        }

        public static string XMLSerialize<T>(T gparam_0)
        {
            string str;
            try
            {
                using (StringWriter writer = new StringWriter())
                {
                    new XmlSerializer(gparam_0.GetType()).Serialize((TextWriter) writer, gparam_0);
                    str = Compress(writer.ToString());
                }
            }
            catch
            {
                str = null;
            }
            return str;
        }
    }
}

