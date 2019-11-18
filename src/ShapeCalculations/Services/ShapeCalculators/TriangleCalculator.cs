using System;
using System.Linq;
using ShapeCalculations.Exceptions;
using ShapeCalculations.Models;
using ShapeCalculations.Models.Enums;

namespace ShapeCalculations.Services.ShapeCalculators
{
    /// <summary>
    /// Класс выполняет расчеты для треугольника.
    /// </summary>
    internal class TriangleCalculator : ShapeCalculator<Triangle>
    {

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="triangle">Модель треугольника</param>
        public TriangleCalculator(Triangle triangle) : base(triangle)
        {
        }

        #endregion


        #region  Overrides

        /// <summary>
        /// Проверить корректность модели
        /// </summary>
        protected override void ValidateShape()
        {
            if (Shape == null)
            {
                throw new ShapeModelWrongException("Не задана модель треугольника для расчета.");
            }

            if (Shape.Sides == null)
            {
                throw new ShapeModelWrongException("В модели треугольника не заданы стороны.", Shape);
            }

            if (Shape.Sides.Length != 3)
            {
                throw new ShapeModelWrongException($"У треугольника должно быть 3 стороны. В модели задано - {Shape.Sides.Length}.", Shape);
            }

            if (Shape.Sides.Any(x => x < double.Epsilon))
            {
                throw new ShapeModelWrongException("Сторона треугольника не может иметь отрицательное или нулевое значение.", Shape);
            }

            var sides = Shape.Sides.OrderBy(x => x).ToArray();
            if (sides[0] + sides[1] <= sides[2])
            {
                throw new ShapeModelWrongException($"Сумма двух сторон треугольника {sides[0]} + {sides[1]} должна превышать третью {sides[2]}.", Shape);
            }
        }

        /// <summary>
        /// Вычислить площадь
        /// </summary>
        protected override void FindShapeArea()
        {
            var sideA = Shape.Sides[0];
            var sideB = Shape.Sides[1];
            var sideC = Shape.Sides[2];

            var semiPerimeter = Shape.Sides.Sum() / 2;

            Shape.Area = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));
        }

        /// <summary>
        /// Выполнить классификацию фигуры
        /// </summary>
        protected override void DefineShapeType()
        {
            Shape.TypeByAngles = GetTypeByAngles();
            Shape.TypeBySideLengths = GetTypeBySideLengths();
        }

        #endregion


        #region Private methods

        /// <summary>
        /// Возвращает классификацию треугольника по величине углов
        /// </summary>
        private TriangleTypeByAngles GetTypeByAngles()
        {
            var squaredSides = Shape.Sides.Select(x => Math.Pow(x, 2)).OrderBy(x => x).ToArray();

            var sumOfSmallest = squaredSides[0] + squaredSides[1];
            var largestSide = squaredSides[2];

            if (largestSide < sumOfSmallest)
            {
                return TriangleTypeByAngles.Acute;
            }

            return largestSide > sumOfSmallest ? TriangleTypeByAngles.Obtuse : TriangleTypeByAngles.Right;
        }

        /// <summary>
        /// Возвращает классификацию треугольника по соотношению длин сторон
        /// </summary>
        private TriangleTypeBySideLengths GetTypeBySideLengths()
        {
            var differentSideCount = Shape.Sides.Distinct().Count();

            return differentSideCount switch
            {
                1 => TriangleTypeBySideLengths.Equilateral,
                2 => TriangleTypeBySideLengths.Isosceles,
                3 => TriangleTypeBySideLengths.Scalene,
                _ => throw new Exception($"Непредвиденное количество отличающихся сторон у треугольника - {differentSideCount}.")
            };
        }

        #endregion

    }
}
