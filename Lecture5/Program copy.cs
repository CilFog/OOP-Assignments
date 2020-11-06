using System;

namespace Lecture5
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                ReadInt();
            }
        }

        static void ReadInt()
        { 
            int integer;

            Console.WriteLine("Write an integer");
            string input = Console.ReadLine();

            try
            {
                integer = int.Parse(input);
            }
            catch
            {
                Console.WriteLine("Wrong type of input");
            }
        }
    }
}
