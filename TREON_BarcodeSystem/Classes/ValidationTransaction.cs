using System;
namespace TREON_BarcodeSystem.Classes
{
    public abstract class ValidationTransaction
    {
        public int Id { get; protected set; }
        public decimal Amount { get; set; }
        public User User { get; set; }

        protected bool IsValidUser(User user)
        {
            try
            {
                if (user is null)
                {
                    throw new ArgumentNullException($"{nameof(user)} cannot be null");
                }

                return true;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        protected bool IsValidProduct(Product product)
        {
            try
            {
                if (product is null)
                {
                    throw new ArgumentNullException($"{nameof(product)} cannot be null");
                }

                return true;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        protected bool IsValidId(int id)
        {
            try
            {
                if (id < 1)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(id)} must not be less than one");
                }

                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        protected bool IsValidAmount(decimal amount)
        {
            try
            {
                if (amount <= 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(amount)} must not be less than zero");
                }

                return true;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
