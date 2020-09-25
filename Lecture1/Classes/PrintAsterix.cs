using System;

namespace Lecture1
{
    public static class PrintAsterix 
    {
        static string[] IndentAsterixOnEachLine(int amountOfAsterix)
        {
            char asterixSign = '*';

            string[] array = new string[amountOfAsterix];
            
            for(int asterix = 1; asterix <= amountOfAsterix; asterix++)
            {
                array[asterix - 1] = new String(asterixSign, asterix); 
            }

            return array;
        }

        static string[] UnindentAsterixOnEachLine(int amountOfAsterix)
        {
            char asterixSign = '*';

            string[] array = new string[amountOfAsterix];

            for (int asterix = 1; asterix <= amountOfAsterix; asterix++)
            {
                array[asterix - 1] = new String(asterixSign, (8 - asterix));
            }

            return array;
        }
    }
}