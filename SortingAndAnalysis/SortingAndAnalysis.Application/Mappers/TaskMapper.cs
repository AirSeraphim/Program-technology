// TaskMapper.cs

using SortingAndAnalysis.Domain.Models;
using SortingAndAnalysis.Application.DTOs;

namespace SortingAndAnalysis.Application.Mappers;

/// <summary>
/// Маппер для преобразования данных между доменной моделью AnalysisTask и DTO.
/// </summary>
public static class TaskMapper
{
    /// <summary>
    /// Преобразует доменную сущность AnalysisTask в TaskDto.
    /// </summary>
    /// <param name="task">Задача анализа</param>
    /// <returns>DTO задачи</returns>
    public static TaskDto ToDto(AnalysisTask task)
    {
        if (task == null) return null;

        return new TaskDto
        {
            Id = task.Id,
            Description = task.Description,
            Status = task.Status,
            CreatedAt = task.CreatedAt
        };
    }

    /// <summary>
    /// Преобразует список задач в список DTO.
    /// </summary>
    /// <param name="tasks">Список задач</param>
    /// <returns>Список DTO задач</returns>
    public static List<TaskDto> ToDtos(List<AnalysisTask> tasks) =>
        tasks?.Select(ToDto).ToList();
}