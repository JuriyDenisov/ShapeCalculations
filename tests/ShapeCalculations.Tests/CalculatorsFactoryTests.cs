using System;
using Moq;
using ShapeCalculations.Models;
using ShapeCalculations.Services;
using Xunit;

namespace ShapeCalculations.Tests
{
    /// <summary>
    /// Класс для создания контекста общего для всех тестов
    /// </summary>
    public class CalculatorsFactoryFixture
    {
        public CalculatorsFactory CalculatorsFactory { get; }

        public CalculatorsFactoryFixture()
        {
            CalculatorsFactory = new CalculatorsFactory();
        }
    }

    /// <summary>
    /// Тестирование класса CalculatorsFactory
    /// </summary>
    public class CalculatorsFactoryTests : IClassFixture<CalculatorsFactoryFixture>
    {

        #region Fields

        private readonly CalculatorsFactory _calculatorsFactory;

        #endregion


        #region Constructors

        public CalculatorsFactoryTests(CalculatorsFactoryFixture calculatorsFactoryFixture)
        {
            _calculatorsFactory = calculatorsFactoryFixture.CalculatorsFactory;
        }

        #endregion


        #region Test methods

        [Fact]
        public void GetCalculator_GetCircleCalculator_Success()
        {
            // Arrange
            var circle = new Circle(15d);

            // Act
            var circleCalculator = _calculatorsFactory.GetCalculator(circle);

            // Assert
            Assert.NotNull(circleCalculator);
        }

        [Fact]
        public void GetCalculator_GetTriangleCalculator_Success()
        {
            // Arrange
            var triangle = new Triangle(15d, 17d, 23d);

            // Act
            var triangleCalculator = _calculatorsFactory.GetCalculator(triangle);

            // Assert
            Assert.NotNull(triangleCalculator);
        }

        [Fact]
        public void GetCalculator_ArgumentNull_ThrowException()
        {
            // Act
            var exception = Record.Exception(() => _calculatorsFactory.GetCalculator(null));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void GetCalculator_WrongShapeType_ThrowException()
        {
            // Arrange
            var shapeMock = new Mock<Shape>();
            var unknownShape = shapeMock.Object;

            // Act
            var exception = Record.Exception(() => _calculatorsFactory.GetCalculator(unknownShape));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ArgumentOutOfRangeException>(exception);
        }

        [Fact]
        public void GetCalculator_CalculatorCreated_ShapeValidated()
        {
            // Arrange
            var circle = new Circle(57d);

            // Act
            _calculatorsFactory.GetCalculator(circle);

            // Assert
            Assert.True(circle.Validated);
        }

        #endregion

    }
}
