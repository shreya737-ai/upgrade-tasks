using System;
using System.IO;

namespace week5_task4
{
    internal class Program3
    {
        static void Main(string[] args)
        {
            try
            {
                // 1. Accept root directory path from user
                Console.Write("Enter root directory path: ");
                string rootPath = Console.ReadLine();

                // Check if directory exists
                if (!Directory.Exists(rootPath))
                {
                    Console.WriteLine("Invalid directory path. Folder does not exist.");
                    return;
                }

                // Create DirectoryInfo object
                DirectoryInfo rootDirectory = new DirectoryInfo(rootPath);

                // 2. Get all subdirectories inside root folder
                DirectoryInfo[] subDirectories = rootDirectory.GetDirectories();

                // Check if subdirectories exist
                if (subDirectories.Length == 0)
                {
                    Console.WriteLine("No subdirectories found in the given root directory.");
                    return;
                }

                Console.WriteLine("\nSubdirectories and File Count:");
                Console.WriteLine("-----------------------------------");

                // 3. Display folder names and number of files in each directory
                foreach (DirectoryInfo dir in subDirectories)
                {
                    FileInfo[] files = dir.GetFiles();

                    Console.WriteLine("Folder Name : " + dir.Name);
                    Console.WriteLine("File Count  : " + files.Length);
                    Console.WriteLine(new string('-', 35));
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Error: You do not have permission to access one or more directories.");
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.WriteLine("Error: Directory not found.");
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("File system error occurred.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error occurred.");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("\nProgram ended.");
            Console.ReadLine();
        }
    }
}