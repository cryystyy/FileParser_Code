using System.Collections.Generic;

namespace FileParser.Helpers.LogicHelpers.Actions
{
    public abstract class Base
    {
        public readonly string FileExtension;
        protected IBaseHelper ActionHelper;
        protected IEnumerable<string> Files;

        protected Base(IBaseHelper helper, string scanPath, bool isAsync = false)
        {
            FileExtension = "*";
            ActionHelper = helper;
            Files = isAsync ? helper.GetAllFilesFromFolderAsync(scanPath, FileExtension) : helper.GetAllFilesFromFolder(scanPath, FileExtension);
        }

        protected Base(IBaseHelper helper, IEnumerable<string> files)
        {
            ActionHelper = helper;
            Files = files;
        }

        public abstract IEnumerable<string> GetFiles(string scanPath);

        public abstract IEnumerable<string> GetFilesAsync(string scanPath);
    }
}