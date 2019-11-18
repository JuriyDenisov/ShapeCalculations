using System;
using System.Runtime.Serialization;
using ShapeCalculations.Models;

namespace ShapeCalculations.Exceptions
{
    /// <summary>
    /// Исключение выбрасываемое в случае обнаружения, что входная модель фигуры не корректна
    /// </summary>
    [Serializable]
    public class ShapeModelWrongException : Exception
    {

        #region Fields

        /// <summary>
        /// Модель фигуры
        /// </summary>
        public Shape Shape { get; set; }

        #endregion


        #region Constructors

        /// <summary>
        /// Конструктор
        /// </summary>
        public ShapeModelWrongException()
        {
        }

        /// <summary>
        /// Конструктор с сообщением
        /// </summary>
        /// <param name="message">Сообщение описывающее причину ошибки</param>
        public ShapeModelWrongException(string message) : base(message)
        {
        }

        /// <summary>
        /// Конструктор с сообщением и объектом модели фигуры
        /// </summary>
        /// <param name="message">Сообщение описывающее причину ошибки</param>
        /// <param name="shape">Модель фигуры</param>
        public ShapeModelWrongException(string message, Shape shape) : base(message)
        {
            Shape = shape;
        }

        /// <summary>
        /// Конструктор с сообщением и внутренним исключением
        /// </summary>
        /// <param name="message">Сообщение описывающее причину ошибки</param>
        /// <param name="innerException">Внутреннее исключение</param>
        public ShapeModelWrongException(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Конструктор с данными для сериализации
        /// </summary>
        protected ShapeModelWrongException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        #endregion

    }
}
