using System;

namespace Lecture2.Classes
{
    public class BankAccount
    {
        public BankAccount(double balance)
        {

            if(balance < 0)
            {
                throw new ArgumentException("Balance must be greater than 0");
            }

            if (balance > 250000)
            {
                throw new ArgumentException("Balance must not be greater than 250000");
            }

            Balance = balance;
        }

        public double Balance { get; private set; }
        private double BorrowingRate = 0.1;
        private double SavingsRate = 0.01;

        public bool DepositMoney(double depositMoney)
        {
            if (depositMoney <= 0)
            {
                throw new ArgumentException("You must deposit somthing greather than 0");
            }
            if ((depositMoney + Balance) > 250000)
            {
                throw new ArgumentException($"Your deposit is too great. Your current balance is {Balance} and will exceed 250.000, if you deposit {depositMoney}.");
            }

            Balance += depositMoney;

            return true;
        }

        public bool WithdrawMoney(double WithdrawelMoney)
        {
            if (WithdrawelMoney <= 0)
            {
                throw new ArgumentException("You can't withdraw something you don't have");
            }

            if ((Balance - WithdrawelMoney) < (-100000))
            {
                throw new ArgumentException($"Your withdrawel is too great. Your current balance is {Balance} and will go below 100000, if you withdraw {WithdrawelMoney}");
            }
            Balance -= WithdrawelMoney;

            return true;
        }

        public bool ChangeBorrowingRate(double changeRateWith)
        {
            if(((BorrowingRate - changeRateWith) < 0.06))
            {
                throw new ArgumentException("Borrowingrate must not be lower than 6%");
            }
            BorrowingRate += changeRateWith;

            return true;
        }

        public bool ChangeSavingsRate(double changeRateWith)
        {
            if(((SavingsRate + changeRateWith) > 0.02))
            {
                throw new ArgumentException("Savingsrate must not be greater than 2%");
            }
            SavingsRate += changeRateWith;

            return true;
        }
    }

}
