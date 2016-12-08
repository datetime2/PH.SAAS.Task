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
            return new byte[fileStream.Length];
        }
    }
}
