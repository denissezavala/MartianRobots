using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.Extensions;
using MartianRobots.Helpers;

namespace MartianRobots.BusinessObjects
{
    public class Robot
    {
        private IInstructionsParser _instructionsParser;
        public Position Position { get; set; }

        public Robot(int x, int y, string orientation, IInstructionsParser instructionsParser)
        {
            Position = new Position(x, y, orientation.ToDegrees());
            _instructionsParser = instructionsParser;
        }

        public Position ExecuteInstructions(string instructions)
        {
            foreach (var instruction in _instructionsParser.Parse(instructions))
            {
                ExecuteInstruction(instruction);
            }
            return Position;
        }

        private void ExecuteInstruction(Instruction instruction)
        {
            Turn(instruction.Degrees);   
            Move(instruction.Distance);
            //Console.WriteLine("After instruction {0}, degrees: {1}, coord: {2},{3}", instruction.Name, Position.Degrees, Position.Coordinate.X, Position.Coordinate.Y);
        }

        private void Turn(int degrees)
        {
            if (degrees != 0)
            {
                Position.Degrees = (Position.Degrees + degrees) % 360;
            }
        }

        private void Move(int distance)
        {
            if (distance == 0)
            {
                return;
            }

            if (Position.Degrees == 0)
            {
                Position.Coordinate.Y += distance;
            }
            else if (Position.Degrees == 90)
            {
                Position.Coordinate.X += distance;
            }
            else if (Position.Degrees == 180 || Position.Degrees == -180)
            {
                Position.Coordinate.Y -= distance;
            }
            else if (Position.Degrees == 270 || Position.Degrees == -90)
            {
                Position.Coordinate.X -= distance;
            }
        }
    }
}
