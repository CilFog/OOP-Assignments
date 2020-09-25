using System;

namespace Lecture1
{
    public static class Groups
    {
        static int GetUsersInputNumber()
        {
            int number = int.Parse(Console.ReadLine());

            return number;
        }

        static int GetUsersGroupmembers()
        {
            Console.WriteLine("Enter how many groupmembers do you have:");

            int amountOfGroupmembers = int.Parse(Console.ReadLine());

            return amountOfGroupmembers;
        }

        static string[] GetGroupmemberNames(int AmountOfGroupmembers)
        {
            string[] groupmembers = new string[AmountOfGroupmembers];

            int groupmemberName = 0;

            Console.WriteLine("Enter your groupmembers names");

            while (groupmemberName < AmountOfGroupmembers)
            {
                groupmembers[groupmemberName] = Console.ReadLine();

                groupmemberName++;

            }

            return groupmembers;

        }

        static void PrintGroupmemberNames(string[] groupmembers)
        {
            Console.WriteLine("This is your members");
            foreach(string member in groupmembers)
            {
                Console.WriteLine(member);
            }
        }

        static string[] EnterGroupmemberNames()
        {
            Console.WriteLine("Enter the names of your groupmembers");

            string names = Console.ReadLine();

            string[] groupmembers = names.Split(' ');

            return groupmembers;

        }
    }
}