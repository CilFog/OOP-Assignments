using System;

namespace Lecture3 
{
    public class Car : IComparable
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public double Price { get; set; }

        public int CompareTo(object obj)
        {
            return Price.CompareTo(((Car)obj).Price);
        }
    }
}