using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task1
{
    internal class Number_Analysis_Using_Loops
    {
        static void Main()
        {
            // Accept number from user
            Console.Write("Enter Number: ");
            int N = int.Parse(Console.ReadLine());

            int evenCount = 0;
            int oddCount = 0;
            int sum = 0;

            // Loop from 1 to N
            for (int i = 1; i <= N; i++)
            {
                sum += i;

                if (i % 2 == 0)
                {
                    evenCount++;
                }
                else
                {
                    oddCount++;
                }
            }

            // Display results
            Console.WriteLine("Even Count: " + evenCount);
            Console.WriteLine("Odd Count: " + oddCount);
            Console.WriteLine("Sum: " + sum);
        }
    }
}
