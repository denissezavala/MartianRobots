using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.Interfaces;

namespace MartianRobots.BusinessObjects
{
    public class Grid : IGrid
    {
        private Coordinate _limit { get; set; }
        private List<Coordinate> _scentedCoordinates { get; set; }

        public Grid(int x, int y)
        {
            _limit = new Coordinate(x, y);
            _scentedCoordinates = new List<Coordinate>();
        }

        public bool IsCoordinateValid(Coordinate coordinate)
        {
            return coordinate.X <= _limit.X && coordinate.Y <= _limit.Y;
        }

        public void AddScentedCoordinate(Coordinate scentedCoord)
        {
            _scentedCoordinates.Add(scentedCoord);
        }

        public bool IsCoordinateScented(Coordinate coord)
        {
            return _scentedCoordinates.Any(sc => sc.X == coord.X && sc.Y == coord.Y);
        }
    }
}
