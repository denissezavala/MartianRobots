using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.BusinessObjects;

namespace MartianRobots
{
    public class Program
    {
        public static void Main(string[] args)
        {
            InstructionsSetup();

            var robotA = new Robot(1, 1, "E");
            var robotB = new Robot(3, 2, "N");
            var robotC = new Robot(0, 3, "W");

            Console.WriteLine("Robot A");
            Console.WriteLine(robotA.ExecuteInstructions("RFRFRFRF"));
            Console.WriteLine("Robot B");
            Console.WriteLine(robotB.ExecuteInstructions("FRRFLLFFRRFLL"));
            Console.WriteLine("Robot C");
            Console.WriteLine(robotC.ExecuteInstructions("LLFFFLFLFL"));
            Console.Read();
        }

        static void InstructionsSetup()
        {
            InstructionsParser.InstructionDefinitions = new List<Instruction>
            {
                new Instruction("F", 1),
                new Instruction("R", 0, 90),
                new Instruction("L", 0, -90),
                //new Instruction("B", -1, 0),
            };
        }
    }
}
