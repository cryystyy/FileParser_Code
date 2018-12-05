using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileParser.Helpers.LogicHelpers
{
    public class ActionAttrib: System.Attribute

    {
        public readonly string Command;

        public ActionAttrib(string command)
        {
            Command = command;
        }
    }
}
