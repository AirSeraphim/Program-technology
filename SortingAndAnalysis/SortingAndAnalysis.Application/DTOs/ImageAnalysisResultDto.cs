// ImageAnalysisResultDto.cs

using System;

namespace SortingAndAnalysis.Application.DTOs;

/// <summary>
/// DTO для передачи результатов анализа изображения.
/// </summary>
public class ImageAnalysisResultDto
{
    /// <summary>
    /// Идентификатор задачи анализа
    /// </summary>
    public Guid TaskId { get; set; }

    /// <summary>
    /// Результат анализа
    /// </summary>
    public string Result { get; set; }

    /// <summary>
    /// Время завершения анализа
    /// </summary>
    public DateTime CompletedAt { get; set; }
}