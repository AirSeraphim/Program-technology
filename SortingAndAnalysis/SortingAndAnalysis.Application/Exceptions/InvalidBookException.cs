// InvalidBookException.cs

using System;

namespace SortingAndAnalysis.Application.Exceptions;

/// <summary>
/// Исключение, выбрасываемое при некорректных данных книги.
/// </summary>
public class InvalidBookException : Exception
{
    /// <summary>
    /// Инициализирует новый экземпляр <see cref="InvalidBookException"/>.
    /// </summary>
    public InvalidBookException() : base("Книга содержит недопустимые данные.")
    {
    }

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="InvalidBookException"/> с указанием сообщения об ошибке.
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    public InvalidBookException(string message) : base(message)
    {
    }

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="InvalidBookException"/> с указанием сообщения и внутреннего исключения.
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    /// <param name="innerException">Внутреннее исключение</param>
    public InvalidBookException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}