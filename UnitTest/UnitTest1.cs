using System.Collections.Generic;
using System.Linq;
using FileParser.Helpers;
using FileParser.Helpers.LogicHelpers;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ActionCppTest()
        {
            IBaseHelper baseHelper = new BaseHelper();
            var list = new ActionCreator(baseHelper).DoAction("cs", @"C:\folder\", new List<string>
            {
                @"C:\folder\file.txt",
                @"C:\folder\file2.cs",
                @"C:\folder\sub_folder\file3.cs"
            });
            list.Count().Should().Be(3);
            list.All(f => f.EndsWith(" /")).Should().BeTrue();
        }

        [TestMethod]
        public void ActionAllTest()
        {
            IBaseHelper baseHelper = new BaseHelper();
            var list = new ActionCreator(baseHelper).DoAction("all", @"C:\folder\", new List<string>
            {
                @"C:\folder\file1.txt",
                @"C:\folder\file2.cs",
                @"C:\folder\sub_folder\file3.cs",
                @"C:\folder\sub_foler\file1.txt"
            });
            list.Count().Should().Be(4);
            list.All(f => !f.Contains(@"C:\")).Should().BeTrue();
        }

        [TestMethod]
        public void ActionReversed1()
        {
            IBaseHelper baseHelper = new BaseHelper();
            var list = new ActionCreator(baseHelper).DoAction("reversed1", @"C:\stuff\", new List<string>
            {
                @"C:\stuff\te\t.dat"
            });
            list.First().Should().Be(@"t.dat\te");
        }

        [TestMethod]
        public void ActionReversed2()
        {
            IBaseHelper baseHelper = new BaseHelper();
            var list = new ActionCreator(baseHelper).DoAction("reversed2", @"C:\stuff\", new List<string>
            {
                @"c:\stuff\te\t.dat"
            });
            list.First().Should().Be(@"dat.t\te");
        }
    }
}