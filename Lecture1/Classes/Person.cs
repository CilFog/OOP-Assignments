using System;

namespace Lecture1.Classes
{
    public class Person
    {
        public Person(string firstname, string lastname, int age, Person personFather, Person personsMother)
        {
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
            PersonFather = personFather;
            PersonsMother = personsMother;
            Id = UpdateId;
            UpdateId++;

        }
        public Person(string firstname, string lastname, int age)
        {
            Firstname = firstname;
            Lastname = lastname;
            Age = age;
            Id = UpdateId;
            UpdateId++;

        }

        public int Age;
        public int Id { get; set; }

        public static int UpdateId = 0;
        
        public string Firstname
        {
            get => _Firstname;
            set => _Firstname = value ?? throw new ArgumentNullException("Person cannot be null");
         
        }

        public string Lastname
        {
            get => _Lastname;
            set => _Lastname = value ?? throw new ArgumentNullException(nameof(value));
        }

        public Person PersonFather
        {
            get => _PersonsFather;
            set => _PersonsFather = value ?? throw new ArgumentNullException("Father cannot be null");
        }

        public Person PersonsMother
        {
            get => _PersonsMother;
            set => _PersonsMother = value ?? throw new ArgumentNullException("Mother cannot be null");
        }

     

        private string _Firstname;
        private string _Lastname;
        private Person _PersonsFather;
        private Person _PersonsMother;
    }
}
