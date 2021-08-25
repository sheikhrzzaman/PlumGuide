using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlumGuide.PlutoRover.Services;
using Moq;
using PlumGuide.PlutoRover.Processors;
using PlumGuide.PlutoRover.Models;

namespace PlumGuide.PlutoRover.Tests.Processors
{
    [TestClass]
    public class InstructionProcessorTests
    {
        private Mock<IRoverMoveServiceFactory> _mockRoverMoveServiceFactory;
        private Mock<IRoverPositionService> _mockRoverPositionService;
        private Mock<IRoverMoveValidationService> _mockRoverMoveValidationService;
        private Mock<IRoverMoveService> _mockRoverMoveService;

        private IInstructionProcessor _processor;

        private char[] _instructions;

        private RoverPosition _roverPosition;

        [TestInitialize]
        public void TestInit()
        {
            _roverPosition = new RoverPosition { PointX = 0, PointY = 0, Direction = "N" };
            _instructions = new char[] { 'F' };

            _mockRoverMoveServiceFactory = new Mock<IRoverMoveServiceFactory>();
            _mockRoverPositionService = new Mock<IRoverPositionService>();
            _mockRoverMoveValidationService = new Mock<IRoverMoveValidationService>();

            _mockRoverMoveService = new Mock<IRoverMoveService>();

            _mockRoverMoveServiceFactory.Setup(x => x.GetRoverMoveService(It.IsAny<string>()))
                                        .Returns(_mockRoverMoveService.Object);

            _mockRoverPositionService.Setup(x => x.GetRoverCurrentPosition())
                                     .Returns(new RoverPosition());
            _mockRoverMoveValidationService.Setup(x => x.IsValidMove(It.IsAny<RoverPosition>()))
                                           .Returns((true, string.Empty));

            _mockRoverMoveService.Setup(x => x.Move(It.IsAny<RoverPosition>()))
                                 .Returns(_roverPosition);

            _processor = new InstructionProcessor(
                _mockRoverMoveServiceFactory.Object,
                _mockRoverPositionService.Object,
                _mockRoverMoveValidationService.Object);

        }

        [TestMethod]
        public void Process_WhenSuccess_ThenNewPositionRetrun()
        {
            // Arrange

            // Act
            var (roverPosition, message) = _processor.Process(_instructions);

            // Assert
            Assert.AreEqual(roverPosition, _roverPosition);
            Assert.IsTrue(string.IsNullOrWhiteSpace(message));

            _mockRoverPositionService.Verify(x => x.GetRoverCurrentPosition(), Times.Once);
            _mockRoverPositionService.Verify(x => x.SaveRoverCurrentPosition(_roverPosition), Times.Once);
            _mockRoverMoveValidationService.Verify(x => x.IsValidMove(_roverPosition), Times.Once);
            _mockRoverMoveService.Verify(x => x.Move(It.IsAny<RoverPosition>()), Times.Once);
        }

        [TestMethod]
        public void Process_WhenTwoInstructionsAndSuccess_ThenMoveServiceCalledTwice()
        {
            // Arrange
            _instructions = new char[] { 'F', 'R' };

            // Act
            var (roverPosition, message) = _processor.Process(_instructions);

            // Assert
            Assert.AreEqual(roverPosition, _roverPosition);

            _mockRoverMoveService.Verify(x => x.Move(It.IsAny<RoverPosition>()), Times.Exactly(2));
        }

    }
}
