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
        public int Degrees { get; set; }
        public bool IsValid { get; set; }

        public Position(int x, int y, int degrees)
        {
            Coordinate = new Coordinate(x, y);
            Degrees = degrees;
            IsValid = true;
        }

        public override string ToString()
        {
            return string.Format("{0} {1} {2} {3}", Coordinate.X, Coordinate.Y, Degrees.ToOrientation(), IsValid ? string.Empty : "LOST" );
        }
    }
}
