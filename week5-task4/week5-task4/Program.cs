using System;
using System.IO;
using System.Text;

namespace week5_task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = "logmessages.txt";

            try
            {
                char choice;

                do
                {
                    // 1. Accept message from user
                    Console.Write("Enter a log message: ");
                    string message = Console.ReadLine();

                    // Add new line after each message
                    string logEntry = message + Environment.NewLine;

                    // Convert string to bytes
                    byte[] data = Encoding.UTF8.GetBytes(logEntry);

                    // 2 & 3. Write and append messages using FileStream
                    using (FileStream fs = new FileStream(filePath, FileMode.Append, FileAccess.Write))
                    {
                        fs.Write(data, 0, data.Length);
                    }

                    // 4. Confirmation message
                    Console.WriteLine("Message written successfully to file.");

                    Console.Write("Do you want to add another message? (y/n): ");
                    choice = Convert.ToChar(Console.ReadLine().ToLower());

                } while (choice == 'y');
            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("Error: You do not have permission to access the file.");
                Console.WriteLine(ex.Message);
            }
            catch (IOException ex)
            {
                Console.WriteLine("File error occurred.");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unexpected error occurred.");
                Console.WriteLine(ex.Message);
            }

            Console.WriteLine("Program ended.");
            Console.ReadLine();
        }
    }
}