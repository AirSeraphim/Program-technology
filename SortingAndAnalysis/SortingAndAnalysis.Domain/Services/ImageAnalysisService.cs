using SortingAndAnalysis.Domain.Interfaces;
using SortingAndAnalysis.Domain.Models;

namespace SortingAndAnalysis.Domain.Services;

/// <summary>
/// Доменный сервис для анализа изображений с помощью "наномашины"
/// </summary>
public class ImageAnalysisService : IImageAnalysisService
{
    private readonly INanoMachineLogRepository _logRepository;

    /// <summary>
    /// Конструктор с внедрением зависимостей
    /// </summary>
    public ImageAnalysisService(INanoMachineLogRepository logRepository)
    {
        _logRepository = logRepository;
    }

    /// <summary>
    /// Выполняет анализ изображения по указанному пути
    /// </summary>
    /// <param name="imagePath">Путь к изображению</param>
    /// <returns>Результат анализа</returns>
    public string Analyze(string imagePath)
    {
        // Проверка входных данных
        if (string.IsNullOrWhiteSpace(imagePath))
            throw new ArgumentException("Путь к изображению не может быть пустым", nameof(imagePath));

        if (!File.Exists(imagePath))
            throw new FileNotFoundException("Файл не найден", imagePath);

        // Имитация анализа изображения
        string result = $"Анализ файла '{imagePath}' завершён. Обнаружены стандартные элементы.";

        // Логируем действие наномашины
        var logEntry = new NanoMachineLog($"[ImageAnalysis] Проанализирован файл: {imagePath}");
        _logRepository.Add(logEntry);

        return result;
    }
}