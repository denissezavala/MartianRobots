using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MartianRobots.Helpers;
using MartianRobots.BusinessObjects;

namespace MartianRobots.Tests.Helpers
{
    [TestFixture]
    public class InstructionsParserTests
    {
        private InstructionsParser _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new InstructionsParser();
        }

        private List<Instruction> InstructionsDefinition()
        {
            return new List<Instruction>
            {
                new Instruction("F", 1),
                new Instruction("R", 0, 90),
                new Instruction("L", 0, -90)
            };
        }

        [Test]
        public void Parse_Returns_Empty_If_No_Definitions_Exist()
        {
            // Arrange
            var instructionsString = "FRRF";

            // Act
            var result = _sut.Parse(instructionsString);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }

        [Test]
        public void Parse_Returns_Instructions_If_Definitions_Exist()
        {
            // Arrange
            var instructionsString = "FRRF";
            _sut.InstructionDefinitions = InstructionsDefinition();

            // Act
            var result = _sut.Parse(instructionsString);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(4, result.Count());
        }

        [Test]
        public void Parse_Returns_Null_If_Definitions_Not_Found()
        {
            // Arrange
            var instructionsString = "X";
            _sut.InstructionDefinitions = InstructionsDefinition();

            // Act
            var result = _sut.Parse(instructionsString);

            // Assert
            Assert.AreEqual(1, result.Count());
            Assert.IsNull(result.First());
        }

        [Test]
        public void Parse_Returns_Empty_If_Instructions_String_Empty()
        {
            // Arrange
            var instructionsString = "";
            _sut.InstructionDefinitions = InstructionsDefinition();

            // Act
            var result = _sut.Parse(instructionsString);

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
