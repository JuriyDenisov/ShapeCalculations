namespace ShapeCalculations.Models
{
    /// <summary>
    /// Круг
    /// </summary>
    public class Circle : Shape
    {

        #region Fields

        /// <summary>
        /// Радиус
        /// </summary>
        public double Radius { get; }

        #endregion


        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="radius">Радиус</param>
        public Circle(double radius) => Radius = radius;

        #endregion

    }
}
