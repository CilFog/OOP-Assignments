using System;
using TREON_BarcodeSystem.Exceptions;

namespace TREON_BarcodeSystem.Classes
{
    public class BuyTransaction : Transaction
    {
        public Product Product { get; set; }

        public BuyTransaction(User user, Product product)
        {
            if (IsValidUser(user) && IsValidProduct(Product))
            {
                Amount = product.Price;
                User = user;
                Product = product;
            }
        }

        public override void Execute()
        {
            if (!Product.Active)
            {
                throw new ProductNotActiveException($"{Product.Name} is not active");
            }
            else if (Product.CanBeBoughtOnCredit)
            {
                User.Balance -= Amount;
            }
            else if (Product.Price < User.Balance)
            {
                User.Balance -= Amount;
            }
            else
            {
                throw new InsufficientCreditsException($"Not enough cash on {User.Username}'s balance");
            }
        }
    }
}
