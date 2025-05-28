using System;

namespace SortingAndAnalysis.Domain.Models;

public class Book
{
    public Guid Id { get; private set; }
    public string Title { get; private set; }
    public string Author { get; private set; }
    public DateTime PublishedDate { get; private set; }

    // Инварианты
    protected Book() { } // Для EF Core

    public Book(string title, string author, DateTime publishedDate)
    {
        if (string.IsNullOrWhiteSpace(title))
            throw new ArgumentException("Название книги не может быть пустым", nameof(title));

        Id = Guid.NewGuid();
        Title = title;
        Author = author;
        PublishedDate = publishedDate;
    }

    public void UpdateTitle(string newTitle)
    {
        if (string.IsNullOrWhiteSpace(newTitle))
            throw new ArgumentException("Новое название не может быть пустым");

        Title = newTitle;
    }
}