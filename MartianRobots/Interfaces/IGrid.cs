using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.BusinessObjects;

namespace MartianRobots.Interfaces
{
    public interface IGrid
    {
        bool IsCoordinateValid(Coordinate coordinate);
        void AddScentedCoordinate(Coordinate scentedCoord);
        bool IsCoordinateScented(Coordinate coord);
    }
}
