using System;
using ShapeCalculations.Models;
using ShapeCalculations.Services.Interfaces;
using ShapeCalculations.Services.ShapeCalculators;

namespace ShapeCalculations.Services
{

    /// <summary>
    /// Фабрика, которая возвращает объект умеющий выполнять различные вычисления для данной фигуры
    /// </summary>
    public class CalculatorsFactory : ICalculatorsFactory
    {

        #region ICalculatorsFactory implementation

        /// <summary>
        /// Возвращает вычислитель для данной фигуры, инициализированный проверенной моделью и готовый к работе
        /// </summary>
        /// <param name="shape">Модель фигуры</param>
        /// <returns>Вычислитель инициализированный проверенной моделью фигуры</returns>
        public IShapeCalculator GetCalculator(Shape shape)
        {
            var calculator = Create(shape);

            calculator.Validate();

            return calculator;
        }

        #endregion


        #region Private methods

        /// <summary>
        /// Создает объект, который умеет выполнять расчеты для данной фигуры.
        /// </summary>
        /// <param name="shape">Модель фигуры</param>
        /// <returns>Объект с операциями вычисления для фигуры</returns>
        private IShapeCalculator Create(Shape shape)
        {
            return shape switch
            {
                null => throw new ArgumentNullException(nameof(shape), "Не задана фигура для обсчета."),
                Circle circle => new CircleCalculator(circle),
                Triangle triangle => new TriangleCalculator(triangle),
                _ => throw new ArgumentOutOfRangeException(nameof(shape), $"Обсчет фигуры с типом {shape.GetType()} не предусмотрен."),
            };
        }

        #endregion

    }
}
