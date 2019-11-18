using System;
using ShapeCalculations.Exceptions;
using ShapeCalculations.Models;

namespace ShapeCalculations.Services.ShapeCalculators
{
    /// <summary>
    /// Класс выполняет расчеты для круга.
    /// </summary>
    internal class CircleCalculator : ShapeCalculator<Circle>
    {

        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="circle">Модель круга</param>
        public CircleCalculator(Circle circle) : base(circle)
        {
        }

        #endregion


        #region IShapeCalculator implementation

        /// <summary>
        /// Проверить корректность модели
        /// </summary>
        protected override void ValidateShape()
        {
            if (Shape == null)
            {
                throw new ShapeModelWrongException("Не задана модель круга для расчета.");
            }

            if (Shape.Radius < 0)
            {
                throw new ShapeModelWrongException("Радиус круга не может быть отрицательным.", Shape);
            }
        }

        /// <summary>
        /// Вычислить площадь
        /// </summary>
        protected override void FindShapeArea()
        {
            Shape.Area = Math.PI * Math.Pow(Shape.Radius, 2);
        }

        /// <summary>
        /// Выполнить классификацию фигуры
        /// </summary>
        protected override void DefineShapeType()
        {
            // У круга нет подтипов, так как он определяется только одним линейным размером
        }

        #endregion

    }
}
