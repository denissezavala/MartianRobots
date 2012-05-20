using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.Extensions
{
    public static class DoubleExtensions
    {
        public static string ToOrientation(this double degrees)
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

        //public static string ToInstruction(this double degrees)
        //{
        //    if (degrees == 0)
        //    {
        //        return "F";
        //    }
        //    else if (degrees == 90)
        //    {
        //        return "R";
        //    }
        //    else if (degrees == -90 || degrees == 270)
        //    {
        //        return "L";
        //    }

        //    throw new NotImplementedException();
        //}
    }
}
