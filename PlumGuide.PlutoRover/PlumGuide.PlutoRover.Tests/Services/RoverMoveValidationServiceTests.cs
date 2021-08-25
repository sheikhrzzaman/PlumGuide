using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using PlumGuide.PlutoRover.Models;
using PlumGuide.PlutoRover.Services;
using System.Collections.Generic;

namespace PlumGuide.PlutoRover.Tests.Services
{
    [TestClass]
    public class RoverMoveValidationServiceTests
    {
        private Mock<IPlutoBoundaryService> _mockPlutoBoundaryService;
        private Mock<IPlutoObstableLocationService> _mockPlutoObstableLocationService;

        private IRoverMoveValidationService _roverMoveValidationService;

        private List<RoverPosition> _plutoBoundaries;
        private List<RoverPosition> _plutoObstables;

        private RoverPosition _roverPosition;

        [TestInitialize]
        public void TestInit()
        {
            _roverPosition = new RoverPosition { PointX = 0, PointY = 0, Direction = "N" };
            
            _plutoBoundaries = new List<RoverPosition> 
            { 
                new RoverPosition { PointX = 100, PointY = 100, Direction = "N" } 
            };

            _plutoObstables = new List<RoverPosition>
            {
                new RoverPosition { PointX = 2, PointY = 2, Direction = "S" }
            };

            _mockPlutoBoundaryService = new Mock<IPlutoBoundaryService>();
            _mockPlutoObstableLocationService = new Mock<IPlutoObstableLocationService>();

            _mockPlutoBoundaryService.Setup(x => x.GetBoundaries()).Returns(_plutoBoundaries);
            _mockPlutoObstableLocationService.Setup(x => x.GetObstableLocations()).Returns(_plutoObstables);

            _roverMoveValidationService = new RoverMoveValidationService(
                _mockPlutoBoundaryService.Object,
                _mockPlutoObstableLocationService.Object);

        }

        [TestMethod]
        public void IsValidMove_WhenBoundaryNotReachAndNoObstables_ThenReturnTrue()
        {
            // Arrange

            // Act
            var (isValid, message) = _roverMoveValidationService.IsValidMove(_roverPosition);

            // Assert
            Assert.IsTrue(isValid);
            Assert.IsNull(message);
            _mockPlutoBoundaryService.Verify(x => x.GetBoundaries(), Times.Once);
            _mockPlutoObstableLocationService.Verify(x => x.GetObstableLocations(), Times.Once);
        }

        [TestMethod]
        public void IsValidMove_WhenObstableFound_ThenReturnFalse()
        {
            // Arrange
            _plutoBoundaries.Add(_roverPosition);
            _mockPlutoBoundaryService.Reset();
            _mockPlutoObstableLocationService.Setup(x => x.GetObstableLocations()).Returns(_plutoBoundaries);

            // Act
            var (isValid, message) = _roverMoveValidationService.IsValidMove(_roverPosition);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsNotNull(message);
        }

        [TestMethod]
        public void IsValidMove_WhenPlutoBoundaryReachred_ThenReturnFalse()
        {
            // Arrange
            _plutoBoundaries.Add(_roverPosition);
            _mockPlutoBoundaryService.Reset();
            _mockPlutoBoundaryService.Setup(x => x.GetBoundaries()).Returns(_plutoBoundaries);

            // Act
            var (isValid, message) = _roverMoveValidationService.IsValidMove(_roverPosition);

            // Assert
            Assert.IsFalse(isValid);
            Assert.IsNotNull(message);
        }
    }
}
