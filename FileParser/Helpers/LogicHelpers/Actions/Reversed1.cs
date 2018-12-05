using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileParser.Helpers.LogicHelpers.Actions
{
    [ActionAttrib("reversed1")]
    internal class Reversed1 : Base
    {
        public Reversed1(IBaseHelper helper, string scanPath, bool isAsync) : base(helper, scanPath, isAsync)
        {
        }

        public Reversed1(IBaseHelper helper, IEnumerable<string> files) : base(helper, files)
        {
        }

        public override IEnumerable<string> GetFiles(string scanPath)
        {
            var files = Files.Select(f => ActionHelper.GetRelativePath(f, scanPath));
            foreach (var file in files)
            {
                var pathParts = file.Split("/".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                yield return string.Join(@"\", pathParts.Reverse());
            }
        }

        public override IEnumerable<string> GetFilesAsync(string scanPath)
        {
            return Task.Run(() => GetFiles(scanPath)).GetAwaiter().GetResult();
        }
    }
}