using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.BusinessObjects
{
    public static class InstructionsParser
    {
        public static List<Instruction> InstructionDefinitions { get; set; }

        public static IEnumerable<Instruction> Parse(string instructions)
        {
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
