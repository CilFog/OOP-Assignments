using System;
namespace Lecture2.Classes
{
    public class Person
    {
        public Person(string firstname, string lastname, int age)
        {
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
        }

        public int Age;


        public string Firstname
        {
            get => _Firstname;
            set => _Firstname = value ?? throw new ArgumentNullException("Person cannot be null");

        }

        public string Lastname
        {
            get => _Lastname;
            set => _Lastname = value ?? throw new ArgumentNullException("Person cannot be null");
        }

        private string _Firstname;
        private string _Lastname;


    }
}

