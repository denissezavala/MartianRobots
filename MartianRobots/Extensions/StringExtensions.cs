using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.Extensions
{
    public static class StringExtensions
    {
        public static int ToDegrees(this string orientation)
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

        public static string Truncate(this string longString, int length)
        {
            return length < longString.Length ? longString.Substring(0, length) : longString;
        }
    }
}
