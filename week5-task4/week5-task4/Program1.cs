using System;
using System.IO;

namespace week5_task4
{
    internal class Program1
    {
        static void Main(string[] args)
        {
            try
            {
                // 1. Accept folder path from user
                Console.Write("Enter folder path: ");
                string folderPath = Console.ReadLine();

                // Check if directory exists
                if (!Directory.Exists(folderPath))
                {
                    Console.WriteLine("Invalid directory path. Folder does not exist.");
                    return;
                }

                // Get all files from the folder
                string[] files = Directory.GetFiles(folderPath);

                // 3. Count total number of files
                Console.WriteLine($"\nTotal number of files: {files.Length}\n");

                // 2. Display file name, size, and creation date
                foreach (string file in files)
                {
                    FileInfo fileInfo = new FileInfo(file);

                    Console.WriteLine("File Name      : " + fileInfo.Name);
                    Console.WriteLine("File Size      : " + fileInfo.Length + " bytes");
                    Console.WriteLine("Creation Date  : " + fileInfo.CreationTime);
                    Console.WriteLine(new string('-', 40));
                }
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Error: You do not have permission to access this folder.");
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