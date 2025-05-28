// ApplicationBookService.cs

using SortingAndAnalysis.Application.DTOs;
using SortingAndAnalysis.Application.Interfaces;
using SortingAndAnalysis.Domain.Models;
using SortingAndAnalysis.Domain.Services;

namespace SortingAndAnalysis.Application.Services;

/// <summary>
/// Реализация сервиса для работы с книгами.
/// Используется в API-слое для вызова бизнес-логики сортировки.
/// </summary>
public class ApplicationBookService : IApplicationBookService
{
    private readonly ISortService _sortService;

    /// <summary>
    /// Конструктор с внедрением зависимости к сервису сортировки.
    /// </summary>
    /// <param name="sortService">Сервис сортировки книг</param>
    public ApplicationBookService(ISortService sortService)
    {
        _sortService = sortService;
    }

    /// <summary>
    /// Сортировка книг по названию.
    /// </summary>
    /// <returns>Список отсортированных книг</returns>
    public List<BookDto> SortBooksByTitle()
    {
        // Получаем список книг из доменного слоя
        var books = GetSampleBooks(); // можно заменить на вызов репозитория
        var sortedBooks = _sortService.SortByTitle(books);
        return BookMapper.ToDtos(sortedBooks);
    }

    /// <summary>
    /// Сортировка книг по дате публикации.
    /// </summary>
    /// <returns>Список отсортированных книг</returns>
    public List<BookDto> SortBooksByDate()
    {
        var books = GetSampleBooks();
        var sortedBooks = _sortService.SortByDate(books);
        return BookMapper.ToDtos(sortedBooks);
    }

    /// <summary>
    /// Получить книгу по идентификатору (в примере статические данные).
    /// </summary>
    /// <param name="id">Идентификатор книги</param>
    /// <returns>Книга в формате DTO</returns>
    public BookDto GetBookById(Guid id)
    {
        var book = GetSampleBooks().FirstOrDefault(b => b.Id == id);
        return BookMapper.ToDto(book);
    }

    #region Вспомогательные методы

    // Пример получения данных (в реальном проекте будет через репозиторий)
    private List<Book> GetSampleBooks()
    {
        return new List<Book>
        {
            new Book("Clean Code", "Robert C. Martin", new DateTime(2008, 8, 1)),
            new Book("Domain-Driven Design", "Eric Evans", new DateTime(2003, 8, 30)),
            new Book("Patterns of Enterprise Application Architecture", "Martin Fowler", new DateTime(2002, 11, 15))
        };
    }

    #endregion
}