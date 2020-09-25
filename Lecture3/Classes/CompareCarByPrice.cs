using System;
using System.Collections.Generic;

namespace Lecture3.Classes
{
    public class CompareCarByPrice : IComparer<Car>
    {
        int IComparer<Car>.Compare(Car x, Car y)
        {
            return x.Price.CompareTo(y.Price);
        }
    }
}
