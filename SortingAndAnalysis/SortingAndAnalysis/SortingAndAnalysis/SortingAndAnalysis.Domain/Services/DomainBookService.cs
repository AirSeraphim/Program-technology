using SortingAndAnalysis.Domain.Models;
using SortingAndAnalysis.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace SortingAndAnalysis.Domain.Services;

/// <summary>
/// Доменный сервис для выполнения операций над книгами.
/// Реализует бизнес-логику, такую как сортировка и проверки.
/// </summary>
public class DomainBookService : ISortService
{
    /// <summary>
    /// Сортировка списка книг по названию.
    /// </summary>
    /// <param name="books">Список книг</param>
    /// <returns>Отсортированный список</returns>
    public List<Book> SortByTitle(List<Book> books)
    {
        if (books == null) return new List<Book>();

        return books.OrderBy(b => b.Title).ToList();
    }

    /// <summary>
    /// Сортировка списка книг по дате публикации.
    /// </summary>
    /// <param name="books">Список книг</param>
    /// <returns>Отсортированный список</returns>
    public List<Book> SortByDate(List<Book> books)
    {
        if (books == null) return new List<Book>();

        return books.OrderBy(b => b.PublishedDate).ToList();
    }

    /// <summary>
    /// Проверяет, есть ли книги с одинаковыми названиями.
    /// </summary>
    /// <param name="books">Список книг</param>
    /// <returns>True, если есть дубликаты</returns>
    public bool HasDuplicateTitles(List<Book> books)
    {
        if (books == null || books.Count < 2) return false;

        return books.GroupBy(b => b.Title).Any(g => g.Count() > 1);
    }
}