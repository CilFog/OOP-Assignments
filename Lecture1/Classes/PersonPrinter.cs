using System;

namespace Lecture1.Classes
{
    public class PersonPrinter
    {
        public string PrintInformation(Person person)
        {
            return $"Firstname: {person.Firstname}, Lastname: {person.Lastname}, Age: {person.Age}";
        }

        public void PrintFamilyTree(Person person)
        {
            if(person == null)
            {
                return; 
            }

            Console.WriteLine(PrintInformation(person));
            PrintFamilyTree(person.PersonFather);
            PrintFamilyTree(person.PersonsMother);

        }
    }
}
