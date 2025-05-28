using Microsoft.AspNetCore.Mvc;
using SortingAndAnalysis.Domain.Models;
using SortingAndAnalysis.Domain.Interfaces;

namespace SortingAndAnalysis.Api.Controllers;

/// <summary>
/// Контроллер для управления книгами.
/// Реализует стандартные операции CRUD.
/// </summary>
[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookRepository _bookRepository;

    /// <summary>
    /// Конструктор с внедрением зависимости к репозиторию.
    /// </summary>
    /// <param name="bookRepository">Репозиторий для работы с книгами</param>
    public BookController(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    /// <summary>
    /// Получить список всех книг.
    /// </summary>
    /// <returns>Список книг</returns>
    [HttpGet]
    public IActionResult GetAllBooks()
    {
        var books = _bookRepository.GetAll();
        return Ok(books);
    }

    /// <summary>
    /// Получить книгу по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор книги</param>
    /// <returns>Книга или 404, если не найдена</returns>
    [HttpGet("{id:guid}")]
    public IActionResult GetBookById(Guid id)
    {
        var book = _bookRepository.GetById(id);
        if (book == null)
            return NotFound(new { Message = "Книга не найдена" });

        return Ok(book);
    }

    /// <summary>
    /// Добавить новую книгу.
    /// </summary>
    /// <param name="book">Данные новой книги</param>
    /// <returns>201 Created при успешном добавлении</returns>
    [HttpPost]
    public IActionResult CreateBook([FromBody] Book book)
    {
        if (book == null)
            return BadRequest(new { Message = "Данные книги не могут быть пустыми" });

        _bookRepository.Add(book);
        return CreatedAtAction(nameof(GetBookById), new { id = book.Id }, book);
    }

    /// <summary>
    /// Обновить информацию о книге.
    /// </summary>
    /// <param name="book">Обновлённая информация о книге</param>
    /// <returns>204 No Content при успехе</returns>
    [HttpPut]
    public IActionResult UpdateBook([FromBody] Book book)
    {
        if (book == null)
            return BadRequest(new { Message = "Данные книги не могут быть пустыми" });

        var existingBook = _bookRepository.GetById(book.Id);
        if (existingBook == null)
            return NotFound(new { Message = "Книга не найдена" });

        _bookRepository.Update(book);
        return NoContent();
    }

    /// <summary>
    /// Удалить книгу по идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор книги</param>
    /// <returns>204 No Content при успехе</returns>
    [HttpDelete("{id:guid}")]
    public IActionResult DeleteBook(Guid id)
    {
        var book = _bookRepository.GetById(id);
        if (book == null)
            return NotFound(new { Message = "Книга не найдена" });

        _bookRepository.Delete(id);
        return NoContent();
    }
}