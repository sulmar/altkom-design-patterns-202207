using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace StatePattern.UnitTests
{

    [TestClass]
    public class LampTests
    {
        [TestMethod]
        public void PushDown_Init_ShouldVolumeIs0()
        {
            // Arrange

            // Act
            Lamp lamp = new Lamp();

            // Assert
            Assert.AreEqual(0, lamp.Volume);

        }

        [TestMethod]
        public void PushDown_Once_ShouldIsOn()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.PushDown();

            // Assert
            Assert.AreEqual(50, lamp.Volume);
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
            Assert.AreEqual(0, lamp.Volume);
        }

        [TestMethod]
      //  [ExpectedException(typeof(InvalidOperationException))]
        public void PushDown_Twice_ShouldVolumeIs100()
        {
            // Arrange
            Lamp lamp = new Lamp();

            // Act
            lamp.PushDown();
            lamp.PushDown();

            // Assert
            Assert.AreEqual(100, lamp.Volume);
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
