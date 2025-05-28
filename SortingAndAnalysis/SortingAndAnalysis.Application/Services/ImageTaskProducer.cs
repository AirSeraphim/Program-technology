using RabbitMQ.Client;
using System.Text;
using SortingAndAnalysis.Application.Interfaces;

namespace SortingAndAnalysis.Application.Services;

public class ImageTaskProducer : IImageTaskProducer
{
    private readonly IModel _channel;

    public ImageTaskProducer()
    {
        var factory = new ConnectionFactory() { HostName = "localhost" };
        var connection = factory.CreateConnection();
        _channel = connection.CreateModel();

        _channel.QueueDeclare(queue: "image_analysis_queue",
                             durable: false,
                             exclusive: false,
                             autoDelete: false,
                             arguments: null);
    }

    public void SendImageAnalysisTask(string imagePath)
    {
        var body = Encoding.UTF8.GetBytes(imagePath);

        _channel.BasicPublish(exchange: "",
                             routingKey: "image_analysis_queue",
                             basicProperties: null,
                             body: body);
    }
}