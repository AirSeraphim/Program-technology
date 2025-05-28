// SortService.cs

using SortingAndAnalysis.Domain.Models;
using SortingAndAnalysis.Domain.Services;
using System.Collections.Generic;
using System.Linq;

namespace SortingAndAnalysis.Application.Services;

/// <summary>
/// Сервис для выполнения различных видов сортировки книг.
/// Используется в бизнес-логике приложения.
/// </summary>
public class SortService : ISortService
{
    /// <summary>
    /// Сортировка списка книг по названию.
    /// </summary>
    /// <param name="books">Список книг</param>
    /// <returns>Отсортированный список</returns>
    public List<Book> SortByTitle(List<Book> books) =>
        books.OrderBy(b => b.Title).ToList();

    /// <summary>
    /// Сортировка списка книг по дате публикации.
    /// </summary>
    /// <param name="books">Список книг</param>
    /// <returns>Отсортированный список</returns>
    public List<Book> SortByDate(List<Book> books) =>
        books.OrderBy(b => b.PublishedDate).ToList();
}