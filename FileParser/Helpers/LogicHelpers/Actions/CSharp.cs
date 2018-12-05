using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileParser.Helpers.LogicHelpers.Actions
{
    [ActionAttrib("cs")]
    public class CSharp : Base
    {
        public CSharp(IBaseHelper helper, string scanPath, bool isAsync) : base(helper, scanPath, isAsync)
        {
            ActionHelper = helper;
            if (isAsync)
                Files = helper.GetAllFilesFromFolderAsync(scanPath, "*.cs");
            else
                Files = helper.GetAllFilesFromFolder(scanPath, "*.cs");
        }

        public CSharp(IBaseHelper helper, IEnumerable<string> files) : base(helper, files)
        {
        }

        public override IEnumerable<string> GetFiles(string scanPath)
        {
            return Files.Select(f => $"{ActionHelper.GetRelativePath(f, scanPath)} /");
            ;
        }

        public override IEnumerable<string> GetFilesAsync(string scanPath)
        {
            return Task.Run(() =>
            {
                return Files.Select(f => $"{ActionHelper.GetRelativePath(f, scanPath)} /");
            }).GetAwaiter().GetResult();
        }
    }
}