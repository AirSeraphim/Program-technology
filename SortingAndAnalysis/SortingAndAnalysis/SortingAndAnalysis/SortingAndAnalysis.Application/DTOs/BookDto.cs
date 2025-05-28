namespace SortingAndAnalysis.Application.DTOs;

/// <summary>
/// DTO для передачи данных о книге.
/// </summary>
public class BookDto
{
    /// <summary>
    /// Уникальный идентификатор книги
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название книги
    /// </summary>
    public string Title { get; set; }

    /// <summary>
    /// Автор книги
    /// </summary>
    public string Author { get; set; }

    /// <summary>
    /// Дата публикации
    /// </summary>
    public DateTime PublishedDate { get; set; }
}