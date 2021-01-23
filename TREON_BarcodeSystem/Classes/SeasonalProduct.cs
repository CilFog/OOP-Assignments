using System;
namespace TREON_BarcodeSystem.Classes
{
    public class SeasonalProduct : Product
    {
        DateTime SeasonStartDate { get; set; }
        DateTime SeasonEndDate { get; set; }

        public SeasonalProduct(string name, decimal price, bool active,
            bool canBeBoughtOnCredit, DateTime startDate, DateTime EndDate)
            : base (name, price, active, canBeBoughtOnCredit)
        {

        }

        public SeasonalProduct(int id, string name, decimal price, bool active,
            bool canBeBoughtOnCredit, DateTime startDate, DateTime EndDate)
            : base(UpdateId(), name, price, active, canBeBoughtOnCredit)
        {
            Id = _id;
        }
    }
}
