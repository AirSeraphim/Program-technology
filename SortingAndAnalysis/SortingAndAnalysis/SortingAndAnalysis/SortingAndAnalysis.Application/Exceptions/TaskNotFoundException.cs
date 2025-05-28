// TaskNotFoundException.cs

using System;

namespace SortingAndAnalysis.Application.Exceptions;

/// <summary>
/// Исключение, выбрасываемое при попытке получить несуществующую задачу.
/// </summary>
public class TaskNotFoundException : Exception
{
    /// <summary>
    /// Инициализирует новый экземпляр <see cref="TaskNotFoundException"/>.
    /// </summary>
    public TaskNotFoundException()
        : base("Задача не найдена.")
    {
    }

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="TaskNotFoundException"/> с указанием ID задачи.
    /// </summary>
    /// <param name="taskId">ID задачи</param>
    public TaskNotFoundException(Guid taskId)
        : base($"Задача с ID {taskId} не найдена.")
    {
    }

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="TaskNotFoundException"/> с указанием сообщения.
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    public TaskNotFoundException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Инициализирует новый экземпляр <see cref="TaskNotFoundException"/> с сообщением и внутренним исключением.
    /// </summary>
    /// <param name="message">Сообщение об ошибке</param>
    /// <param name="innerException">Внутреннее исключение</param>
    public TaskNotFoundException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}