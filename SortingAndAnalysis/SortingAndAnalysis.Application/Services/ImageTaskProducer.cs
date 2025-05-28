using RabbitMQ.Client;
using System.Text;
using SortingAndAnalysis.Application.Interfaces;

namespace SortingAndAnalysis.Application.Services;

/// <summary>
/// Реализация производителя задач для анализа изображений.
/// Отправляет задачи в очередь RabbitMQ.
/// </summary>
public class ImageTaskProducer : IImageTaskProducer
{
    private readonly IModel _channel;

    /// <summary>
    /// Инициализирует соединение с RabbitMQ и создает очередь, если её нет.
    /// </summary>
    public ImageTaskProducer()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        var connection = factory.CreateConnection();
        _channel = connection.CreateModel();

        // Объявляем очередь, если она ещё не существует
        _channel.QueueDeclare(
            queue: "image_analysis_queue",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }

    /// <summary>
    /// Отправляет задачу на анализ изображения в очередь RabbitMQ.
    /// </summary>
    /// <param name="imagePath">Путь к изображению</param>
    public void SendImageAnalysisTask(string imagePath)
    {
        if (string.IsNullOrWhiteSpace(imagePath))
            throw new ArgumentException("Путь к изображению не может быть пустым", nameof(imagePath));

        var body = Encoding.UTF8.GetBytes(imagePath);

        // Публикуем сообщение в очередь
        _channel.BasicPublish(
            exchange: "",
            routingKey: "image_analysis_queue",
            basicProperties: null,
            body: body);
    }
}