using System;

namespace Lecture5.Classes
{
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(double balance)
        {
            if(balance < 0)
            {
                Console.WriteLine("Cannot have a negative balance");
            }
        }
    }
}
