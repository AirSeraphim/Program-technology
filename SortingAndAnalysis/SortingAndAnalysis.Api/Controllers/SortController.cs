using Microsoft.AspNetCore.Mvc;
using SortingAndAnalysis.Application.Interfaces;
using SortingAndAnalysis.Application.DTOs;

namespace SortingAndAnalysis.Api.Controllers;

/// <summary>
/// Контроллер для выполнения сортировки книг через API.
/// Предоставляет эндпоинты для сортировки по названию, дате и другим критериям.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class SortController : ControllerBase
{
    private readonly IApplicationBookService _bookService;

    /// <summary>
    /// Конструктор с внедрением зависимости к сервису работы с книгами.
    /// </summary>
    /// <param name="bookService">Сервис для работы с книгами</param>
    public SortController(IApplicationBookService bookService)
    {
        _bookService = bookService;
    }

    /// <summary>
    /// Сортировка книг по названию.
    /// </summary>
    /// <returns>Отсортированный список книг</returns>
    [HttpPost("books/by-title")]
    public IActionResult SortBooksByTitle()
    {
        var result = _bookService.SortBooksByTitle();
        return Ok(result);
    }

    /// <summary>
    /// Сортировка книг по дате публикации.
    /// </summary>
    /// <returns>Отсортированный список книг</returns>
    [HttpPost("books/by-date")]
    public IActionResult SortBooksByDate()
    {
        var result = _bookService.SortBooksByDate();
        return Ok(result);
    }
}