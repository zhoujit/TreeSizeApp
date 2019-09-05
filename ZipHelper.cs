using ICSharpCode.SharpZipLib.Checksums;
using ICSharpCode.SharpZipLib.Zip;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeSizeApp
{
    class ZipHelper
    {
        public static bool ZipFolder(string compressFolder, bool removeZippedFolder)
        {
            bool success = true;
            if (Directory.Exists(compressFolder))
            {
                DirectoryInfo di = new DirectoryInfo(compressFolder);
                string fileName = di.Name + ".zip";

                string zipFileName = Path.Combine(compressFolder, fileName);
                HandleFolder(di.FullName, zipFileName, removeZippedFolder);
            }
            else
            {
                success = false;
            }
            return success;
        }

        private static void HandleFolder(string compressFolder, string zipFileName, bool removeZippedFolder)
        {
            int compressionLevel = 9;
            if (!compressFolder.EndsWith(Path.DirectorySeparatorChar.ToString()))
            {
                compressFolder += Path.DirectorySeparatorChar.ToString();
            }

            List<Tuple<bool, string>> removeList = new List<Tuple<bool, string>>();

            List<string> dirs = new List<string>(Directory.EnumerateDirectories(compressFolder, "*.*", SearchOption.AllDirectories));
            dirs.Sort((x, y) => y.CompareTo(x));
            using (ZipOutputStream zipOutput = new ZipOutputStream(File.Create(zipFileName)))
            {
                zipOutput.SetLevel(compressionLevel);
                foreach (string dir in dirs)
                {
                    WriteEntry(zipOutput, compressFolder, false, dir);
                }

                dirs.Add(compressFolder);
                foreach (string dir in dirs)
                {
                    IEnumerable<string> fileNames = Directory.EnumerateFiles(dir, "*.*", SearchOption.TopDirectoryOnly);
                    foreach (string filename in fileNames)
                    {
                        if (string.Compare(filename, zipFileName) == 0)
                        {
                            continue;
                        }
                        WriteEntry(zipOutput, compressFolder, true, filename);
                        if (removeZippedFolder)
                        {
                            removeList.Add(new Tuple<bool, string>(true, filename));
                        }
                    }
                    if (removeZippedFolder)
                    {
                        removeList.Add(new Tuple<bool, string>(false, dir));
                    }
                }
                zipOutput.Flush();
            }

            foreach(Tuple<bool, string> entry in removeList)
            {
                if (entry.Item1)
                {
                    File.Delete(entry.Item2);
                }
                else
                {
                    if (Directory.GetFileSystemEntries(entry.Item2).Length == 0)
                    {
                        Directory.Delete(entry.Item2);
                    }
                }
            }
        }

        private static void WriteEntry(ZipOutputStream zipOutput, string compressFolder, bool isFile, string item)
        {
            string zipName = item.Replace(compressFolder, "");
            zipName = isFile ? zipName : string.Format($"{zipName}/");
            var fileEntry = new ZipEntry(zipName)
            {
                DateTime = DateTime.Now
            };
            zipOutput.PutNextEntry(fileEntry);
            if (!isFile)
            {
                return;
            }
            byte[] buffer = new byte[1024 * 1024 * 10];
            using (var fileStream = File.OpenRead(item))
            {
                int sourceBytes;
                do
                {
                    sourceBytes = fileStream.Read(buffer, 0, buffer.Length);
                    zipOutput.Write(buffer, 0, sourceBytes);
                } while (sourceBytes > 0);
            }
        }

    }
}
