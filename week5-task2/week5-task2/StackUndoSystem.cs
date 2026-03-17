using System;

namespace StackUndoSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] stack = new string[10]; // Array-based stack
            int top = -1; // Stack is empty initially

            // Perform operations
            Push(stack, ref top, "Type A");
            Display(stack, top);

            Push(stack, ref top, "Type B");
            Display(stack, top);

            Push(stack, ref top, "Type C");
            Display(stack, top);

            Pop(stack, ref top); // Undo
            Display(stack, top);

            Pop(stack, ref top); // Undo
            Display(stack, top);

            // Final state
            Console.WriteLine("\nCurrent State After Operations:");
            if (top >= 0)
            {
                Console.WriteLine(stack[top]);
            }
            else
            {
                Console.WriteLine("No actions available");
            }
        }

        // Push operation
        static void Push(string[] stack, ref int top, string action)
        {
            if (top == stack.Length - 1)
            {
                Console.WriteLine("Stack Overflow! Cannot add more actions.");
                return;
            }

            top++;
            stack[top] = action;
            Console.WriteLine($"Action Added: {action}");
        }

        // Pop operation (Undo)
        static void Pop(string[] stack, ref int top)
        {
            if (top == -1)
            {
                Console.WriteLine("Stack Underflow! No actions to undo.");
                return;
            }

            Console.WriteLine($"Undo Action: {stack[top]}");
            top--;
        }

        // Display current stack state
        static void Display(string[] stack, int top)
        {
            Console.WriteLine("Current Stack State:");
            if (top == -1)
            {
                Console.WriteLine("Empty");
            }
            else
            {
                for (int i = 0; i <= top; i++)
                {
                    Console.WriteLine(stack[i]);
                }
            }
            Console.WriteLine();
        }
    }
}