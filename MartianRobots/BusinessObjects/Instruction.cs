using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MartianRobots.BusinessObjects
{
    public class Instruction
    {
        public string Name { get; set; }
        public double Degrees { get; set; }
        public int Distance { get; set; }

        public Instruction(string name, int distance, double degrees = 0)
        {
            Name = name;
            Degrees = degrees;
            Distance = distance;
        }
    }
}
