using SortingAndAnalysis.Domain.Models;
using SortingAndAnalysis.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SortingAndAnalysis.Infrastructure.Repositories;

/// <summary>
/// Реализация репозитория задач анализа.
/// Используется для сохранения и получения задач из БД.
/// </summary>
public class AnalysisTaskRepository : IAnalysisTaskRepository
{
    private readonly AppDbContext _context;

    public AnalysisTaskRepository(AppDbContext context) => 
        _context = context;

    public IEnumerable<AnalysisTask> GetAll() => 
        _context.AnalysisTasks.ToList();

    public AnalysisTask GetById(Guid id) => 
        _context.AnalysisTasks.Find(id);

    public void Add(AnalysisTask task) => 
        _context.AnalysisTasks.Add(task);

    public void Update(AnalysisTask task) => 
        _context.AnalysisTasks.Update(task);
}