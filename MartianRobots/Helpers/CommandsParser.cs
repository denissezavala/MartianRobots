using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.BusinessObjects;

namespace MartianRobots.Helpers
{
    public class CommandsParser
    {
        public static Coordinate CommandToCoordinate(string command)
        {
            var coordinates = command.Split(' ');
            int x = 0, y = 0;

            if (coordinates.Count() < 2 || !Int32.TryParse(coordinates[0], out x) || !Int32.TryParse(coordinates[1], out y))
            {
                return null;
            }

            return new Coordinate(x, y);
        }

        public static string RobotCommandToOrientation(string command)
        {
            var parts = command.Split(' ');
            
            if (parts.Count() < 3)
            {
                return null;
            }

            return parts[2];
        }

        public static bool IsRobotCommandValid(Coordinate coord, string orientation)
        {
            return coord != null && !string.IsNullOrEmpty(orientation);
        }
    }
}
