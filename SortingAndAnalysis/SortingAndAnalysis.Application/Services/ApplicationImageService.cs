// ApplicationImageService.cs

using SortingAndAnalysis.Application.Interfaces;
using SortingAndAnalysis.Domain.Services;

namespace SortingAndAnalysis.Application.Services;

/// <summary>
/// Сервис для работы с анализом изображений.
/// Используется в API-слое для вызова бизнес-логики анализа.
/// </summary>
public class ApplicationImageService : IApplicationImageService
{
    private readonly IImageAnalysisService _analysisService;

    /// <summary>
    /// Конструктор с внедрением зависимости к доменному сервису.
    /// </summary>
    /// <param name="analysisService">Сервис для анализа изображений</param>
    public ApplicationImageService(IImageAnalysisService analysisService)
    {
        _analysisService = analysisService;
    }

    /// <summary>
    /// Анализировать изображение по указанному пути.
    /// </summary>
    /// <param name="path">Путь к файлу изображения</param>
    /// <returns>Результат анализа</returns>
    public string AnalyzeImage(string path)
    {
        if (string.IsNullOrWhiteSpace(path))
            throw new ArgumentException("Путь к изображению не может быть пустым", nameof(path));

        return _analysisService.Analyze(path);
    }
}