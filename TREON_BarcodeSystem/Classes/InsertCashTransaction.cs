using System;

namespace TREON_BarcodeSystem.Classes
{
    public class InsertCashTransaction : Transaction
    {
        public InsertCashTransaction(User user, decimal amount)
        {
            if (IsValidUser(user) && IsValidAmount(amount))
            {
                User = user;
                Amount = amount;
            }
        }

        public override void Execute()
        {
            User.Balance += Amount;
        }

        public override string ToString()
        {
            return $"{Id}. At {Date},  {Amount} was inserted into useraccount {User.Username}";
        }
    }
}
