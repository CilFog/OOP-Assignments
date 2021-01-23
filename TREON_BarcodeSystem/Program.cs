using System;
using TREON_BarcodeSystem.Classes;

namespace TREON_BarcodeSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("hshsh", "Cecilie", "Fog", "Ceciliemwf@gmail.com");

            Console.WriteLine(user.Balance);
            Console.WriteLine(user.Id);
            Console.WriteLine(user.Username);
        }
    }
}
