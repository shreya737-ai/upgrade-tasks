using System;

namespace task1
{
    internal class Simple_Calculator_Using_Switch
    {
        static void Main()
        {
            Console.Write("Enter First Number: ");
            double num1 = double.Parse(Console.ReadLine());

            // Accept second number
            Console.Write("Enter Second Number: ");
            double num2 = double.Parse(Console.ReadLine());


            Console.Write("Enter Operator (+, -, *, /): ");
            char op = Convert.ToChar(Console.ReadLine());

            double result;


            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    Console.WriteLine("Result: " + result);
                    break;

                case '-':
                    result = num1 - num2;
                    Console.WriteLine("Result: " + result);
                    break;

                case '*':
                    result = num1 * num2;
                    Console.WriteLine("Result: " + result);
                    break;

                case '/':
                    if (num2 == 0)
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                    }
                    else
                    {
                        result = num1 / num2;
                        Console.WriteLine("Result: " + result);
                    }
                    break;

                default:
                    Console.WriteLine("Invalid operator!");
                    break;
            }
        }
    }
