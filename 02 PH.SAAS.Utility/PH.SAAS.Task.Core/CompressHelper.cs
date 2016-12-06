using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SharpCompress.Archives;
using SharpCompress.Common;
using SharpCompress.Readers;

namespace PH.SAAS.Task.Core
{
    /// <summary>
    /// 文件压缩帮助类库
    /// </summary>
    public class CompressHelper
    {
        /// <summary>
        /// 通用解压 支持rar,zip
        /// </summary>
        /// <param name="compressfilepath"></param>
        /// <param name="uncompressdir"></param>
        public static void UnCompress(string compressfilepath, string uncompressdir)
        {
            var extension = Path.GetExtension(compressfilepath);
            if (extension == null) return;
            var ext = extension.ToLower();
            switch (ext)
            {
                case ".rar":
                    UnRar(compressfilepath, uncompressdir);
                    break;
                case ".zip":
                    UnZip(compressfilepath, uncompressdir);
                    break;
            }
        }

        /// <summary>
        /// 解压rar
        /// </summary>
        /// <param name="compressfilepath"></param>
        /// <param name="uncompressdir"></param>
        private static void UnRar(string compressfilepath, string uncompressdir)
        {
            using (Stream stream = File.OpenRead(compressfilepath))
            {
                using (var reader = ReaderFactory.Open(stream))
                {
                    while (reader.MoveToNextEntry())
                    {
                        if (!reader.Entry.IsDirectory)
                        {
                            reader.WriteEntryToDirectory(uncompressdir, new ExtractionOptions
                            {
                                ExtractFullPath = true,
                                Overwrite = true
                            });
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 解压zip
        /// </summary>
        /// <param name="compressfilepath"></param>
        /// <param name="uncompressdir"></param>
        private static void UnZip(string compressfilepath, string uncompressdir)
        {
            using (var archive = ArchiveFactory.Open(compressfilepath))
            {
                foreach (var entry in archive.Entries.Where(entry => !entry.IsDirectory))
                {
                    entry.WriteToDirectory(uncompressdir, new ExtractionOptions
                    {
                        ExtractFullPath = true,
                        Overwrite = true
                    });
                }
            }
        }
    }
}
