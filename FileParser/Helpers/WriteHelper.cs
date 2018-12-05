using System;
using System.IO;
using FileParser.Helpers.LogicHelpers;

namespace FileParser.Helpers
{
    public class WriteHelper
    {
        public WriteHelper(string folderPath, string results, string command)
        {
            ScanLocation = folderPath;
            ResultLocation = results;
            Command = command;
        }

        private string ScanLocation { get; }

        private string ResultLocation { get; }

        private string Command { get; }

        public bool WriteFile()
        {
            if (Directory.Exists(Path.GetDirectoryName(ScanLocation)))
            {
                var list = new ActionCreator(new BaseHelper()).DoAction(Command, ScanLocation);
                File.WriteAllLines(ResultLocation, list);
                return true;
            }

            Console.WriteLine("Folder not found");
            return false;
        }
    }
}