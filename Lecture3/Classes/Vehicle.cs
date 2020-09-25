using System;
namespace Lecture3.Classes
{
    public class Vehicle
    {
        protected int registrationNumber;
        protected double maxVelocity;
        protected decimal value;
        private object p;

        public Vehicle(object p)
        {
            this.p = p;
        }

        public Vehicle(int registrationNumber, double maxVelocity,decimal value)
        {
            this.registrationNumber = registrationNumber;
            this.maxVelocity = maxVelocity;
            this.value = value;
        }

        public int RegistrationNumber
        {
            get
            {
                return registrationNumber;
            }
        }
    }
}
