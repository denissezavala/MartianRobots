using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using MartianRobots.BusinessObjects;

namespace MartianRobots.Tests.BusinessObjects
{
    [TestFixture]
    public class RobotTests
    {
        private Robot _sut;

        [SetUp]
        public void Setup()
        {
            //_sut = new Robot();
        }

        [Test]
        public void Constructor_Sets_Position_Coordinates()
        {
            // Arrange
            var x =3;
            var y= 4;
            var orientation = "E";
           
            // Act
            _sut = new Robot(x, y, orientation);

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
            _sut = new Robot(x, y, orientation);

            // Assert
            Assert.AreEqual(degrees, _sut.Position.Degrees);
        }

        [Test]
        public void Move_Should_Increment_X_When_Current_Position_Is_East()
        {
            // Arrange
            int x = 0;
            int y = 0;
            double degrees = 90;
            _sut = new Robot(0, 0, "E");
            _sut.Position = new Position(x, y, degrees);
            
            // Act
            
        }
    }
}
