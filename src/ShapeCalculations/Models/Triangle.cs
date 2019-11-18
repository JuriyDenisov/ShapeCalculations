using ShapeCalculations.Models.Enums;

namespace ShapeCalculations.Models
{
    /// <summary>
    /// Треугольник
    /// </summary>
    public class Triangle : Shape
    {

        #region Fields

        /// <summary>
        /// Стороны треугольника
        /// </summary>
        public double[] Sides { get; }

        /// <summary>
        /// Классификация треугольника по величине углов
        /// </summary>
        public TriangleTypeByAngles? TypeByAngles { get; set; }

        /// <summary>
        /// Классификация треугольника по соотношению длин сторон
        /// </summary>
        public TriangleTypeBySideLengths? TypeBySideLengths { get; set; }

        #endregion


        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sideA">Сторона a</param>
        /// <param name="sideB">Сторона b</param>
        /// <param name="sideC">Сторона c</param>
        public Triangle(double sideA, double sideB, double sideC) => Sides = new[] { sideA, sideB, sideC };

        /// <summary>
        /// Конструктор
        /// </summary>
        /// <param name="sides">Стороны треугольника</param>
        public Triangle(double[] sides) => Sides = sides;

        #endregion

    }
}
