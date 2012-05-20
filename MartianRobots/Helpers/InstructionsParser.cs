using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.BusinessObjects;

namespace MartianRobots.Helpers
{
    public class InstructionsParser :IInstructionsParser
    {
        public List<Instruction> InstructionDefinitions { get; set; }

        public IEnumerable<Instruction> Parse(string instructions)
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
