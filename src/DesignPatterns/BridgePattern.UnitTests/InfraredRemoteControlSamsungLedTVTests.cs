using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace BridgePattern.UnitTests
{
    [TestClass]
    public class InfraredRemoteControlSamsungLedTVTests
    {
        [TestMethod]
        public void SwitchOn_ShouldOnTrue()
        {
            // Arrange
            ILedTv ledTv = new SamsungLedTv();
            AbstractRemoteControl remoteControl = new InfraredRemoteControl(ledTv);

            // Act
            remoteControl.SwitchOn();

            //
            Assert.IsTrue(ledTv.On);
        }

        [TestMethod]
        public void SwitchOn_ShouldOnFalse()
        {
            // Arrange
            InfraredRemoteControlSamsungLedTV ledTV = new InfraredRemoteControlSamsungLedTV();

            // Act
            ledTV.SwitchOff();

            //
            Assert.IsFalse(ledTV.On);
        }

        [TestMethod]
        public void SetChannel_ShouldSetCurrentChannel()
        {
            // Arrange
            InfraredRemoteControlSamsungLedTV ledTV = new InfraredRemoteControlSamsungLedTV();

            // Act
            ledTV.SetChannel(10);

            //
            Assert.AreEqual(10, ledTV.CurrentChannel);
        }
    }
}
