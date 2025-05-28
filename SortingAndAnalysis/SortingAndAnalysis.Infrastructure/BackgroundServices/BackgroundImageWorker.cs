using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using SortingAndAnalysis.Domain.Services;

namespace SortingAndAnalysis.Infrastructure.BackgroundServices;

public class BackgroundImageWorker : BackgroundService
{
    private readonly IImageAnalysisService _analysisService;

    public BackgroundImageWorker(IImageAnalysisService analysisService)
    {
        _analysisService = analysisService;
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

            try
            {
                var result = _analysisService.Analyze(message);
                Console.WriteLine(result);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при обработке: {ex.Message}");
            }
        };

        channel.BasicConsume(queue: "image_analysis_queue",
                             autoAck: true,
                             consumer: consumer);

        await Task.CompletedTask;
    }
}