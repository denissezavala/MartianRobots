using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using MartianRobots.Extensions;

namespace MartianRobots.Tests.Extensions
{
    [TestFixture]
    public class StringExtensionsTests
    {
        public void ToDegrees_Converts_N_To_0()
        {
            // Act
            var degrees = "N".ToDegrees();

            // Assert
            Assert.AreEqual(0, degrees);
        }

        public void ToDegrees_Converts_S_To_180()
        {
            // Act
            var degrees = "S".ToDegrees();

            // Assert
            Assert.AreEqual(180, degrees);
        }

        public void ToDegrees_Converts_E_To_0()
        {
            // Act
            var degrees = "E".ToDegrees();

            // Assert
            Assert.AreEqual(90, degrees);
        }

        public void ToDegrees_Converts_W_To_0()
        {
            // Act
            var degrees = "W".ToDegrees();

            // Assert
            Assert.AreEqual(270, degrees);
        }

        public void ToDegrees_Throws_Exception_For_Uknown_Orientation()
        {
            // Assert
            Assert.Throws<NotImplementedException>(() => "Uknown".ToDegrees());
        }
    }
}
