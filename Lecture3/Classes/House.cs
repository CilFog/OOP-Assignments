using System;
namespace Lecture3.Classes
{
    public class House : FixedProperty, ITaxable
    {
        protected double area;

        public House() : base(null)
        {
        }

        public House(string location, bool inCity, double area,
                     decimal value) :
            base(location, inCity, value)
        {
            this.area = area;
        }

        public double Area
        {
            get
            {
                return area;
            }
        }

        public decimal TaxValue()
        {
            return 2m;
        }
    }
}
