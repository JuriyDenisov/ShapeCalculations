namespace ShapeCalculations.Services.Interfaces
{
    /// <summary>
    /// Методы доступные у объекта умеющего обсчитывать фигуру
    /// </summary>
    public interface IShapeCalculator
    {

        /// <summary>
        /// Проверить корректность модели
        /// </summary>
        void Validate();

        /// <summary>
        /// Вычислить площадь
        /// </summary>
        void FindArea();

        /// <summary>
        /// Выполнить классификацию фигуры
        /// </summary>
        void DefineType();

    }
}
