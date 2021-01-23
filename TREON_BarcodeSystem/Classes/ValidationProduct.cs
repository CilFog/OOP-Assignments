using System;
namespace TREON_BarcodeSystem.Classes
{
    public abstract class ValidationProduct
    {
        protected bool IsValidProductName(string productName)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(productName))
                {
                    throw new ArgumentException($"{nameof(productName)} cannot be null, empty or whitespace");
                }
                return true;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        protected bool IsValidPrice(decimal price)
        {
            try
            {
                if (price <= 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(price)} must be set to something purchaseable");
                }

                return true;
            }
            catch (ArgumentOutOfRangeException ex)
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
    }
}
