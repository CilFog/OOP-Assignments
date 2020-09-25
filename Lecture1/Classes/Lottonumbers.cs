using System;

namespace Lecture1
{
    public static class Lottonumbers
    {
        static int MakeRandomLottoNumbers()
        {
            Random rnd = new Random();
            return rnd.Next(1, 100);
        }

        static int[] LottoCard()
        {
            int lottoNumbers = 7;
            int[] lottoCard = new int[lottoNumbers];

            for (int lottoNumber = 0; lottoNumber < lottoNumbers; lottoNumber++)
            {
                lottoCard[lottoNumber] = MakeRandomLottoNumbers();
            }

            return lottoCard;  
        }
    }
}