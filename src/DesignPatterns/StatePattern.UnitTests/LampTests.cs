using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StatePattern.UnitTests
{

    [TestClass]
    public class LampTests
    {
        [TestMethod]
        public void PushDown_Init_ShouldIsOff()
        {
            // Arrange

            // Act
            Lamp lamp = new Lamp();

            // Assert
            Assert.IsFalse(lamp.IsOn);

        }

        [TestMethod]
        public void PushDown_Once_ShouldIsOn()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.PushDown();

            // Assert
            Assert.IsTrue(lamp.IsOn);
        }

        [TestMethod]
        public void PushDown_PushUp_ShouldIsOff()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.PushDown();
            lamp.PushUp();

            // Assert
            Assert.IsFalse(lamp.IsOn);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PushDown_Twice_ShouldThrowException()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.PushDown();
            lamp.PushDown();

            // Assert
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void PushUp_Twice_ShouldThrowException()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.PushUp();
            lamp.PushUp();

            // Assert
        }
    }
}
