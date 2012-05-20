using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.Extensions;
using MartianRobots.Helpers;
using MartianRobots.Interfaces;

namespace MartianRobots.BusinessObjects
{
    public class Robot
    {
        private IInstructionsParser _instructionsParser;
        private Grid _grid;
        public Position Position { get; set; }

        public Robot(int x, int y, string orientation, IInstructionsParser instructionsParser, Grid grid)
        {
            Position = new Position(x, y, orientation.ToDegrees());
            _instructionsParser = instructionsParser;
            _grid = grid;
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
            if (instruction != null && Position.IsValid)
            {
                Turn(instruction.Degrees);
                Move(instruction.Distance);
                //Console.WriteLine("After instruction {0}, degrees: {1}, coord: {2},{3}", instruction.Name, Position.Degrees, Position.Coordinate.X, Position.Coordinate.Y);
            }
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

            var nextCoordinate = GetNextCoordinate(distance);
            var nextCoordinateIsValid = _grid.IsCoordinateValid(nextCoordinate);
            //Console.WriteLine("{0},{1} {2}", nextCoordinate.X, nextCoordinate.Y, Position.IsValid);

            if (nextCoordinateIsValid)
            {
                Position.Coordinate = nextCoordinate;
                Position.IsValid = true;
            }
            else if(!_grid.IsCoordinateScented(nextCoordinate))
            {
                _grid.AddScentedCoordinate(nextCoordinate);
                Position.IsValid = false;
            }

        }

        private Coordinate GetNextCoordinate(int distance)
        {
            Coordinate nextCoord = new Coordinate(Position.Coordinate.X, Position.Coordinate.Y);

            if (Position.Degrees == 0)
            {
                nextCoord.Y = Position.Coordinate.Y + distance;
            }
            else if (Position.Degrees == 90)
            {
                nextCoord.X = Position.Coordinate.X + distance;
            }
            else if (Position.Degrees == 180 || Position.Degrees == -180)
            {
                nextCoord.Y = Position.Coordinate.Y - distance;
            }
            else if (Position.Degrees == 270 || Position.Degrees == -90)
            {
                nextCoord.X = Position.Coordinate.X - distance;
            }

            return nextCoord;
        }
    }
}
