using System;

namespace TREON_BarcodeSystem.Classes
{
    public delegate void UserBalanceNotification(User user, decimal balance);

    public class User : ValidationUser, IComparable<User>
    {
        //Properties - or known as fields with get and set methods.
        //Makes use of access modifiers: private and public
        private static int _id { get; set; } = 0;
        public int Id { get; private set; }
        public string Username { get; }
        public decimal Balance { get; set; } = 0;
        private string FirstName { get; }
        private string LastName { get; }
        private string Email { get; }

        //Uses constructor chaining
        public User(string username, string firstName, string lastName, string email)
            : this(UpdateId(), username, firstName, lastName, email, 0M)
        {
            Id = _id;
        }

        public User(int id, string username, string firstName, string lastName, string email, decimal balance)
        {
            if (IsValidId(id) && IsValidName(username) && IsValidName(firstName) && IsValidName(lastName) && IsValidEmail(email))
            {
                Id = id;
                Username = username;
                FirstName = firstName;
                LastName = lastName;
                Email = email;
                Balance = balance;
            }
        }

        private static int UpdateId()
        {
            _id++;
            return _id;
        }

        public override bool Equals(object obj)
        {
            return obj is User user &&
                   Id == user.Id &&
                   Username == user.Username &&
                   Email == user.Email;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id, Username, Email);
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName} ({Email})";
        }

        public int CompareTo(User other)
        {
            try
            {
                if (other is null)
                {
                    throw new ArgumentNullException("Unable to compare User with null");
                }
                return Id.CompareTo(other.Id);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return -1;
            }
        }
    }
}
