using System;
using lecture8.Classes;

namespace lecture8
{
    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(new CircleCenter(0, 0), 10);
            Console.WriteLine($"The radius of the circle is {circle.Radius}");
            Console.WriteLine($"The center of the circle is ({circle.Center.X}, {circle.Center.Y})");
        }
    }
}
