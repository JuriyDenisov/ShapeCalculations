using Moq;
using ShapeCalculations.Models;
using ShapeCalculations.Services.ShapeCalculators;
using Xunit;

namespace ShapeCalculations.Tests
{
    /// <summary>
    /// Тестирование класса ShapeCalculator
    /// </summary>
    public class ShapeCalculatorTests
    {

        #region Fields

        private readonly Circle _testShape;
        private readonly Mock<ShapeCalculator<Circle>> _shapeCalculatorMock;
        private readonly ShapeCalculator<Circle> _shapeCalculator;

        #endregion


        #region Constructors

        public ShapeCalculatorTests()
        {
            _testShape = new Circle(15d);
            _shapeCalculatorMock = new Mock<ShapeCalculator<Circle>>(_testShape);
            _shapeCalculator = _shapeCalculatorMock.Object;
        }

        #endregion


        #region Test methods

        [Fact]
        public void Validate_Called_ValidatedFlagTrue()
        {
            // Act
            _shapeCalculator.Validate();

            // Assert
            Assert.True(_testShape.Validated);
        }

        [Fact]
        public void Validate_ValidatedShapeIn_DoNothing()
        {
            // Arrange
            _testShape.Validated = true;

            // Act
            _shapeCalculator.Validate();

            // Assert
            Assert.True(_shapeCalculatorMock.Invocations.Count == 0);
        }

        [Fact]
        public void FindArea_Called_ShapeValidated()
        {
            // Act
            _shapeCalculator.FindArea();

            // Assert
            Assert.True(_testShape.Validated);
        }

        [Fact]
        public void DefineType_Called_ShapeValidated()
        {
            // Act
            _shapeCalculator.DefineType();

            // Assert
            Assert.True(_testShape.Validated);
        }

        #endregion

    }
}
