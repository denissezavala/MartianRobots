using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.Extensions
{
    public static class StringExtensions
    {
        public static double ToDegrees(this string orientation)
        {
            switch (orientation)
            {
                case "N":
                    return 0;
                case "S":
                    return 180;
                case "E":
                    return 90;
                case "W":
                    return 270;
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
