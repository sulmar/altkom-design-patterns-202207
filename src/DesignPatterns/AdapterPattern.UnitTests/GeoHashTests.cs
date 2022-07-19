using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AdapterPattern.UnitTests
{
    [TestClass]
    public class GeoHashTests
    {
        [TestMethod]
        public void Convert_GeoHash_ShouldReturnLocation()
        {
            // Arrange
            string geohash = "u3ky1z5793cb";

            // Act
            Location location = new Location();

            // Assert
            Assert.AreEqual(location.Latitude, 53.12499993);
            Assert.AreEqual(location.Longitude, 18.01111115);
        }

        [TestMethod]
        public void Convert_Location_ShouldReturnGeohash()
        {
            // Arrange
            var location = new Location { Latitude = 52.22967605, Longitude = 21.01222912 };

            // Act
            string result = "";

            // Assert
            Assert.AreEqual("u3qcnhheumm9", result);
        }
    }
}
