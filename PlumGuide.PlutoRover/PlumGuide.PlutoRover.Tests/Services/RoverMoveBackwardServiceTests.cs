using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlumGuide.PlutoRover.Models;
using PlumGuide.PlutoRover.Services;

namespace PlumGuide.PlutoRover.Tests.Services
{
    [TestClass]
    public class RoverMoveBackwardServiceTests
    {
        [TestMethod]
        [DataRow("N",0, -1)]
        [DataRow("E", -1, 0)]
        [DataRow("S", 0, 1)]
        [DataRow("W", 1, 0)]
        public void WhenMove_ThenCorrectPositionReturn(string direction, int expectedPointX, int expectedPointY)
        {
            // Arrange
            var roverPosition = new RoverPosition { PointX = 0, PointY = 0, Direction = direction };
            IRoverMoveService roverMoveService = new RoverMoveBackwardService();

            // Act
            var result = roverMoveService.Move(roverPosition);

            // Assert
            Assert.AreEqual(roverPosition.Direction, result.Direction);
            Assert.AreEqual(expectedPointX, result.PointX);
            Assert.AreEqual(expectedPointY, result.PointY);
        }
    }
}
