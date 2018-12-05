using System;
using FileParser.Helpers;

namespace FileParser
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                args = new[] {@"C:\"};
                Console.WriteLine("Called without any parameters, will scan by default drive C:");
            }

            var resultsFilePath = "results.txt";
            var command = "all";

            switch (args.Length)
            {
                case 3:
                    resultsFilePath = args[2];
                    break;
                case 2:
                    command = args[1];
                    break;
            }

            var writer = new WriteHelper(args[0], resultsFilePath, command);

            Console.WriteLine("Started parsing the files, hold on to your seat");
            Console.WriteLine(writer.WriteFile() ? "Files have been written successfully" : "Failed to write files");

            Console.ReadKey();
        }
    }
}