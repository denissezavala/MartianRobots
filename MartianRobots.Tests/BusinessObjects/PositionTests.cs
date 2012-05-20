using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MartianRobots.BusinessObjects;
using Moq;

namespace MartianRobots.Tests.BusinessObjects
{
    [TestFixture]
    public class PositionTests
    {
        Position _sut;

        [Test]
        public void ToString_Returns_Coordinates_And_Orientation_As_String()
        {
            // Arrange
            _sut = new Position(3, 5, 90);

            // Act
            var result = _sut.ToString();

            // Assert
            Assert.AreEqual("3 5 E", result);
        }
    }
}
