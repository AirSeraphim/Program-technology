using System;

namespace SortingAndAnalysis.Domain.Models;

public class AnalysisTask
{
    public Guid Id { get; private set; }
    public string Description { get; private set; }
    public string Status { get; private set; } = "Pending";
    public DateTime CreatedAt { get; private set; }

    protected AnalysisTask() { }

    public AnalysisTask(string description)
    {
        Id = Guid.NewGuid();
        Description = description;
        CreatedAt = DateTime.UtcNow;
    }

    public void MarkAsCompleted()
    {
        Status = "Completed";
    }
}