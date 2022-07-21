using Microsoft.VisualStudio.TestTools.UnitTesting;
using StatePattern.Solution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatePattern.UnitTests
{
    [TestClass]
    public class LightSwitchTests
    {
        [TestMethod]
        public void Init_WhenCalled_ShouldStateIsOff()
        {
            // Arrange

            // Act
            LightSwitch lightSwitch = new LightSwitch();

            // Assert
            Assert.IsInstanceOfType(lightSwitch.State, typeof(Off));

        }

        [TestMethod]
        public void Push_Once_ShouldStateIsOn()
        {
            // Arrange
            LightSwitch lightSwitch = new LightSwitch();

            // Act
            lightSwitch.Push();

            // Assert
            Assert.IsInstanceOfType(lightSwitch.State, typeof(On));
        }

        [TestMethod]
        //  [ExpectedException(typeof(InvalidOperationException))]
        public void PushDown_Twice_ShouldStateIsOff()
        {
            // Arrange
            LightSwitch lightSwitch = new LightSwitch();

            // Act
            lightSwitch.Push();
            lightSwitch.Push();

            // Assert
            Assert.IsInstanceOfType(lightSwitch.State, typeof(Off));
        }
    }
}
