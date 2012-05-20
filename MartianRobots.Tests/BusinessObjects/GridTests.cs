using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MartianRobots.BusinessObjects;

namespace MartianRobots.Tests.BusinessObjects
{
    [TestFixture]
    public class GridTests
    {
        private Grid _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Grid(3, 5);
        }

        [Test]
        public void IsCoordinateValid_Returns_True_For_Coord_Inside_Grid()
        {
            // Arrange
            var coordinate = new Coordinate(2,2);
            
            // Act
            var result = _sut.IsCoordinateValid(coordinate);

            // Assert
            Assert.IsTrue(result);
        }

        [Test]
        public void IsCoordinateValid_Returns_False_For_Coord_Outside_Grid()
        {
            // Arrange
            var coordinate = new Coordinate(5, 2);

            // Act
            var result = _sut.IsCoordinateValid(coordinate);

            // Assert
            Assert.IsFalse(result);
        }
    }
}
