using System;
using System.Collections.Generic;
using ShapeCalculations.Models;
using ShapeCalculations.Services;
using Xunit;

namespace ShapeCalculations.Tests
{
    /// <summary>
    ///  ласс дл€ создани€ контекста общего дл€ всех тестов
    /// </summary>
    public class ShapeCreatorFixture
    {
        public ShapeCreator ShapeCreator { get; }

        public ShapeCreatorFixture()
        {
            ShapeCreator = new ShapeCreator();
        }
    }

    /// <summary>
    /// “естирование класса ShapeCreator
    /// </summary>
    public class ShapeCreatorTests : IClassFixture<ShapeCreatorFixture>
    {

        #region Fields

        private readonly ShapeCreator _shapeCreator;

        #endregion

        #region Constructors

        public ShapeCreatorTests(ShapeCreatorFixture shapeCreatorFixture)
        {
            _shapeCreator = shapeCreatorFixture.ShapeCreator;
        }

        #endregion


        #region Test methods

        [Fact]
        public void GetShape_CreateCircle_Success()
        {
            // Arrange
            const double radius = 12d;

            // Act
            var shape = _shapeCreator.GetShape(radius);

            // Assert
            var circle = shape as Circle;
            Assert.NotNull(circle);
            Assert.Equal(radius, circle.Radius);
        }

        [Fact]
        public void GetShape_CreateTriangleBySides_Success()
        {
            // Arrange
            const double sideA = 12d;
            const double sideB = 17d;
            const double sideC = 14d;

            // Act
            var shape = _shapeCreator.GetShape(sideA, sideB, sideC);

            // Assert
            var triangle = shape as Triangle;
            Assert.NotNull(triangle);
            Assert.Equal(sideA, triangle.Sides[0]);
            Assert.Equal(sideB, triangle.Sides[1]);
            Assert.Equal(sideC, triangle.Sides[2]);
        }

        [Fact]
        public void GetShape_CreateTriangleByArray_Success()
        {
            // Arrange
            var sides = new[] { 12d, 17d, 14d };

            // Act
            var shape = _shapeCreator.GetShape(sides);

            // Assert
            var triangle = shape as Triangle;
            Assert.NotNull(triangle);
            Assert.Equal(sides, triangle.Sides);
        }

        [Theory]
        [InlineData(null)]
        [InlineData(new double[0])]
        public void GetShape_ArgumentNull_ThrowException(double[] shapeSizes)
        {
            // Act
            var exception = Record.Exception(() => _shapeCreator.GetShape(shapeSizes));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Theory]
        [MemberData(nameof(WrongSizes))]
        public void GetShape_ArgumentsWrong_ThrowException(params double[] shapeSizes)
        {
            // Act
            var exception = Record.Exception(() => _shapeCreator.GetShape(shapeSizes));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ArgumentOutOfRangeException>(exception);
        }

        #endregion


        #region Test Data

        /// <summary>
        /// Ќеверные наборы размеров, чь€ передача должна приводить к выбросу исключени€
        /// </summary>
        public static IEnumerable<object[]> WrongSizes =>
            new List<object[]>
            {
                new object[] { -12d },
                new object[] { 0d },
                new object[] { 12d, 17d },
                new object[] { 12d, 17d, -10d },
                new object[] { 12d, -17d, 10d },
                new object[] { -12d, 17d, 10d },
                new object[] { -12d, -17d, -10d },
                new object[] { 12d, 17d, 0d },
                new object[] { 12d, 0d, 10d },
                new object[] { 0d, 17d, 10d },
                new object[] { 0d, 0d, 0d },
                new object[] { 12d, 17d, 10d, 19d },
                new object[] { 12d, 17d, 10d, 19d, 27d },
                new object[] { 12d, 17d, 10d, 19d, 27d, 31d },
            };

        #endregion

    }
}
