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
    }
}
