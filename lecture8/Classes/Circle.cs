using System;
namespace lecture8.Classes
{
    public class Circle
    {
        public Circle(CircleCenter center, double radius)
        {
            if(radius <= 0)
            {
                throw new ArgumentOutOfRangeException("radius", radius, "A radius cannot be negative or zero");
            }

            Center = center;
            Radius = radius;
        }

        public CircleCenter Center { get; set; }
        public double Radius { get; set; }

        public bool CheckIfPointIsInsideCircle(double X, double Y)
        {
            double distance = Math.Sqrt(Math.Pow(X - Center.X, 2) + Math.Pow(Y - Center.Y, 2));

            if(distance > Radius)
            {
                return true;
            }

            else if(distance == Radius)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckIfCircleOverlapEachOther(Circle Othercircle)
        {
            double distance = Math.Sqrt(Math.Pow(Othercircle.Center.X - Center.X, 2) + Math.Pow(Othercircle.Center.Y - Center.Y, 2));
            if(distance <= Radius)
            {
                return true;
            }

            return false;
        }
    }
}
