namespace FreightHepler
{
    using System;
    using System.IO;
    using System.Security.Cryptography;
    using System.Text;

    public class DESEncrypt
    {
        private static DESEncrypt _DESEncrypt;
        private DES des_0;
        private Encoding encoding;
        private string string_0;
        private string string_1;

        private DESEncrypt()
        {
            this.string_0 = "gowwwliz";
            this.string_1 = "www.geslock.com";
            this.encoding = new UnicodeEncoding();
            this.des_0 = new DESCryptoServiceProvider();
            #if !DEBUG
            if (!Enigma_IDE.EP_CheckupIsEnigmaOk() || !Enigma_IDE.EP_CheckupIsProtected())
                this.des_0 = null;
            #endif

        }

        public DESEncrypt(string string_2, string string_3)
        {
            this.string_0 = "gowwwliz";
            this.string_1 = "www.geslock.com";
            this.encoding = new UnicodeEncoding();
            this.string_0 = string_2;
            this.string_1 = string_3;
            this.des_0 = new DESCryptoServiceProvider();
            #if !DEBUG
            if (!Enigma_IDE.EP_CheckupIsEnigmaOk() || !Enigma_IDE.EP_CheckupIsProtected())
                this.des_0 = null;
            #endif
        }

        public void DecryptFile(string filePath)
        {
            this.DecryptFile(filePath, filePath);
        }

        public void DecryptFile(string filePath, string outPath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException("指定的解密文件没有找到");
            }
            byte[] bytes = Encoding.ASCII.GetBytes(this.string_0);
            byte[] rgbKey = Encoding.ASCII.GetBytes(this.EncryptKey);
            FileInfo info = new FileInfo(filePath);
            byte[] buffer = new byte[info.Length];
            FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            try
            {
                ICryptoTransform transform = this.des_0.CreateDecryptor(rgbKey, bytes);
                new CryptoStream(stream, transform, CryptoStreamMode.Read).Read(buffer, 0, buffer.Length);
            }
            catch (Exception exception)
            {
                throw new ApplicationException(exception.Message);
            }
            finally
            {
                try
                {
                    stream.Close();
                } 
                catch
                {
                }
            }
            FileStream stream2 = new FileStream(outPath, FileMode.Create, FileAccess.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.Close();
        }

        public string DecryptString(string strContent)
        {
            string str = "";
            try
            {
                if (string.IsNullOrEmpty(strContent))
                {
                    return string.Empty;
                }
                strContent = strContent.Replace("&AP", "/");
                byte[] rgbKey = null;
                byte[] rgbIV = null;
                byte[] buffer = new byte[strContent.Length];
                MemoryStream stream = new MemoryStream();
                CryptoStream stream2 = null;
                try
                {
                    rgbKey = Encoding.UTF8.GetBytes(this.string_1.Substring(0, 8));
                    rgbIV = Encoding.UTF8.GetBytes(this.string_0);
                    DESCryptoServiceProvider provider = new DESCryptoServiceProvider();
                    buffer = Convert.FromBase64String(strContent);
                    stream2 = new CryptoStream(stream, provider.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                    stream2.Write(buffer, 0, buffer.Length);
                    stream2.FlushFinalBlock();
                    stream2.Close();
                    stream.Close();
                    str = new UTF8Encoding().GetString(stream.ToArray());
                }
                catch
                {
                    if (stream != null)
                    {
                        stream.Close();
                    }
                    if (stream2 != null)
                    {
                        stream2.Close();
                    }
                }
            }
            catch
            {
            }
            return str;
        }

        public string DecryptString(byte[] toDecrypt)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(this.string_0);
            byte[] rgbKey = Encoding.ASCII.GetBytes(this.EncryptKey);
            byte[] buffer = new byte[toDecrypt.Length];
            ICryptoTransform transform = this.des_0.CreateDecryptor(rgbKey, bytes);
            MemoryStream stream = new MemoryStream(toDecrypt);
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Read);
            try
            {
                stream2.Read(buffer, 0, buffer.Length);
            }
            catch (Exception exception)
            {
                throw new ApplicationException(exception.Message);
            }
            finally
            {
                try
                {
                    stream.Close();
                    stream2.Close();
                }
                catch
                {
                }
            }
            return this.EncodingMode.GetString(buffer);
        }

        public string DecryptString_AsicII(string strContent)
        {
            string str = "";
            try
            {
                string str3 = "";
                int num = 0;
                for (int i = 0; i < strContent.Length; i++)
                {
                    num++;
                    str3 = str3 + strContent[i];
                    if ((num % 2) == 0)
                    {
                        byte num3 = Convert.ToByte(str3, 0x10);
                        byte[] bytes = new byte[] { num3 };
                        str = str + Encoding.ASCII.GetString(bytes);
                        num = 0;
                        str3 = "";
                    }
                }
            }
            catch
            {
                str = null;
            }
            return str;
        }

        public void EncryptFile(string filePath)
        {
            this.EncryptFile(filePath, filePath);
        }

        public void EncryptFile(string filePath, string outPath)
        {
            if (File.Exists(filePath))
            {
                byte[] bytes = Encoding.ASCII.GetBytes(this.string_0);
                byte[] rgbKey = Encoding.ASCII.GetBytes(this.EncryptKey);
                FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                string s = new StreamReader(stream, this.EncodingMode).ReadToEnd();
                byte[] buffer = this.EncodingMode.GetBytes(s);
                stream.Close();
                FileStream stream2 = new FileStream(outPath, FileMode.Create, FileAccess.Write);
                ICryptoTransform transform = this.des_0.CreateEncryptor(rgbKey, bytes);
                CryptoStream stream3 = new CryptoStream(stream2, transform, CryptoStreamMode.Write);
                try
                {
                    try
                    {
                        stream3.Write(buffer, 0, buffer.Length);
                        stream3.FlushFinalBlock();
                    }
                    catch (Exception exception)
                    {
                        throw new ApplicationException(exception.Message);
                    }
                    return;
                }
                finally
                {
                    try
                    {
                        stream2.Close();
                        stream3.Close();
                    }
                    catch
                    {
                    }
                }
            }
            throw new FileNotFoundException("没有找到指定的文件");
        }

        public void EncryptObject(string string_2)
        {
        }

        public string EncryptString(string strContent)
        {
            byte[] rgbKey = null;
            byte[] rgbIV = null;
            byte[] buffer = null;
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = null;
            try
            {
                rgbKey = Encoding.UTF8.GetBytes(this.string_1.Substring(0, 8));
                rgbIV = Encoding.UTF8.GetBytes(this.string_0);
                buffer = Encoding.UTF8.GetBytes(strContent);
                stream2 = new CryptoStream(stream, this.des_0.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                stream2.Write(buffer, 0, buffer.Length);
                stream2.FlushFinalBlock();
                stream2.Close();
                stream.Close();
                return Convert.ToBase64String(stream.ToArray());
            }
            catch
            {
                if (stream2 != null)
                {
                    stream2.Close();
                }
                if (stream != null)
                {
                    stream.Close();
                }
                return null;
            }
        }

        public string EncryptString_AsicII(string strContent)
        {
            string str = "";
            try
            {
                byte[] bytes = Encoding.ASCII.GetBytes(strContent);
                for (int i = 0; i < bytes.Length; i++)
                {
                    str = str + Convert.ToString(bytes[i], 0x10).PadLeft(2, '0');
                }
            }
            catch
            {
                str = null;
            }
            return str;
        }

        public byte[] EncryptStringReturnBytes(string string_2)
        {
            byte[] bytes = Encoding.ASCII.GetBytes(this.string_0);
            byte[] rgbKey = Encoding.ASCII.GetBytes(this.EncryptKey);
            byte[] buffer = this.EncodingMode.GetBytes(string_2);
            ICryptoTransform transform = this.des_0.CreateEncryptor(rgbKey, bytes);
            MemoryStream stream = new MemoryStream();
            CryptoStream stream2 = new CryptoStream(stream, transform, CryptoStreamMode.Write);
            stream2.Write(buffer, 0, buffer.Length);
            stream2.FlushFinalBlock();
            byte[] buffer4 = stream.ToArray();
            stream2.Close();
            stream.Close();
            return buffer4;
        }

        public static DESEncrypt Default
        {
            get
            {
                if (_DESEncrypt == null)
                {
                    _DESEncrypt = new DESEncrypt();
                }
                return _DESEncrypt;
            }
        }

        public Encoding EncodingMode
        {
            get
            {
                return this.encoding;
            }
            set
            {
                this.encoding = value;
            }
        }

        public string EncryptKey
        {
            get
            {
                return this.string_1;
            }
            set
            {
                this.string_1 = value;
            }
        }
    }
}

