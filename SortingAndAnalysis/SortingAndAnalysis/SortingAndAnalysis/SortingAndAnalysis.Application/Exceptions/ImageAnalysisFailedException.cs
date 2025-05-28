// ImageAnalysisFailedException.cs

using System;

namespace SortingAndAnalysis.Application.Exceptions;

/// <summary>
/// Исключение, выбрасываемое при ошибке анализа изображения.
/// </summary>
public class ImageAnalysisFailedException : Exception
{
    /// <summary>
    /// Инициализирует новый экземпляр <see cref="ImageAnalysisFailedException"/>.
    /// </summary>
    public ImageAnalysisFailedException()
        : base("Ошибка при анализе изображения.")
    {
    }

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="ImageAnalysisFailedException"/> с указанием сообщения.
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    public ImageAnalysisFailedException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="ImageAnalysisFailedException"/> с сообщением и внутренним исключением.
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    /// <param name="innerException">Внутреннее исключение</param>
    public ImageAnalysisFailedException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}