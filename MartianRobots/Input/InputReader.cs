using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.BusinessObjects;
using MartianRobots.Interfaces;

namespace MartianRobots.Input
{
    public class ConsoleInputReader
    {
        public string ReadGridCommand()
        {
            return Console.ReadLine();
        }

        public List<RobotCommand> ReadRobotCommands()
        {
            string robotOrientation = Console.ReadLine();
            var robotCommands = new List<RobotCommand>();

            while (robotOrientation != string.Empty)
            {
                var robotInstruction = Console.ReadLine();
                robotCommands.Add(new RobotCommand(robotOrientation, robotInstruction));

                robotOrientation = Console.ReadLine();
            }

            return robotCommands;
        }
    }
}