using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.Extensions;

namespace MartianRobots.BusinessObjects
{
    public class Robot
    {
        public Position Position { get; set; }
        //public static List<Instruction> InstructionsDefinition { get; set; }

        public Robot(int x, int y, string orientation)
        {
            Position = new Position(x, y, orientation.ToDegrees());
        }

        public Position ExecuteInstructions(string instructions)
        {
            foreach (var instruction in InstructionsParser.Parse(instructions))
            {
                ExecuteInstruction(instruction);
            }
            return Position;
        }

        //private IEnumerable<Instruction> ParseInstructionsString(string instructions)
        //{
        //    foreach (var instName in instructions)
        //    {
        //        yield return InstructionsDefinition.Find(x => x.Name == instName.ToString());
        //    }
        //}

        private void ExecuteInstruction(Instruction instruction)
        {
            Turn(instruction.Degrees);   
            Move(instruction.Distance);
            //Console.WriteLine("After instruction {0}, degrees: {1}, coord: {2},{3}", instruction.Name, Position.Degrees, Position.Coordinate.X, Position.Coordinate.Y);
        }

        private void Turn(double degrees)
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
