using System;
using Lecture5.Classes;

namespace Lecture5
{
    class Program
    {
        static void Main(string[] args)
        {
            BankAccount account = new BankAccount(5);

            account.Withdraw(6);
        }

        static void ReadInt()
        { 
            long integer;
            
            Console.WriteLine("Write an integer");
            string input = Console.ReadLine();

            try
            {
                integer = long.Parse(input);
            }
            catch
            {
                Console.WriteLine("Wrong type of input");
            }
        }
    }
}
