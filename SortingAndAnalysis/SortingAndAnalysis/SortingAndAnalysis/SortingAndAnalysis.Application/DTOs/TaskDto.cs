namespace SortingAndAnalysis.Application.DTOs;

/// <summary>
/// DTO для передачи данных о задаче анализа.
/// </summary>
public class TaskDto
{
    /// <summary>
    /// Уникальный идентификатор задачи
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Описание задачи
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Текущий статус задачи
    /// </summary>
    public string Status { get; set; }

    /// <summary>
    /// Дата создания задачи
    /// </summary>
    public DateTime CreatedAt { get; set; }
}