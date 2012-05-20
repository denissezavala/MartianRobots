using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.Extensions;

namespace MartianRobots.BusinessObjects
{
    public class Position
    {
        public Coordinate Coordinate { get; set; }
        public double Degrees { get; set; }

        public Position(int x, int y, double degrees)
        {
            Coordinate = new Coordinate(x, y);
            Degrees = degrees;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2}", Coordinate.X, Coordinate.Y, Degrees.ToOrientation());
        }
    }
}
