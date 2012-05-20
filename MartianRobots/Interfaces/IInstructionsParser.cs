using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.BusinessObjects;

namespace MartianRobots.Interfaces
{
    public interface IInstructionsParser
    {
        List<Instruction> InstructionDefinitions { get; set; }
        IEnumerable<Instruction> Parse(string instructions);
    }
}
