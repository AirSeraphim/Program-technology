using SortingAndAnalysis.Application.DTOs;
using System.Collections.Generic;

namespace SortingAndAnalysis.Application.Interfaces;

/// <summary>
/// Интерфейс сервиса для работы с книгами.
/// Предоставляет методы для сортировки и получения информации о книгах.
/// </summary>
public interface IApplicationBookService
{
    /// <summary>
    /// Сортировка книг по названию.
    /// </summary>
    /// <returns>Список отсортированных книг</returns>
    List<BookDto> SortBooksByTitle();

    /// <summary>
    /// Сортировка книг по дате публикации.
    /// </summary>
    /// <returns>Список отсортированных книг</returns>
    List<BookDto> SortBooksByDate();

    /// <summary>
    /// Получить книгу по её идентификатору.
    /// </summary>
    /// <param name="id">Идентификатор книги</param>
    /// <returns>Книга в формате DTO</returns>
    BookDto GetBookById(Guid id);
}