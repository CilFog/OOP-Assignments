using System;

namespace Lektion1.Classes 
{
    static class RadiansAndDegrees 
    {
        static double ConvertRadiansToDegrees(double radians)
        {
            if (radians < 2 && radians > 0)
            {
                return radians * (180 / Math.PI);
            }

            else if (radians == 2)
            {
                return 0;
            }
            else if (radians == 0)
            {
                return 360;
            }
            else return 0;
        }

        static double ConvertDegreesToRadians(double degrees)
        {
            if (degrees == 0)
            {
                degrees = 360;
            }
            return degrees * (Math.PI / 180);
        }
    }
}