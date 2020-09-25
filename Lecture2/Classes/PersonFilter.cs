using System;
using System.Collections.Generic;

namespace Lecture2.Classes
{
    public abstract class PersonFilter
    {
        public PersonFilter()
        {
        }

        public virtual List<Person> Filter(List<Person> plist)
        {
            List<Person> FilterationDone = new List<Person>();

            foreach(Person person in plist)
            {
                if(FilterPredicate(person))
                {
                    FilterationDone.Add(person);
                }
            }

            return FilterationDone;
        }

        public abstract bool FilterPredicate(Person person);
    }
}
