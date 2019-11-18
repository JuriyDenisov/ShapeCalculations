using System;
using System.Collections.Generic;
using ShapeCalculations.Exceptions;
using ShapeCalculations.Models;
using ShapeCalculations.Models.Enums;
using ShapeCalculations.Services;
using Xunit;

namespace ShapeCalculations.Tests
{

    /// <summary>
    /// Класс для создания контекста общего для всех тестов
    /// </summary>
    public class ShapeCalculationServiceFixture
    {
        public ShapeCalculationService CalculationService { get; }

        public ShapeCalculationServiceFixture()
        {
            CalculationService = new ShapeCalculationService();
        }
    }

    /// <summary>
    /// Тестирование класса ShapeCalculationService
    /// </summary>
    public class ShapeCalculationServiceTests : IClassFixture<ShapeCalculationServiceFixture>
    {

        #region Fields

        private readonly ShapeCalculationService _calculationService;

        private readonly TestCircleData _validCircleData;
        private readonly TestTriangleData _validTriangleData;

        private readonly Circle _wrongCircle;

        #endregion


        #region Constructors

        public ShapeCalculationServiceTests(ShapeCalculationServiceFixture calculationServiceFixture)
        {
            _calculationService = calculationServiceFixture.CalculationService;

            _validCircleData = GetValidCircleData();
            _validTriangleData = GetValidTriangleData();

            _wrongCircle = GetWrongCirce();
        }

        #endregion


        #region Test methods

        #region Testing Validate method

        [Fact]
        public void Validate_CircleIn_CircleValidated()
        {
            // Arrange
            var circle = _validCircleData.Circle;

            // Act
            _calculationService.Validate(circle);

            // Assert
            Assert.True(circle.Validated);
        }

        [Fact]
        public void Validate_TriangleIn_TriangleValidated()
        {
            // Arrange
            var triangle = _validTriangleData.Triangle;

            // Act
            _calculationService.Validate(triangle);

            // Assert
            Assert.True(triangle.Validated);
        }

        [Fact]
        public void Validate_NullIn_ThrowException()
        {
            // Act
            var exception = Record.Exception(() => _calculationService.Validate(null));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void Validate_WrongCircleIn_ThrowException()
        {
            // Act
            var exception = Record.Exception(() => _calculationService.Validate(_wrongCircle));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ShapeModelWrongException>(exception);
        }

        [Theory]
        [MemberData(nameof(WrongTriangles))]
        public void Validate_WrongTriangleIn_ThrowException(Triangle wrongTriangle)
        {
            // Act
            var exception = Record.Exception(() => _calculationService.Validate(wrongTriangle));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ShapeModelWrongException>(exception);
        }

        #endregion

        #region Testing FindArea method

        [Fact]
        public void FindArea_CircleIn_CircleValidated()
        {
            // Arrange
            var circle = _validCircleData.Circle;

            // Act
            _calculationService.FindArea(circle);

            // Assert
            Assert.True(circle.Validated);
        }

        [Fact]
        public void FindArea_CircleIn_AreaCalculated()
        {
            // Arrange
            var circle = _validCircleData.Circle;

            // Act
            _calculationService.FindArea(circle);

            // Assert
            Assert.Equal(_validCircleData.CorrectArea, circle.Area);
        }

        [Fact]
        public void FindArea_TriangleIn_TriangleValidated()
        {
            // Arrange
            var triangle = _validTriangleData.Triangle;

            // Act
            _calculationService.FindArea(triangle);

            // Assert
            Assert.True(triangle.Validated);
        }

        [Fact]
        public void FindArea_TriangleIn_AreaCalculated()
        {
            // Arrange
            var triangle = _validTriangleData.Triangle;

            // Act
            _calculationService.FindArea(triangle);

            // Assert
            Assert.Equal(_validTriangleData.CorrectArea, triangle.Area);
        }

        [Fact]
        public void FindArea_NullIn_ThrowException()
        {
            // Act
            var exception = Record.Exception(() => _calculationService.FindArea(null));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void FindArea_WrongCircleIn_ThrowException()
        {
            // Act
            var exception = Record.Exception(() => _calculationService.FindArea(_wrongCircle));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ShapeModelWrongException>(exception);
        }

        [Theory]
        [MemberData(nameof(WrongTriangles))]
        public void FindArea_WrongTriangleIn_ThrowException(Triangle wrongTriangle)
        {
            // Act
            var exception = Record.Exception(() => _calculationService.FindArea(wrongTriangle));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ShapeModelWrongException>(exception);
        }

        #endregion

        #region Testing DefineType method

        [Fact]
        public void DefineType_CircleIn_NoException()
        {
            // Arrange
            var circle = _validCircleData.Circle;

            // Act
            var exception = Record.Exception(() => _calculationService.DefineType(circle));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void DefineType_CircleIn_CircleValidated()
        {
            // Arrange
            var circle = _validCircleData.Circle;

            // Act
            _calculationService.DefineType(circle);

            // Assert
            Assert.True(circle.Validated);
        }

        [Fact]
        public void DefineType_TriangleIn_TriangleValidated()
        {
            // Arrange
            var triangle = _validTriangleData.Triangle;

            // Act
            var exception = Record.Exception(() => _calculationService.DefineType(triangle));

            // Assert
            Assert.True(triangle.Validated);
        }

        [Theory]
        [MemberData(nameof(TrianglesWithTypes))]
        public void DefineType_TriangleIn_TypeDefinedCorrectly(Triangle triangle, TriangleTypeByAngles typeByAngles, TriangleTypeBySideLengths typeBySideLengths)
        {
            // Act
            _calculationService.DefineType(triangle);

            // Assert
            Assert.Equal(typeByAngles, triangle.TypeByAngles);
            Assert.Equal(typeBySideLengths, triangle.TypeBySideLengths);
        }

        [Fact]
        public void DefineType_NullIn_ThrowException()
        {
            // Act
            var exception = Record.Exception(() => _calculationService.DefineType(null));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void DefineType_WrongCircleIn_ThrowException()
        {
            // Act
            var exception = Record.Exception(() => _calculationService.DefineType(_wrongCircle));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ShapeModelWrongException>(exception);
        }

        [Theory]
        [MemberData(nameof(WrongTriangles))]
        public void DefineType_WrongTriangleIn_ThrowException(Triangle wrongTriangle)
        {
            // Act
            var exception = Record.Exception(() => _calculationService.DefineType(wrongTriangle));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ShapeModelWrongException>(exception);
        }

        #endregion

        #region Testing CalculateAll method

        [Fact]
        public void CalculateAll_CircleIn_AllCalculated()
        {
            // Arrange
            var circle = _validCircleData.Circle;

            // Act
            _calculationService.CalculateAll(circle);

            // Assert
            Assert.True(circle.Validated);
            Assert.Equal(_validCircleData.CorrectArea, circle.Area);
        }

        [Fact]
        public void CalculateAll_TriangleIn_AllCalculated()
        {
            // Arrange
            var triangle = _validTriangleData.Triangle;

            // Act
            _calculationService.CalculateAll(triangle);

            // Assert
            Assert.True(triangle.Validated);
            Assert.Equal(_validTriangleData.CorrectArea, triangle.Area);
            Assert.Equal(_validTriangleData.CorrectTypeByAngles, triangle.TypeByAngles);
            Assert.Equal(_validTriangleData.CorrectTypeBySideLengths, triangle.TypeBySideLengths);
        }

        [Fact]
        public void CalculateAll_NullIn_ThrowException()
        {
            // Act
            var exception = Record.Exception(() => _calculationService.CalculateAll(null));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ArgumentNullException>(exception);
        }

        [Fact]
        public void CalculateAll_WrongCircleIn_ThrowException()
        {
            // Act
            var exception = Record.Exception(() => _calculationService.CalculateAll(_wrongCircle));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ShapeModelWrongException>(exception);
        }

        [Theory]
        [MemberData(nameof(WrongTriangles))]
        public void CalculateAll_WrongTriangleIn_ThrowException(Triangle wrongTriangle)
        {
            // Act
            var exception = Record.Exception(() => _calculationService.CalculateAll(wrongTriangle));

            // Assert
            Assert.NotNull(exception);
            Assert.IsType<ShapeModelWrongException>(exception);
        }

        #endregion


        #endregion


        #region Test Data

        /// <summary>
        /// Возвращает круг с корректными размерами и верно вычисленной площадью
        /// </summary>
        static TestCircleData GetValidCircleData()
        {
            return new TestCircleData
            {
                Circle = new Circle(15d),
                CorrectArea = 706.8583470577034d,
            };
        }

        /// <summary>
        /// Возвращает треугольник с корректными размерами и верно вычисленными характеристиками
        /// </summary>
        static TestTriangleData GetValidTriangleData()
        {
            return new TestTriangleData
            {
                Triangle = new Triangle(11d, 17d, 21d),
                CorrectArea = 93.17825658381895d,
                CorrectTypeByAngles = TriangleTypeByAngles.Obtuse,
                CorrectTypeBySideLengths = TriangleTypeBySideLengths.Scalene,
            };
        }

        /// <summary>
        /// Возвращает модель круга с некорректными размерами
        /// </summary>
        static Circle GetWrongCirce()
        {
            return new Circle(-10d);
        }

        /// <summary>
        /// Треугольники с недопустимыми размерами, чья передача должна приводить к выбросу исключения
        /// </summary>
        public static IEnumerable<object[]> WrongTriangles =>
            new List<object[]>
            {
                new object[] { new Triangle(null)  },
                new object[] { new Triangle(new double[0])  },
                new object[] { new Triangle(new []{ 13d })  },
                new object[] { new Triangle(new []{ 13d, 14d })  },
                new object[] { new Triangle(new []{ 13d, 14d, 17d, 19d })  },
                new object[] { new Triangle(12d, 0, 17d)  },
                new object[] { new Triangle(12d, 15d, -20d)  },
                new object[] { new Triangle(3d, 20d, 7d)  },
                new object[] { new Triangle(25d, 5d, 5d)  },
            };

        /// <summary>
        /// Треугольники с указанными типами
        /// </summary>
        public static IEnumerable<object[]> TrianglesWithTypes =>
            new List<object[]>
            {
                new object[] { new Triangle(5d, 5d, 5d), TriangleTypeByAngles.Acute, TriangleTypeBySideLengths.Equilateral },
                new object[] { new Triangle(3d, 4d, 5d), TriangleTypeByAngles.Right, TriangleTypeBySideLengths.Scalene },
                new object[] { new Triangle(3d, 4d, 6d), TriangleTypeByAngles.Obtuse, TriangleTypeBySideLengths.Scalene },
                new object[] { new Triangle(4d, 4d, 5d), TriangleTypeByAngles.Acute, TriangleTypeBySideLengths.Isosceles },
            };

        #endregion

    }


    #region Helper classes

    class TestCircleData
    {
        public Circle Circle { get; set; }
        public double CorrectArea { get; set; }
    }

    class TestTriangleData
    {
        public Triangle Triangle { get; set; }
        public double CorrectArea { get; set; }
        public TriangleTypeByAngles CorrectTypeByAngles { get; set; }
        public TriangleTypeBySideLengths CorrectTypeBySideLengths { get; set; }
    }

    #endregion

}
