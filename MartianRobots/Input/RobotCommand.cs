using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.Input
{
    public class RobotCommand
    {
        public string Instruction { get; set; }
        public string Orientation { get; set; }

        public RobotCommand(string orientation, string instruction)
        {
            Instruction = instruction;
            Orientation = orientation;
        }
    }
}
