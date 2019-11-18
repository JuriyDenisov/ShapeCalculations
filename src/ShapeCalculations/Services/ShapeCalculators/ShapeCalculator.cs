using ShapeCalculations.Models;
using ShapeCalculations.Services.Interfaces;

namespace ShapeCalculations.Services.ShapeCalculators
{
    /// <summary>
    /// Базовый класс расчетов для фигуры
    /// </summary>
    public abstract class ShapeCalculator<TShape> : IShapeCalculator
        where TShape: Shape
    {

        #region Fields

        /// <summary>
        /// Фигура
        /// </summary>
        protected TShape Shape;

        #endregion


        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="shape">Фигура</param>
        protected ShapeCalculator(TShape shape)
        {
            Shape = shape;
        }

        #endregion


        #region Public methods

        /// <summary>
        /// Проверить корректность модели
        /// </summary>
        public void Validate()
        {
            if (Shape.Validated)
            {
                return;
            }

            ValidateShape();

            Shape.Validated = true;
        }

        /// <summary>
        /// Вычислить площадь
        /// </summary>
        public void FindArea()
        {
            Validate();

            FindShapeArea();
        }

        /// <summary>
        /// Выполнить классификацию фигуры
        /// </summary>
        public void DefineType()
        {
            Validate();

            DefineShapeType();
        }

        #endregion


        #region Abstract methods

        /// <summary>
        /// Проверить корректность модели
        /// </summary>
        protected abstract void ValidateShape();

        /// <summary>
        /// Вычислить площадь
        /// </summary>
        protected abstract void FindShapeArea();

        /// <summary>
        /// Выполнить классификацию фигуры
        /// </summary>
        protected abstract void DefineShapeType();

        #endregion

    }
}
