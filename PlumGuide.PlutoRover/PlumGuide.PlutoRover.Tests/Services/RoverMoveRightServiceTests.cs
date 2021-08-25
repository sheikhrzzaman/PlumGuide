using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlumGuide.PlutoRover.Models;
using PlumGuide.PlutoRover.Services;

namespace PlumGuide.PlutoRover.Tests.Services
{
    [TestClass]
    public class RoverMoveRightServiceTests
    {
        [TestMethod]
        [DataRow("N", "E")]
        [DataRow("E", "S")]
        [DataRow("S", "W")]
        [DataRow("W", "N")]
        public void WhenMove_ThenCorrectPositionReturn(string direction, string expectedDirection)
        {
            // Arrange
             var roverPosition = new RoverPosition { PointX = 0, PointY = 0, Direction = direction };
             var roverMoveService = new RoverMoveRightService();

            // Act
            var result = roverMoveService.Move(roverPosition);

            // Assert
            Assert.AreEqual(expectedDirection, result.Direction);
            Assert.AreEqual(roverPosition.PointX, result.PointX);
            Assert.AreEqual(roverPosition.PointY, result.PointY);
        }
    }
}
