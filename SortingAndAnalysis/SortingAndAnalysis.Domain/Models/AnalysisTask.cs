// AnalysisTask.cs

using System;

namespace SortingAndAnalysis.Domain.Models;

/// <summary>
/// Задача анализа изображения или текста.
/// </summary>
public class AnalysisTask
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public string Status { get; private set; } = "Pending"; // Pending / Completed / Failed
    public DateTime CreatedAt { get; private set; }

    protected AnalysisTask() { }

    public AnalysisTask(string description)
    {
        Id = Guid.NewGuid();
        Description = description;
        CreatedAt = DateTime.UtcNow;
    }

    /// <summary>
    /// Пометить задачу как завершённую
    /// </summary>
    public void MarkAsCompleted()
    {
        Status = "Completed";
    }

    /// <summary>
    /// Пометить задачу как проваленную
    /// </summary>
    public void MarkAsFailed()
    {
        Status = "Failed";
    }
}