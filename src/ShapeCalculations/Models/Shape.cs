namespace ShapeCalculations.Models
{
    /// <summary>
    /// Базовая абстрактная фигура
    /// </summary>
    public abstract class Shape
    {

        #region Fields

        /// <summary>
        /// Корректность фигуры проверена
        /// </summary>
        public bool Validated { get; set; }

        /// <summary>
        /// Площадь
        /// </summary>
        public double? Area { get; set; }

        #endregion

    }
}
