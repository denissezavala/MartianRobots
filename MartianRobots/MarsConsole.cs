using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.Input;
using MartianRobots.BusinessObjects;

namespace MartianRobots
{
    public class MarsConsole
    {
        private ConsoleInputReader _inputReader;
        private List<RobotCommand> _robotCommands;
        private string _gridCommand;
        private InstructionsParser _instructionsParser;

        public MarsConsole()
        {
            _inputReader = new ConsoleInputReader();
        }

        public void Start()
        {
            _gridCommand = _inputReader.ReadGridCommand();
            _robotCommands = _inputReader.ReadRobotCommands();
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
                var coord = CommandsParser.CommandToCoordinate(robotCmd.Orientation);
                var orientation = CommandsParser.RobotCommandToOrientation(robotCmd.Orientation);

                if (CommandsParser.IsRobotCommandValid(coord, orientation))
                {
                    var robot = new Robot(coord.X, coord.Y, orientation, GetInstructionsParser(), grid);
                    Console.WriteLine(robot.ExecuteInstructions(robotCmd.Instruction));
                }
                else
                {
                    Console.WriteLine("Command {0} is invalid", robotCmd.Orientation);
                }
            }
        }

        private InstructionsParser GetInstructionsParser()
        {
            if (_instructionsParser == null)
            {
                _instructionsParser = new InstructionsParser()
                {
                    InstructionDefinitions = new List<Instruction>
                    {
                        new Instruction("F", 1),
                        new Instruction("R", 0, 90),
                        new Instruction("L", 0, -90)
                    }
                };
            }

            return _instructionsParser;
        }
    }
}
