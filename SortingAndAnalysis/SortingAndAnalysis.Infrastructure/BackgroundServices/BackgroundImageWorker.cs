using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using SortingAndAnalysis.Domain.Services;
using Microsoft.Extensions.DependencyInjection;

namespace SortingAndAnalysis.Infrastructure.BackgroundServices;

/// <summary>
/// Фоновый сервис, слушающий очередь RabbitMQ.
/// Обрабатывает задачи анализа изображений.
/// </summary>
public class BackgroundImageWorker : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public BackgroundImageWorker(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: "image_analysis_queue",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);

        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            Console.WriteLine($"[x] Получено: {message}");

            using (var scope = _serviceProvider.CreateScope())
            {
                var analysisService = scope.ServiceProvider.GetRequiredService<IImageAnalysisService>();
                try
                {
                    var result = analysisService.Analyze(message);
                    Console.WriteLine($"[✓] Результат: {result}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[!] Ошибка: {ex.Message}");
                }
            }
        };

        channel.BasicConsume(queue: "image_analysis_queue", autoAck: true, consumer: consumer);

        await Task.CompletedTask;
    }
}