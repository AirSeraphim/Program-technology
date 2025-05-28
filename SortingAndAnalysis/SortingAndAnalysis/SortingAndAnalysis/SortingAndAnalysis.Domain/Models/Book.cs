// Book.cs

using System;

namespace SortingAndAnalysis.Domain.Models;

/// <summary>
/// Сущность "Книга" — представляет книгу в системе.
/// </summary>
public class Book
{
    /// <summary>
    /// Уникальный идентификатор книги
    /// </summary>
    public Guid Id { get; private set; }

    /// <summary>
    /// Название книги
    /// </summary>
    public string Title { get; private set; }

    /// <summary>
    /// Автор книги
    /// </summary>
    public string Author { get; private set; }

    /// <summary>
    /// Дата публикации
    /// </summary>
    public DateTime PublishedDate { get; private set; }

    // Защищённый конструктор для EF Core
    protected Book() { }

    /// <summary>
    /// Создаёт новую книгу с проверкой обязательных полей
    /// </summary>
    public Book(string title, string author, DateTime publishedDate)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Название не может быть пустым", nameof(title));

        Id = Guid.NewGuid();
        Title = title;
        Author = author;
        PublishedDate = publishedDate;
    }

    /// <summary>
    /// Обновить название книги
    /// </summary>
    public void UpdateTitle(string newTitle)
    {
        if (string.IsNullOrWhiteSpace(newTitle))
            throw new ArgumentException("Новое название не может быть пустым", nameof(newTitle));

        Title = newTitle;
    }
}