using SortingAndAnalysis.Domain.Models;

namespace SortingAndAnalysis.Domain.Interfaces;

/// <summary>
/// Репозиторий для работы с логами наномашины
/// </summary>
public interface INanoMachineLogRepository
{
    void Add(NanoMachineLog log);
}