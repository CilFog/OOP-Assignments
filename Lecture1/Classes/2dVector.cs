using System;
namespace Lecture1.Classes
{
    public class _dVector
    {
        public _dVector(double x, double y)
        {
            this.x = x;
            this.y = y;
        }

        public double[] Add(double[] b)
        {
            double[] a = new double[] { x, y };


            if (a.Length != b.Length)
            {
                throw new ArgumentException("Both vectors must be of same dimention");
            }

            for (int element = 0; element < a.Length; element++)
            {
                a[element] += b[element];
            }

            return a;
        }


        public double[] Substract(double[] b)
        {
            double[] a = new double[] { x, y };


            if (a.Length != b.Length)
            {
                throw new ArgumentException("Both vectors must be of same dimention");
            }

            for (int element = 0; element < a.Length; element++)
            {
                a[element] -= b[element];
            }

            return a;
        }

        public double[] Multiplication(double scalar)
        {
            double[] a = new double[] { x, y };

            for (int element = 0; element < a.Length; element++)
            {
                a[element] *= scalar;
            }

            return a;
        }

        public double CrossProduct(double[] b)
        {
            double[] a = new double[] { x, y };

            if (a.Length != b.Length)
            {
                throw new ArgumentException("Both vectors must be of same dimention");
            }

            double sum = 0.0;

            for (int element = 0; element < a.Length; element++)
            {
                sum += (a[element] * b[element]);
            }

            return sum;
        }

        public double x { get; set; }
        public double y { get; set; }
    }
}
