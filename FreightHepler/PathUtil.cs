namespace FreightHepler
{
    using System;
    using System.IO;
    using System.Windows.Forms;

    public class PathUtil
    {
        public static bool CreateDirectory(string fullPath)
        {
            try
            {
                string directoryName = Path.GetDirectoryName(fullPath);
                if (!Directory.Exists(directoryName))
                {
                    Directory.CreateDirectory(directoryName);
                }
                return Directory.Exists(directoryName);
            }
            catch
            {
                return false;
            }
        }

        public static bool CreateFolder(string folderPath)
        {
            try
            {
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                return Directory.Exists(folderPath);
            }
            catch
            {
                return false;
            }
        }

        public static bool DeleteDirectory(string folderPath)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    Directory.Delete(folderPath, true);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static void DeleteEmptyFolder(string deleteFolder)
        {
            try
            {
                DirectoryInfo info = new DirectoryInfo(deleteFolder);
                if (!(!info.Exists || IsNotEmptyFolder(deleteFolder)))
                {
                    info.Delete(true);
                }
            }
            catch
            {
            }
        }

        public static string GetAbsolutePath(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                return path.ToLower().Replace("..", Application.StartupPath);
            }
            return path;
        }

        public static string GetFullPath(string saveFolder, string jobNo, string fileName)
        {
            string str = saveFolder;
            if (jobNo.Length < 5)
            {
                str = Path.Combine(str, DateTime.Now.ToString("yyyyMMdd"));
            }
            else
            {
                str = Path.Combine(Path.Combine(str, jobNo.Substring(0, 4)), jobNo.Substring(4));
            }
            return Path.Combine(str, fileName);
        }

        public static string GetRelativePath(string path)
        {
            if (!string.IsNullOrEmpty(path))
            {
                return path.ToLower().Replace(Application.StartupPath.ToLower(), "..");
            }
            return path;
        }

        public static bool IsNotEmptyFolder(string folderPath)
        {
            bool flag = false;
            DirectoryInfo info = new DirectoryInfo(folderPath);
            if (info.GetFiles().Length > 0)
            {
                flag = true;
            }
            if (!flag)
            {
                foreach (DirectoryInfo info2 in info.GetDirectories())
                {
                    if (!flag)
                    {
                        flag = IsNotEmptyFolder(info2.FullName);
                    }
                }
            }
            return flag;
        }
    }
}

