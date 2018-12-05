using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace FileParser.Helpers
{
    public class BaseHelper : IBaseHelper
    {
        public string GetRelativePath(string absoluteFilePath, string scanPath)
        {
            return Uri.UnescapeDataString(new Uri(scanPath).MakeRelativeUri(new Uri(absoluteFilePath)).ToString());
        }

        public IEnumerable<string> GetAllFilesFromFolder(string scanPath, string pattern)
        {
            return Directory.EnumerateFiles(scanPath, pattern, SearchOption.AllDirectories);
        }

        public IEnumerable<string> GetAllFilesFromFolderAsync(string scanPath, string pattern)
        {
            return Task.Run(() =>
                    Directory.EnumerateFiles(scanPath, pattern, SearchOption.AllDirectories)
                )
                .GetAwaiter().GetResult();
        }
    }
}