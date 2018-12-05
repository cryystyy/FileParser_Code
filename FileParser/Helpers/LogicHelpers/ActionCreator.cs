using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using FileParser.Helpers.LogicHelpers.Actions;

namespace FileParser.Helpers.LogicHelpers
{
    public class ActionCreator
    {
        private readonly IBaseHelper _actionHelper;
        private Base _action;

        public ActionCreator(IBaseHelper helper)
        {
            _actionHelper = helper;
        }

        public IEnumerable<string> DoAction(string command, string scanPath)
        {
            _action = Activator.CreateInstance(GetActionType(command), _actionHelper, scanPath, false) as Base;
            return _action.GetFiles(scanPath);
        }

        public IEnumerable<string> DoAction(string command, string folderPath, IEnumerable<string> files)
        {
            _action = Activator.CreateInstance(GetActionType(command), _actionHelper, files) as Base;
            return _action.GetFiles(folderPath);
        }

        public IEnumerable<string> DoActionAsync(string command, string scanPath)
        {
            _action = Activator.CreateInstance(GetActionType(command), _actionHelper) as Base;
            return _action.GetFilesAsync(scanPath);
        }

        private static Type GetActionType(string command)
        {
            var actionType = typeof(Base);
            var attributeType = typeof(ActionAttrib);
            return Assembly
                .GetAssembly(actionType)
                .GetTypes()
                .FirstOrDefault(t => t.IsClass && !t.IsAbstract && t.IsSubclassOf(actionType) &&
                                     ((ActionAttrib) t.GetCustomAttribute(attributeType)).Command == command.ToLower());
        }
    }
}