using System;
using Lecture1.Classes;

namespace Lecture1
{
    class Program
    {
        static void Main(string[] args)
        {
            Person person = new Person("Cecilie", "Fog", 21);
            Console.WriteLine(person.Firstname);
        }
    }
}
