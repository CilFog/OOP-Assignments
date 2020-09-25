using System;
using System.IO;

namespace Lecture1.Classes
{
    public static class DirectoryPrinter
    {
        public static void PrintFilesInDirectory(DirectoryInfo source)
        {
            foreach (FileInfo file in source.GetFiles()) 
            {
                Console.WriteLine($"File: {file.Name}");
                Console.WriteLine($"Size: {file.Length} bytes");
            }
        }

        public static void PrintDirectoryInDirectories(DirectoryInfo source)
        {
            foreach (DirectoryInfo directory in source.GetDirectories())
            {
                Console.WriteLine($"Subdirectory: {directory.Name}");
                Console.WriteLine($"Number of files: {directory.GetFileSystemInfos().Length}");
            }
        }
    }
}
