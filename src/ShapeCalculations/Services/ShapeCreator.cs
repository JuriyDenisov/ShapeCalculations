using System;
using System.Linq;
using ShapeCalculations.Models;
using ShapeCalculations.Services.Interfaces;

namespace ShapeCalculations.Services
{
    /// <summary>
    /// Создает фигуру, самостоятельно определяя нужный тип по количеству входных параметров
    /// </summary>
    public class ShapeCreator : IShapeCreator
    {

        #region IShapeCreator implementation

        /// <summary>
        /// Создает и возвращает фигуру с заданными размерами. Результирующий тип фигуры определяется количеством входящих параметров
        /// </summary>
        /// <param name="shapeSizes">Размеры фигуры</param>
        /// <returns>Фигура с заданными размерами</returns>
        public Shape GetShape(params double[] shapeSizes)
        {
            if (shapeSizes == null || shapeSizes.Length == 0)
            {
                throw new ArgumentNullException(nameof(shapeSizes), "Не указаны линейные размеры фигуры.");
            }

            if (shapeSizes.Any(x => x < double.Epsilon))
            {
                throw new ArgumentOutOfRangeException(nameof(shapeSizes), "Размер фигуры не может быть нулевым или отрицательным.");
            }

            var sizeCount = shapeSizes.Length;

            return sizeCount switch
            {
                1 => new Circle(shapeSizes[0]),
                3 => new Triangle(shapeSizes),
                _ => throw new ArgumentOutOfRangeException(nameof(shapeSizes), $"Не предусмотрено создание фигуры с {sizeCount} линейными размерами"),
            };
        }

        #endregion

    }
}
