using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileParser.Helpers.LogicHelpers.Actions
{
    [ActionAttrib("reversed2")]
    public class Reversed2 : Base
    {
        public Reversed2(IBaseHelper helper, string scanPath, bool isAsync) : base(helper, scanPath, isAsync)
        {
        }

        public Reversed2(IBaseHelper helper, IEnumerable<string> files) : base(helper, files)
        {
        }

        public override IEnumerable<string> GetFiles(string scanPath)
        {
            return Files.Select(f => ReverseString(ActionHelper.GetRelativePath(f, scanPath).Replace(@"/", @"\")));
        }

        public override IEnumerable<string> GetFilesAsync(string scanPath)
        {
            return Task.Run(() =>
            {
                return Files.Select(f =>
                    ReverseString(ActionHelper.GetRelativePath(f, scanPath).Replace(@"/", @"\")));
            }).GetAwaiter().GetResult();
        }

        private static string ReverseString(string input)
        {
            var charArray = input.ToCharArray();
            Array.Reverse(charArray);
            return new string(charArray);
        }
    }
}