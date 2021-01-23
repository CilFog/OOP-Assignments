using System;
namespace TREON_BarcodeSystem.Classes
{
    public abstract class Transaction : ValidationTransaction
    {
        public DateTime Date { get; set; }

        public override string ToString()
        {
            return $"{Id}, at {Date.TimeOfDay}, {Amount} was bought for by {User.Username}";
        }

        public abstract void Execute();
    }
}
