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
            var inputReader = new ConsoleInputReader();
            inputReader.InstructionsParser = InstructionsParser();
            inputReader.ReadCommands();
            inputReader.ExecuteCommands();
           
            Console.Read();
        }

        static IInstructionsParser InstructionsParser()
        {
            return new InstructionsParser()
            {
                InstructionDefinitions = new List<Instruction>
                {
                    new Instruction("F", 1),
                    new Instruction("R", 0, 90),
                    new Instruction("L", 0, -90)
                }
            };
        }
    }
}
