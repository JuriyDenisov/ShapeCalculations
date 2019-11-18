using ShapeCalculations.Models;
using ShapeCalculations.Services.Interfaces;

namespace ShapeCalculations.Services
{
    /// <summary>
    /// Сервис выполняющий различные вычисления для геометрических фигур
    /// </summary>
    public class ShapeCalculationService : IShapeCalculationService
    {
        
        #region Fields

        /// <summary>
        /// Фабрика, которая возвращает объект умеющий выполнять различные вычисления для указанной фигуры
        /// </summary>
        private readonly ICalculatorsFactory _calculatorsFactory;

        #endregion


        #region Constructors

        /// <summary>
        /// Создание класса с фабрикой вычислителей по умолчанию
        /// </summary>
        public ShapeCalculationService() => _calculatorsFactory = new CalculatorsFactory();

        /// <summary>
        /// Создание класса с инициализацией его, указанной фабрикой вычислителей
        /// </summary>
        /// <param name="calculatorsFactory">Фабрика вычислителей, которую нужно использовать при работе</param>
        public ShapeCalculationService(ICalculatorsFactory calculatorsFactory) => _calculatorsFactory = calculatorsFactory;

        #endregion


        #region IShapeCalculationService implementation

        /// <summary>
        /// Проверить корректность модели
        /// </summary>
        /// <param name="shape">Модель фигуры</param>
        public void Validate(Shape shape)
        {
            _calculatorsFactory.GetCalculator(shape);
        }

        /// <summary>
        /// Вычислить площадь
        /// </summary>
        /// <param name="shape">Модель фигуры</param>
        public void FindArea(Shape shape)
        {
            var calculator = _calculatorsFactory.GetCalculator(shape);

            calculator.FindArea();
        }

        /// <summary>
        /// Выполнить классификацию фигуры
        /// </summary>
        /// <param name="shape">Модель фигуры</param>
        public void DefineType(Shape shape)
        {
            var calculator = _calculatorsFactory.GetCalculator(shape);

            calculator.DefineType();
        }

        /// <summary>
        /// Выполнить все доступные вычисления с фигурой
        /// </summary>
        /// <param name="shape">Модель фигуры</param>
        public void CalculateAll(Shape shape)
        {
            var calculator = _calculatorsFactory.GetCalculator(shape);

            calculator.FindArea();
            calculator.DefineType();
        }

        #endregion

    }
}
