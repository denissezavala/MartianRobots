using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using MartianRobots.BusinessObjects;
using MartianRobots.Helpers;
using MartianRobots.Interfaces;

namespace MartianRobots.Tests.BusinessObjects
{
    [TestFixture]
    public class RobotTests
    {
        private Robot _sut;
        private IInstructionsParser _instructionsParser;
        private IGrid _grid;

        [SetUp]
        public void Setup()
        {
            _grid = new Grid(5, 3);
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
            _sut = new Robot(x, y, orientation, _instructionsParser, _grid);

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
            _sut = new Robot(x, y, orientation, _instructionsParser, _grid);

            // Assert
            Assert.AreEqual(degrees, _sut.Position.Degrees);
        }

        [Test]
        public void Execute_Instructions_Calls_InstructionParser_Parse()
        {
            // Arrange
            var instructions = "RFFL";
            var mockInstructionsParser = new Mock<IInstructionsParser>();
            mockInstructionsParser.Setup(x => x.Parse(It.IsAny<string>())).Returns(new List<Instruction>()).Verifiable();
            
            _sut = new Robot(0, 0, "E", mockInstructionsParser.Object, _grid);

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
            _sut = new Robot(0, 0, "E", _instructionsParser, _grid);

            // Act
            var result = _sut.ExecuteInstructions(instructions);

            // Assert
            Assert.IsInstanceOf<Position>(result);
        }

        [Test]
        public void ExecuteInstructions_Returns_1_1_E_For_RFRFRFRF()
        {
            // Arrange
            var expectedX = 1;
            var expectedY = 1;
            var expectedDegrees = 90;
            var instructions = "RFRFRFRF";
            _sut = new Robot(1, 1, "E", _instructionsParser, _grid);

            // Act
            var result = _sut.ExecuteInstructions(instructions);

            // Assert
            Assert.AreEqual(expectedX, result.Coordinate.X);
            Assert.AreEqual(expectedY, result.Coordinate.Y);
            Assert.AreEqual(expectedDegrees, result.Degrees);
        }

        [Test]
        public void ExecuteInstructions_Returns_3_3_N_For_FRRFLLFFRRFLL()
        {
            // Arrange
            var expectedX = 3;
            var expectedY = 3;
            var expectedDegrees = 0;
            var instructions = "FRRFLLFFRRFLL";
            _sut = new Robot(3, 2, "N", _instructionsParser, _grid);

            // Act
            var result = _sut.ExecuteInstructions(instructions);

            // Assert
            Assert.AreEqual(expectedX, result.Coordinate.X);
            Assert.AreEqual(expectedY, result.Coordinate.Y);
            Assert.AreEqual(expectedDegrees, result.Degrees);
        }

        //[Test]
        //public void ExecuteInstructions_Returns_2_3_S_For_LLFFFLFLFL()
        //{
        //    // Arrange
        //    var expectedX = 2;
        //    var expectedY = 3;
        //    var expectedDegrees =180;
        //    var instructions = "LLFFFLFLFL";
        //    _sut = new Robot(0, 3, "W", _instructionsParser, _grid);

        //    // Act
        //    var result = _sut.ExecuteInstructions(instructions);

        //    // Assert
        //    Assert.AreEqual(expectedX, result.Coordinate.X);
        //    Assert.AreEqual(expectedY, result.Coordinate.Y);
        //    Assert.AreEqual(expectedDegrees,  Math.Abs(result.Degrees));
        //}
       
    }
}
