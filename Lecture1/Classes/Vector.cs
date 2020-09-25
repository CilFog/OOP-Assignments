using System;

namespace Lecture1.Classes
{
    public class Vector
    {
        public static double[] Addition(double[] a, double[] b)
        {
            double[] sum = new double[a.Length];

            if(a.Length != b.Length)
            {
                throw new ArgumentException("Both vectors must be of same dimention");
            }

            for(int element = 0; element < a.Length; element++)
            {
                sum[element] = 0;
                sum[element] = a[element] + b[element];
            }

            return sum;
        }

        public static double[] Substraction(double[] a, double[] b)
        {
            double[] sum = new double[a.Length];

            if (a.Length != b.Length)
            {
                throw new ArgumentException("Both vectors must be of same dimention");
            }

            for (int element = 0; element < a.Length; element++)
            {
                sum[element] = 0;
                sum[element] = a[element] - b[element];
            }

            return sum;
        }

        public static double[] Multiplication(double scalar, double[] vector)
        {
            for(int element = 0; element < vector.Length; element++)
            {
                vector[element] *= scalar;
            }

            return vector;
        }

        public static double CrossProduct(double[] a, double[] b)
        {

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
    }
}
