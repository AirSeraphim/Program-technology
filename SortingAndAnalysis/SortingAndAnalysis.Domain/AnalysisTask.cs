namespace SortingAndAnalysis.Domain.Models;

public class AnalysisTask
{
    public Guid Id { get; set; }
    public string Description { get; set; }
    public string Status { get; set; } = "Pending";
}