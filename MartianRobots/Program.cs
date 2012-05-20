using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MartianRobots.BusinessObjects;
using MartianRobots.Input;
using MartianRobots.Interfaces;

namespace MartianRobots
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var marsConsole = new MarsConsole();
            marsConsole.Start();
            marsConsole.ExecuteCommands();
           
            Console.Read();
        }
    }
}
