using System;

namespace Lecture5.Classes
{
    public class BankAccount
    {
        public BankAccount(double balance)
        {
            if(balance < 0)
            {
                throw new InsufficientFundsException(balance);
            }
            Balance = balance;
        }

        private double Balance { get; set; }

        public void Withdraw(double amount)
        {
            if ((Balance - amount) < 0)
            {
                throw new InsufficientFundsException(Balance - amount);
            }
            else
            {
                Balance -= amount;
            }
        }

        public void Deposit(double amount)
        {
            Balance += amount;
        }
    }
}
