using ShapeCalculations.Models;

namespace ShapeCalculations.Services.Interfaces
{
    /// <summary>
    /// Фабрика, которая возвращает объект умеющий выполнять различные вычисления для данной фигуры
    /// </summary>
    public interface ICalculatorsFactory
    {

        /// <summary>
        /// Возвращает вычислитель для данной фигуры, инициализированный проверенной моделью и готовый к работе
        /// </summary>
        /// <param name="shape">Модель фигуры</param>
        /// <returns>Вычислитель инициализированный проверенной моделью фигуры</returns>
        IShapeCalculator GetCalculator(Shape shape);

    }
}
