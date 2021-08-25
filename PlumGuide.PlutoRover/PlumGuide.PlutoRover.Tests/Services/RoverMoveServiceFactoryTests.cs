using Microsoft.VisualStudio.TestTools.UnitTesting;
using PlumGuide.PlutoRover.Services;
using System;
using System.Collections.Generic;

namespace PlumGuide.PlutoRover.Tests.Services
{
    [TestClass]
    public class RoverMoveServiceFactoryTests
    {
        RoverMoveServiceFactory _roverMoveServiceFactory;

        IRoverMoveService _roverMoveLeftService;
        IRoverMoveService _roverMoveRightService;

        [TestInitialize]
        public void TestInit()
        {
            _roverMoveLeftService = new RoverMoveLeftService();
            _roverMoveRightService = new RoverMoveRightService();

            var dictionaryMoveServices = new Dictionary<string, IRoverMoveService>
                {
                    { Constants.Move.Left, _roverMoveLeftService},
                    { Constants.Move.Right, _roverMoveRightService},
                };

            _roverMoveServiceFactory = new RoverMoveServiceFactory(dictionaryMoveServices);
        }

        [TestMethod]
        public void WhenServiceExits_ThenReturnCorrectService()
        {
            // Arrange

            // Act
            var operationService = _roverMoveServiceFactory.GetRoverMoveService(Constants.Move.Left);

            // Assert
            Assert.IsInstanceOfType(operationService, typeof(RoverMoveLeftService));
        }

        [TestMethod]
        public void WhenOperationNotExit_ThenThrowException()
        {
            // Arrange
            var moveKey = "A";
            var errorMessage = $"Move:{moveKey} not supported";

            // Act
            try
            {
                var operationService = _roverMoveServiceFactory.GetRoverMoveService(moveKey);
                Assert.Fail();
            }
            catch (Exception ex)
            {
                // Assert
                Assert.AreEqual(errorMessage, ex.Message);
                Assert.IsInstanceOfType(ex, typeof(NotSupportedException));
            }
        }
    }


}
