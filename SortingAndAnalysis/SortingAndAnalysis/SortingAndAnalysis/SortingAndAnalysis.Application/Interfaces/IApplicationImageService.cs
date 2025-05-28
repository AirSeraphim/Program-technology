namespace SortingAndAnalysis.Application.Interfaces;

/// <summary>
/// Интерфейс для работы с анализом изображений.
/// Используется в API-слое для вызова бизнес-логики анализа.
/// </summary>
public interface IApplicationImageService
{
    /// <summary>
    /// Анализировать изображение по указанному пути.
    /// </summary>
    /// <param name="path">Путь к файлу изображения</param>
    /// <returns>Результат анализа</returns>
    string AnalyzeImage(string path);
}