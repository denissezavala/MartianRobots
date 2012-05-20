using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.BusinessObjects;

namespace MartianRobots.Helpers
{
    public interface IInstructionsParser
    {
        List<Instruction> InstructionDefinitions { get; set; }
        IEnumerable<Instruction> Parse(string instructions);
    }
}
