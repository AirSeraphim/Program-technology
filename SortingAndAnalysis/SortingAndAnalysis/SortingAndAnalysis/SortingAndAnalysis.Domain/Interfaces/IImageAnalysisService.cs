namespace SortingAndAnalysis.Domain.Interfaces;

/// <summary>
/// Интерфейс для сервиса анализа изображений
/// </summary>
public interface IImageAnalysisService
{
    /// <summary>
    /// Анализирует изображение по указанному пути
    /// </summary>
    /// <param name="imagePath">Путь к изображению</param>
    /// <returns>Результат анализа</returns>
    string Analyze(string imagePath);
}