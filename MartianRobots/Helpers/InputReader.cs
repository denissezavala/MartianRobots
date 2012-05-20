using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.BusinessObjects;
using MartianRobots.Interfaces;

namespace MartianRobots.Helpers
{
    public class ConsoleInputReader
    {
        List<KeyValuePair<string, string>> _robotCommands;
        private string _gridCommand;

        public IInstructionsParser InstructionsParser { get; set; }

        public ConsoleInputReader()
        {
            _robotCommands = new List<KeyValuePair<string, string>>();
        }

        public void ReadCommands()
        {
            _gridCommand = Console.ReadLine();
            string robotCommand = Console.ReadLine();

            while (robotCommand != string.Empty)
            {
                var robotInstruction = Console.ReadLine();
                _robotCommands.Add(new KeyValuePair<string, string>(robotCommand, robotInstruction));

                robotCommand = Console.ReadLine();
            }
        }

        public void ExecuteCommands()
        {
            var gridCoord = CommandsParser.CommandToCoordinate(_gridCommand);
            if (gridCoord == null)
            {
                Console.WriteLine("Command {0} is invalid", _gridCommand);
                return;
            }

            var grid = new Grid(gridCoord.X, gridCoord.Y);

            foreach (var robotCmd in _robotCommands)
            {
                var coord = CommandsParser.CommandToCoordinate(robotCmd.Key);
                var orientation = CommandsParser.RobotCommandToOrientation(robotCmd.Key);

                if (CommandsParser.IsRobotCommandValid(coord, orientation))
                {
                    var robot = new Robot(coord.X, coord.Y, orientation, InstructionsParser, grid);
                    Console.WriteLine(robot.ExecuteInstructions(robotCmd.Value));
                }
                else
                {
                    Console.WriteLine("Command {0} is invalid", robotCmd.Key);
                }
            }
        }
    }
}