using Microsoft.AspNetCore.Mvc;
using SortingAndAnalysis.Application.Interfaces;

namespace SortingAndAnalysis.Api.Controllers;

/// <summary>
/// Контроллер для работы с анализом изображений.
/// Принимает запросы и отправляет задачи в очередь через RabbitMQ.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class ImageController : ControllerBase
{
    private readonly IImageTaskProducer _imageTaskProducer;

    /// <summary>
    /// Конструктор с внедрением зависимости к производителю задач.
    /// </summary>
    /// <param name="imageTaskProducer">Сервис для отправки задач в очередь</param>
    public ImageController(IImageTaskProducer imageTaskProducer)
    {
        _imageTaskProducer = imageTaskProducer;
    }

    /// <summary>
    /// Запустить анализ изображения.
    /// </summary>
    /// <param name="imagePath">Путь к изображению</param>
    /// <returns>202 Accepted, если задача успешно добавлена в очередь</returns>
    [HttpPost("analyze")]
    public IActionResult AnalyzeImage([FromBody] string imagePath)
    {
        if (string.IsNullOrWhiteSpace(imagePath))
            return BadRequest(new { Message = "Путь к изображению не может быть пустым" });

        // Отправляем задачу в очередь
        _imageTaskProducer.SendImageAnalysisTask(imagePath);

        return Accepted(new
        {
            Message = "Задача на анализ изображения добавлена в очередь",
            ImagePath = imagePath
        });
    }
}