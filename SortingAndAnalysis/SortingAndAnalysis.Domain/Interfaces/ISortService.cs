using SortingAndAnalysis.Domain.Models;
using System.Collections.Generic;

namespace SortingAndAnalysis.Application.Interfaces;

/// <summary>
/// Сервис для выполнения различных видов сортировки книг.
/// Используется в бизнес-логике приложения.
/// </summary>
public interface ISortService
{
    /// <summary>
    /// Сортировка списка книг по названию.
    /// </summary>
    /// <param name="books">Список книг</param>
    /// <returns>Отсортированный список</returns>
    List<Book> SortByTitle(List<Book> books);

    /// <summary>
    /// Сортировка списка книг по дате публикации.
    /// </summary>
    /// <param name="books">Список книг</param>
    /// <returns>Отсортированный список</returns>
    List<Book> SortByDate(List<Book> books);
}