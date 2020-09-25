using System;

namespace Lecture2.Classes
{

    public class ParkingMeter : ParkingRate
    {
        public ParkingMeter(double coins, double rate) 
        {
            MinutesToPark = InsertCoinsForParking(coins, rate);
        }
        public double InsertCoinsForParking(double coins, double rate)
        {
            return coins * getRate(rate);
        }


        public double MinutesToPark { get; }

        public override double getRate(double rate)
        {
            return rate;
        }
    }

}

