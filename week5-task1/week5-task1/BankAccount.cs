using System;


namespace week5_task1
{
    internal class BankAccount
    {
        private string accountNumber;
        private double balance;

        // Property for Account Number
        public string AccountNumber
        {
            get { return accountNumber; }
            set { accountNumber = value; }
        }

        // Property for Balance (Read-only outside the class)
        public double Balance
        {
            get { return balance; }
            private set { balance = value; }
        }

        // Constructor
        public BankAccount(string accNo, double initialBalance)
        {
            accountNumber = accNo;

            if (initialBalance >= 0)
                balance = initialBalance;
            else
                balance = 0;
        }

        // Deposit Method
        public void Deposit(double amount)
        {
            if (amount > 0)
            {
                balance += amount;
                Console.WriteLine("Deposit Successful!");
                Console.WriteLine("Updated Balance = " + balance);
            }
            else
            {
                Console.WriteLine("Invalid deposit amount!");
            }
        }

        // Withdraw Method
        public void Withdraw(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Invalid withdrawal amount!");
            }
            else if (amount > balance)
            {
                Console.WriteLine("Insufficient balance!");
            }
            else
            {
                balance -= amount;
                Console.WriteLine("Withdrawal Successful!");
                Console.WriteLine("Current Balance = " + balance);
            }
        }
    }
}
