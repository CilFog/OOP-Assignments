using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Linq;

namespace TREON_BarcodeSystem.Classes
{
    public abstract class ValidationUser
    {
        protected bool IsValidEmail(string email)
        {
            try
            {
                MailAddress mailAddress = new MailAddress(email);
                return mailAddress.Address == email;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        protected bool IsValidUsername(string username)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(username))
                {
                    throw new ArgumentException($"{nameof(username)} may not consist of only whitespace, be empty or null");
                }

                string pattern = "([a-z1-9]_)+";

                return Regex.IsMatch(username, pattern);


            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        protected bool IsValidName(string name)
        {
            try
            {
                if (String.IsNullOrEmpty(name))
                {
                    throw new ArgumentException($"{nameof(name)} may not consist of only whitespace, be empty or null");
                }

                return !name.Any(char.IsDigit);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        protected bool IsValidId(int id)
        {
            try
            {
                if (id < 0)
                {
                    throw new ArgumentOutOfRangeException($"{nameof(id)} cannot be negative");
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

            return true;
        }
    }
}
