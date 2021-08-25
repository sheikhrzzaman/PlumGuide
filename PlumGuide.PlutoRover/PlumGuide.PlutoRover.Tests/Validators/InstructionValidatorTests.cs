using Calculator.Validations;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlumGuide.PlutoRover.Tests.Validators
{
    [TestClass]
    public class InstructionValidatorTests
    {
        private InstructionValidator _validator;
        private char[] _instructions;

        [TestInitialize]
        public void TestInit()
        {
            _validator = new InstructionValidator();

            _instructions = new char[] { 'B', 'F', 'L', 'R' };
        }

        [TestMethod]
        public void WhenRequestIsValid_ThenValidationPasses()
        {
            // Arrange

            // Act
            var result = _validator.Validate(_instructions);

            // Assert
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void WhenRequestIsInvalid_InstructionEmpty_ThenValidationFails()
        {
            // Arrange
            _instructions = new char[] { };

            // Act
            var result = _validator.Validate(_instructions);

            // Assert
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void WhenRequestIsInvalid_ThenValidationFails()
        {
            // Arrange
            _instructions = new char[] { 'T' };

            // Act
            var result = _validator.Validate(_instructions);

            // Assert
            Assert.IsFalse(result.IsValid);
        }
    }
}
