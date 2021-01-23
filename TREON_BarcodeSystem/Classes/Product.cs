using System;
namespace TREON_BarcodeSystem.Classes
{
    public class Product : ValidationProduct
    {
        public int Id { get; protected set; }
        public string Name { get; private set; }
        public decimal Price { get; private set; }
        public bool Active { get; private set; }
        public bool CanBeBoughtOnCredit { get; set; }
        protected static int _id { get; set; } = 1;

        //Contructor chaining
        public Product(string name, decimal price, bool active, bool canBeBoughtOnCredit)
            : this(UpdateId(), name, price, active, canBeBoughtOnCredit)
        {
            Id = _id;
        }
        public Product(int id, string name, decimal price, bool active, bool canBeBoughtOnCredit)
        {
            if (IsValidId(id) && IsValidProductName(name) && IsValidPrice(price))
            {
                Id = id;
                Name = name;
                Price = price;
                Active = active;
                CanBeBoughtOnCredit = canBeBoughtOnCredit;
            }
        }

        protected static int UpdateId()
        {
            _id++;
            return _id;
        }

        public override string ToString()
        {
            return $"{Id}: {Name} - {Price}";
        }
    }
}
