using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileParser.Helpers.LogicHelpers.Actions
{
    [ActionAttrib("all")]
    public class All : Base
    {
        public All(IBaseHelper helper, string scanPath, bool isAsync) : base(helper, scanPath, isAsync)
        {
        }

        public All(IBaseHelper helper, IEnumerable<string> files) : base(helper, files)
        {
        }

        public override IEnumerable<string> GetFiles(string scanPath)
        {
            return Files.Select(f => ActionHelper.GetRelativePath(f, scanPath).Replace(@"/", @"\"));
        }

        public override IEnumerable<string> GetFilesAsync(string scanPath)
        {
            return Task.Run(() => { return Files.Select(f => ActionHelper.GetRelativePath(f, scanPath)); }).GetAwaiter()
                .GetResult();
        }
    }
}