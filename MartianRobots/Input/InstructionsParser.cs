using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.BusinessObjects;
using MartianRobots.Interfaces;
using MartianRobots.Extensions;

namespace MartianRobots.Input
{
    public class InstructionsParser : IInstructionsParser
    {
        public List<Instruction> InstructionDefinitions { get; set; }

        public IEnumerable<Instruction> Parse(string instructions)
        {
            instructions = instructions.Truncate(100);

            foreach (var instName in instructions)
            {
                if (InstructionDefinitions != null)
                {
                    yield return InstructionDefinitions.Find(x => x.Name == instName.ToString());
                }
            }
        }
    }
}
