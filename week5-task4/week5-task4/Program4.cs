using System;
using System.IO;

namespace week5_task4
{
    internal class Program4
    {
        static void Main(string[] args)
        {
            try
            {
                // 1. Retrieve all system drives
                DriveInfo[] drives = DriveInfo.GetDrives();

                Console.WriteLine("Drive Health Information");
                Console.WriteLine("------------------------------------------");

                // 2. Process each drive using loop
                foreach (DriveInfo drive in drives)
                {
                    // Ensure drive is ready before accessing properties
                    if (drive.IsReady)
                    {
                        long totalSize = drive.TotalSize;
                        long freeSpace = drive.AvailableFreeSpace;

                        // Calculate free space percentage
                        double freePercentage = (double)freeSpace / totalSize * 100;

                        Console.WriteLine("Drive Name           : " + drive.Name);
                        Console.WriteLine("Drive Type           : " + drive.DriveType);
                        Console.WriteLine("Total Size           : " + totalSize + " bytes");
                        Console.WriteLine("Available Free Space : " + freeSpace + " bytes");

                        // 3. Warning if free space is below 15%
                        if (freePercentage < 15)
                        {
                            Console.WriteLine("Warning: Low disk space! Free space is below 15%.");
                        }

                        Console.WriteLine(new string('-', 45));
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("File system error occurred.");
                Console.WriteLine(ex.Message);
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Access denied while reading drive information.");
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