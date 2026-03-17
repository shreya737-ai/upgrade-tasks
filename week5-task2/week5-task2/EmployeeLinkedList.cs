using System;

namespace EmployeeLinkedList
{
    // Node class
    class Node
    {
        public int EmployeeId;
        public string EmployeeName;
        public Node Next;

        public Node(int id, string name)
        {
            EmployeeId = id;
            EmployeeName = name;
            Next = null;
        }
    }

    // Singly Linked List class
    class EmployeeLinkedList
    {
        private Node head;

        // Insert at beginning
        public void InsertAtBeginning(int id, string name)
        {
            Node newNode = new Node(id, name);
            newNode.Next = head;
            head = newNode;
        }

        // Insert at end
        public void InsertAtEnd(int id, string name)
        {
            Node newNode = new Node(id, name);

            if (head == null)
            {
                head = newNode;
                return;
            }

            Node temp = head;
            while (temp.Next != null)
            {
                temp = temp.Next;
            }

            temp.Next = newNode;
        }

        // Delete by employee ID
        public void DeleteById(int id)
        {
            if (head == null)
            {
                Console.WriteLine("Employee list is empty.");
                return;
            }

            // If head node needs to be deleted
            if (head.EmployeeId == id)
            {
                head = head.Next;
                Console.WriteLine($"Employee with ID {id} deleted.");
                return;
            }

            Node temp = head;
            while (temp.Next != null && temp.Next.EmployeeId != id)
            {
                temp = temp.Next;
            }

            // Employee not found
            if (temp.Next == null)
            {
                Console.WriteLine($"Employee with ID {id} not found.");
                return;
            }

            // Delete node
            temp.Next = temp.Next.Next;
            Console.WriteLine($"Employee with ID {id} deleted.");
        }

        // Display employee list
        public void Display()
        {
            if (head == null)
            {
                Console.WriteLine("Employee list is empty.");
                return;
            }

            Node temp = head;
            while (temp != null)
            {
                Console.WriteLine($"{temp.EmployeeId} - {temp.EmployeeName}");
                temp = temp.Next;
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            EmployeeLinkedList empList = new EmployeeLinkedList();

            // Insert employees
            empList.InsertAtEnd(101, "John");
            empList.InsertAtEnd(102, "Sara");
            empList.InsertAtEnd(103, "Mike");

            Console.WriteLine("Employee List Before Deletion:");
            empList.Display();

            // Delete employee with ID 102
            empList.DeleteById(102);

            Console.WriteLine("\nEmployee List After Deletion:");
            empList.Display();
        }
    }
}