using System.Collections.Generic;

namespace FileParser.Helpers
{
    public interface IBaseHelper
    {
        string GetRelativePath(string absoluteScanPath, string scanPath);
        IEnumerable<string> GetAllFilesFromFolder(string folderPath, string pattern);
        IEnumerable<string> GetAllFilesFromFolderAsync(string folderPath, string pattern);
    }
}