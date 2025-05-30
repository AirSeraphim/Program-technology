using RabbitMQ.Client;
using System.Text;
using SortingAndAnalysis.Application.Interfaces;

namespace SortingAndAnalysis.Infrastructure.Services;

/// <summary>
/// Производитель задач для анализа изображений.
/// Отправляет задачи в очередь RabbitMQ.
/// </summary>
public class ImageTaskProducer : IImageTaskProducer
{
    private readonly IModel _channel;

    public ImageTaskProducer()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        var connection = factory.CreateConnection();
        _channel = connection.CreateModel();

        _channel.QueueDeclare(
            queue: "image_analysis_queue",
            durable: false,
            exclusive: false,
            autoDelete: false,
            arguments: null);
    }

    /// <summary>
    /// Отправить задачу на анализ изображения.
    /// </summary>
    /// <param name="imagePath">Путь к файлу</param>
    public void SendImageAnalysisTask(string imagePath)
    {
        if (string.IsNullOrWhiteSpace(imagePath))
            throw new ArgumentException("Путь не может быть пустым");

        var body = Encoding.UTF8.GetBytes(imagePath);
        _channel.BasicPublish(
            exchange: "",
            routingKey: "image_analysis_queue",
            basicProperties: null,
            body: body);
    }
}