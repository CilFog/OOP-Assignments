using System;
namespace Lecture1.Classes
{
    public static class ReferenceCompariter
    {
        public static bool CompareReferencetype(Person a, Person b)
        {
            if(a == b)
            {
                return true;
            }

            return false;
        }
    }
}
