using ShapeCalculations.Models;

namespace ShapeCalculations.Services.Interfaces
{
    /// <summary>
    /// Контракт определяющий какие вычисления доступны для фигур
    /// </summary>
    public interface IShapeCalculationService
    {

        /// <summary>
        /// Проверить корректность модели
        /// </summary>
        /// <param name="shape">Модель фигуры</param>
        void Validate(Shape shape);

        /// <summary>
        /// Вычислить площадь
        /// </summary>
        /// <param name="shape">Модель фигуры</param>
        void FindArea(Shape shape);

        /// <summary>
        /// Выполнить классификацию фигуры
        /// </summary>
        /// <param name="shape">Модель фигуры</param>
        void DefineType(Shape shape);

        /// <summary>
        /// Выполнить все доступные вычисления с фигурой
        /// </summary>
        /// <param name="shape">Модель фигуры</param>
        void CalculateAll(Shape shape);

    }
}
