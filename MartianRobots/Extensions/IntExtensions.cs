using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.Extensions
{
    public static class IntExtensions
    {
        public static string ToOrientation(this int degrees)
        {
            if (degrees == 0)
            {
                return "N";
            }
            else if (degrees == 90)
            {
                return "E";
            }
            else if (degrees == -90 || degrees == 270)
            {
                return "W";
            }
            else if (degrees == 180 || degrees == -180)
            {
                return "S";
            }

            throw new NotImplementedException();
        }
    }
}
