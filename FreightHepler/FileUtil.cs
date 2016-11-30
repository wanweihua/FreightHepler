namespace FreightHepler
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading;

    public class FileUtil
    {
        public static void AddHost(string line)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(Environment.GetFolderPath(Environment.SpecialFolder.System) + @"\drivers\etc\hosts", false, Encoding.ASCII))
                {
                    writer.WriteLine(line);
                    writer.Flush();
                    writer.Close();
                }
            }
            catch
            {
            }
        }

        public static void BytesToFile(byte[] data, string fileName)
        {
            using (FileStream stream = new FileStream(fileName, FileMode.Create, FileAccess.ReadWrite))
            {
                stream.Write(data, 0, data.Length);
                stream.Flush();
            }
        }

        public static void ClearFolder(string folderPath)
        {
            try
            {
                foreach (FileInfo info in new DirectoryInfo(folderPath).GetFiles())
                {
                    info.Delete();
                }
                foreach (DirectoryInfo info2 in new DirectoryInfo(folderPath).GetDirectories())
                {
                    info2.Delete(true);
                }
            }
            catch
            {
            }
        }

        public static void ClearUpTempFiles()
        {
            try
            {
                CreateFolder(AppDomain.CurrentDomain.BaseDirectory + "Data");
                foreach (FileInfo info in new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory).GetFiles("*.temp"))
                {
                    string fileName = AppDomain.CurrentDomain.BaseDirectory + @"Data\" + info.Name;
                    Delete(fileName);
                    info.MoveTo(fileName);
                }
            }
            catch
            {
            }
        }

        public static bool CopyTo(string sourceFile, string descFile, string suffix, bool overwrite)
        {
            bool flag;
            if (!File.Exists(sourceFile))
            {
                return false;
            }
            if (overwrite && File.Exists(descFile))
            {
                try
                {
                    File.Delete(descFile);
                }
                catch
                {
                    return false;
                }
            }
            if (!PathUtil.CreateDirectory(descFile))
            {
                return false;
            }
            FileStream stream = null;
            FileStream stream2 = null;
            try
            {
                stream = File.OpenRead(sourceFile);
                stream2 = File.OpenWrite(descFile + suffix);
                stream2.Seek(stream2.Length, SeekOrigin.Begin);
                stream.Seek(stream2.Length, SeekOrigin.Begin);
                byte[] buffer = new byte[0x500000];
                int count = 0;
                while ((count = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    stream2.Write(buffer, 0, count);
                    stream2.Flush();
                }
                stream2.Close();
                stream2 = null;
                if (!string.IsNullOrEmpty(suffix))
                {
                    new FileInfo(descFile + suffix).MoveTo(descFile);
                    while (!File.Exists(descFile))
                    {
                        Thread.Sleep(15);
                    }
                }
                flag = true;
            }
            catch
            {
                flag = false;
            }
            finally
            {
                if (stream != null)
                {
                    stream.Close();
                }
                if (stream2 != null)
                {
                    stream2.Close();
                }
                Delete(descFile + suffix);
            }
            return flag;
        }

        public static bool CreateFolder(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void CreateLinkManFile()
        {
            MethodManager.InvokeNoneException(delegate {
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + @"Data\LinkMan.txt"))
                {
                    using (StreamWriter writer = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + @"Data\LinkMan.txt", true, Encoding.UTF8))
                    {
                        writer.WriteLine("您可以通过修改本文件临时添加乘车人信息,每一行为一条记录。格式为:姓名(空格)身份证号(空格)电话号码。第一条为样本。");
                        writer.WriteLine("阿里巴巴 622101195001016626 13800138000");
                        writer.Flush();
                        writer.Close();
                    }
                }
            });
        }

        public static bool Delete(string fileName)
        {
            try
            {
                File.Delete(fileName);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool Delete(string fileName, long fileLength)
        {
            try
            {
                if (File.Exists(fileName))
                {
                    FileInfo info = new FileInfo(fileName);
                    if (info.Length >= fileLength)
                    {
                        File.Delete(fileName);
                    }
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteFolder(string folderPath)
        {
            bool flag = true;
            try
            {
                DirectoryInfo info = new DirectoryInfo(folderPath);
                foreach (DirectoryInfo info3 in info.GetDirectories())
                {
                    bool flag2 = DeleteFolder(info3.FullName);
                    flag = flag ? flag2 : flag;
                }
                FileInfo[] files = info.GetFiles();
                int index = 0;
                while (true)
                {
                    if (index >= files.Length)
                    {
                        break;
                    }
                    FileInfo info2 = files[index];
                    try
                    {
                        Delete(info2.FullName);
                    }
                    catch
                    {
                    }
                    index++;
                }
                info.Delete();
            }
            catch
            {
                flag = false;
            }
            return flag;
        }

        public static void DeleteOutDateFile(string folderPath)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(folderPath);
                foreach (DirectoryInfo info2 in info.GetDirectories())
                {
                    if (info2.CreationTime <= DateTime.Now.AddDays(-1.0))
                    {
                        info2.Delete(true);
                    }
                }
            }
            catch
            {
            }
        }

        public static string GetDataFolder()
        {
            string folderPath = AppDomain.CurrentDomain.BaseDirectory + "Data";
            if (true)
            {
               // folderPath = AppDomain.CurrentDomain.BaseDirectory + "Data" + Program.AppIndex;
                folderPath = AppDomain.CurrentDomain.BaseDirectory + "Data";
            }
            CreateFolder(folderPath);
            return folderPath;
        }

        public static long GetFileLenght(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    return new FileInfo(filePath).Length;
                }
                return -1L;
            }
            catch
            {
                return -1L;
            }
        }

        public static long GetFileLengthOfFolder(string folderPath)
        {
            long num = 0L;
            foreach (FileInfo info in new DirectoryInfo(folderPath).GetFiles())
            {
                num += info.Length;
            }
            foreach (DirectoryInfo info2 in new DirectoryInfo(folderPath).GetDirectories())
            {
                num += GetFileLengthOfFolder(info2.FullName);
            }
            return num;
        }

        public static void HiddenOrShowDirectory(string folderPath, bool hidden)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(folderPath);
                if (info.Exists)
                {
                    info.Attributes = hidden ? FileAttributes.Hidden : FileAttributes.Normal;
                }
            }
            catch
            {
            }
        }

        public static bool IsEmptyFolder(string folderPath)
        {
            foreach (FileInfo info in new DirectoryInfo(folderPath).GetFiles())
            {
                if (!IsHiddenFile(info))
                {
                    return false;
                }
            }
            foreach (DirectoryInfo info2 in new DirectoryInfo(folderPath).GetDirectories())
            {
                if (!IsHiddenDirectory(info2) && !IsEmptyFolder(info2.FullName))
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsHiddenDirectory(DirectoryInfo directoryInfo_0)
        {
            return directoryInfo_0.Attributes.ToString().Contains(FileAttributes.Hidden.ToString());
        }

        public static bool IsHiddenFile(FileInfo fileinfo)
        {
            return fileinfo.Attributes.ToString().Contains(FileAttributes.Hidden.ToString());
        }

        public static bool MoveTo(string sourceFile, string descFile)
        {
            try
            {
                if (File.Exists(descFile))
                {
                    File.Delete(descFile);
                }
                PathUtil.CreateDirectory(descFile);
                File.Move(sourceFile, descFile);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}

