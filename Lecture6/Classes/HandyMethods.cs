using System;
using System.Collections.Generic;

namespace Lecture6.Classes
{
    public class HandyMethods : IComparable<T>
    {
        public HandyMethods()
        {
        }

        public T Max(List<T> items)
        {
            T greatestNumber;
            foreach(T item in items)
            {
                if(items.Count == 0)
                {
                    throw new IndexOutOfRangeException("The list is empty", items);
                }

                else if (greatestNumber == undefined)
                {
                    greatestNumber = item;
                }
                else if(greatestNumber < item)
                {
                    greatestNumber = item;
                }
            }

            return greatestNumber;
        }

        public T Min(List<T> T)
        {
            T smallestNumber;
            foreach (T item in items)
            {
                if (items.count == 0)
                {
                    throw new IndexOutOfRangeException("The list is empty", items);
                }

                else if (smallestNumber == undefined)
                {
                    smallestNumber = item;
                }
                else if (smallestNumber < item)
                {
                    smallestNumber = item;
                }
            }

            return greatestNumber;
        }
    }
}
