using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using MartianRobots.BusinessObjects;
using MartianRobots.Helpers;

namespace MartianRobots.Tests.BusinessObjects
{
    [TestFixture]
    public class RobotTests
    {
        private Robot _sut;
        private InstructionsParser _instructionsParser;

        [SetUp]
        public void Setup()
        {
            _instructionsParser = new InstructionsParser()
            {
                InstructionDefinitions = new List<Instruction>{
                    new Instruction("F", 1),
                    new Instruction("R", 0, 90),
                    new Instruction("L", 0, -90)
                }
            };
        }

        [Test]
        public void Constructor_Sets_Position_Coordinates()
        {
            // Arrange
            var x =3;
            var y= 4;
            var orientation = "E";
           
            // Act
            _sut = new Robot(x, y, orientation, _instructionsParser);

            // Assert
            Assert.AreEqual(x, _sut.Position.Coordinate.X);
            Assert.AreEqual(y, _sut.Position.Coordinate.Y);
        }

        [Test]
        public void Constructor_Sets_Position_Degrees()
        {
            // Arrange
            var x = 3;
            var y = 4;
            var orientation = "E";
            var degrees = 90;

            // Act
            _sut = new Robot(x, y, orientation, _instructionsParser);

            // Assert
            Assert.AreEqual(degrees, _sut.Position.Degrees);
        }

        //[Test]
        //public void Turn_Updates_Position_Degrees()
        //{
        //    // Arrange
        //    _sut = new Robot(0, 0, "N", _instructionsParser);
            
        //    // Act
        //    _sut.Turn(90);

        //    // Assert
        //    Assert.AreEqual(90, _sut.Position.Degrees);
        //}

        [Test]
        public void Execute_Instructions_Calls_InstructionParser_Parse()
        {
            // Arrange
            var instructions = "RFFL";
            var mockInstructionsParser = new Mock<IInstructionsParser>();
            mockInstructionsParser.Setup(x => x.Parse(It.IsAny<string>())).Returns(new List<Instruction>()).Verifiable();
            
            _sut = new Robot(0, 0, "E", mockInstructionsParser.Object);

            // Act
            _sut.ExecuteInstructions(instructions);

            // Assert
            mockInstructionsParser.VerifyAll();
        }

        [Test]
        public void ExecuteInstructions_Returns_Position()
        {
            // Arrange
            var instructions = "RFFL";
            _sut = new Robot(0, 0, "E", _instructionsParser);

            // Act
            var result = _sut.ExecuteInstructions(instructions);

            // Assert
            Assert.IsInstanceOf<Position>(result);
        }
       
    }
}
