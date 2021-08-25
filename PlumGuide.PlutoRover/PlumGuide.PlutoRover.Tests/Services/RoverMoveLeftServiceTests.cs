using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlumGuide.PlutoRover.Models;
using PlumGuide.PlutoRover.Services;

namespace PlumGuide.PlutoRover.Tests.Services
{
    [TestClass]
    public class RoverMoveLeftServiceTests
    {
        [TestMethod]
        [DataRow("N","W")]
        [DataRow("E", "N")]
        [DataRow("S", "E")]
        [DataRow("W", "S")]
        public void WhenMove_ThenCorrectPositionReturn(string direction, string expectedDirection)
        {
            // Arrange
            var roverMoveService = new RoverMoveLeftService();
            var roverPosition = new RoverPosition { PointX = 0, PointY = 0, Direction = direction };

            // Act
            var result = roverMoveService.Move(roverPosition);

            // Assert
            Assert.AreEqual(expectedDirection, result.Direction);
            Assert.AreEqual(roverPosition.PointX, result.PointX);
            Assert.AreEqual(roverPosition.PointY, result.PointY);
        }
    }
}
