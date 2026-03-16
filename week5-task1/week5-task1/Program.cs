using System;

namespace week5_task1
{
    internal class Program
    {
        static void Main()
        {
            // Creating BankAccount object
            BankAccount account = new BankAccount("ACC1001", 0);

            // Sample Input
            account.Deposit(5000);
            account.Withdraw(2000);
        }
    }

}

