namespace SortingAndAnalysis.Application.Interfaces;

/// <summary>
/// Производитель задач для анализа изображений.
/// Отправляет задачи в очередь RabbitMQ.
/// </summary>
public interface IImageTaskProducer
{
    /// <summary>
    /// Отправить задачу на анализ изображения.
    /// </summary>
    /// <param name="imagePath">Путь к изображению</param>
    void SendImageAnalysisTask(string imagePath);
}