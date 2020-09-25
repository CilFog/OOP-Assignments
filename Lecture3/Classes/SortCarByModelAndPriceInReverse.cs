using System;
using System.Collections.Generic;

namespace Lecture3.Classes
{
    public class SortCarByModelAndPriceInReverse : IComparer<Car>
    {
        int IComparer<Car>.Compare(Car x, Car y)
        {
            int result = -(x.Model.CompareTo(y.Model));

            if(result == 0)
            {
                result = -(x.Price.CompareTo(y.Price));
            }

            return result;
        }
    }
}
