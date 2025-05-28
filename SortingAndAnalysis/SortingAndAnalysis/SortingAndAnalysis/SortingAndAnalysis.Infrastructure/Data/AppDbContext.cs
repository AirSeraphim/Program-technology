// SortingAndAnalysis.Infrastructure/Data/AppDbContext.cs

using Microsoft.EntityFrameworkCore;
using SortingAndAnalysis.Domain.Models;

namespace SortingAndAnalysis.Infrastructure.Data;

/// <summary>
/// Контекст Entity Framework Core для работы с базой данных.
/// </summary>
public class AppDbContext : DbContext
{
    /// <summary>
    /// Таблица книг
    /// </summary>
    public DbSet<Book> Books { get; set; }

    /// <summary>
    /// Таблица задач анализа
    /// </summary>
    public DbSet<AnalysisTask> AnalysisTasks { get; set; }

    /// <summary>
    /// Конструктор с настройкой контекста
    /// </summary>
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    /// <summary>
    /// Настройка моделей через Fluent API
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Пример: настройка первичного ключа
        modelBuilder.Entity<Book>().HasKey(b => b.Id);
        modelBuilder.Entity<AnalysisTask>().HasKey(a => a.Id);
    }
}