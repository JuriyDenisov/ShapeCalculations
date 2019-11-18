using ShapeCalculations.Models;

namespace ShapeCalculations.Services.Interfaces
{
    /// <summary>
    /// Интерфейс создания фигуры нужного типа по указанному набору ее параметров
    /// </summary>
    public interface IShapeCreator
    {

        /// <summary>
        /// Создает и возвращает фигуру с заданными размерами. Результирующий тип фигуры определяется количеством входящих параметров
        /// </summary>
        /// <param name="shapeSizes">Размеры фигуры</param>
        /// <returns>Фигура с заданными размерами</returns>
        Shape GetShape(params double[] shapeSizes);

    }
}
