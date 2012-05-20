using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.BusinessObjects;
using MartianRobots.Helpers;
using MartianRobots.Interfaces;

namespace MartianRobots
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var grid = new Grid(5, 3);
            var robotA = new Robot(1, 1, "E", InstructionsParser(), grid);
            var robotB = new Robot(3, 2, "N", InstructionsParser(), grid);
            var robotC = new Robot(0, 3, "W", InstructionsParser(), grid);

            Console.WriteLine("Robot A");
            Console.WriteLine(robotA.ExecuteInstructions("RFRFRFRF"));
            Console.WriteLine("Robot B");
            Console.WriteLine(robotB.ExecuteInstructions("FRRFLLFFRRFLL"));
            Console.WriteLine("Robot C");
            Console.WriteLine(robotC.ExecuteInstructions("LLFFFLFLFL"));
           
            Console.Read();
        }

        static IInstructionsParser InstructionsParser()
        {
            return new InstructionsParser()
            {
                InstructionDefinitions = new List<Instruction>{
                    new Instruction("F", 1),
                    new Instruction("R", 0, 90),
                    new Instruction("L", 0, -90)
                }
            };
        }
    }
}
