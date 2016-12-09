using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PH.SAAS.Task.Core
{
    /// <summary>
    /// IO方面帮助类库
    /// </summary>
    public class IOHelper
    {
        /// <summary>
        /// 获取目录大小 递归
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public static long DirSize(DirectoryInfo d)
        {
            // 所有文件大小.
            var fis = d.GetFiles();
            var Size = fis.Sum(fi => fi.Length);
            // 遍历出当前目录的所有文件夹.
            var dis = d.GetDirectories();
            Size += dis.Sum(di => DirSize(di));
            return (Size);
        }

        /// <summary> 
        /// 从文件读取 Stream 
        /// </summary> 
        public static Stream FileToStream(string filePath)
        {
            // 打开文件 
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            // 读取文件的 byte[] 
            byte[] bytes = new byte[fileStream.Length];
            fileStream.Read(bytes, 0, bytes.Length);
            fileStream.Close();
            // 把 byte[] 转换成 Stream 
            Stream stream = new MemoryStream(bytes);
            return stream;
        }

        /// <summary> 
        /// 从文件读取 Stream 
        /// </summary> 
        public static byte[] FileToByte(string filePath)
        {
            // 打开文件 
            FileStream fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            // 读取文件的 byte[] 
            var dllByte = new byte[fileStream.Length];
            fileStream.Read(dllByte, 0, Convert.ToInt32(dllByte.Length));
            fileStream.Close();
            return dllByte;
        }

        public static void CopyFile(string fileFullPath, string destination, bool isDeleteSourceFile = false,
            string fileName = "")
        {
            if (string.IsNullOrWhiteSpace(fileFullPath))
            {
                throw new ArgumentNullException("fileFullPath", "源文件全路径不能为空");
            }
            if (!File.Exists(fileFullPath))
            {
                throw new FileNotFoundException("找不到源文件", fileFullPath);
            }
            if (!Directory.Exists(destination))
            {
                throw new DirectoryNotFoundException("找不到目标目录 " + destination);
            }
            fileName = string.IsNullOrWhiteSpace(fileName) ? Path.GetFileName(fileFullPath) : fileName;
            File.Copy(fileFullPath, Path.Combine(destination, fileName), true);
            if (isDeleteSourceFile)
            {
                File.Delete(fileFullPath);
            }
        }

        public static long GetDirectoryLength(string dirPath)
        {
            if (!Directory.Exists(dirPath))
            {
                return 0L;
            }
            var info = new DirectoryInfo(dirPath);
            var num = info.GetFiles().Sum(info2 => info2.Length);
            var directories = info.GetDirectories();
            if (directories.Length > 0)
            {
                num += directories.Sum(t => GetDirectoryLength(t.FullName));
            }
            return num;
        }
        public static string GetMapPath(string path)
        {
            var applicationBase = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
            if (string.IsNullOrWhiteSpace(path)) return (applicationBase + path);
            path = path.Replace("/", @"\");
            if (!path.StartsWith(@"\"))
                path = @"\" + path;
            path = path.Substring(path.IndexOf('\\') + (applicationBase.EndsWith(@"\") ? 1 : 0));
            return (applicationBase + path);
        }
    }
}
