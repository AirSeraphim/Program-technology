using Microsoft.EntityFrameworkCore;
using SortingAndAnalysis.Domain.Models;

namespace SortingAndAnalysis.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<AnalysisTask> AnalysisTasks { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>().HasKey(b => b.Id);
        modelBuilder.Entity<AnalysisTask>().HasKey(a => a.Id);

        base.OnModelCreating(modelBuilder);
    }
}