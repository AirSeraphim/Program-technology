// BookMapper.cs

using SortingAndAnalysis.Domain.Models;
using SortingAndAnalysis.Application.DTOs;

namespace SortingAndAnalysis.Application.Mappers;

/// <summary>
/// Маппер для преобразования данных между доменной моделью Book и DTO.
/// </summary>
public static class BookMapper
{
    /// <summary>
    /// Преобразует доменную сущность Book в BookDto.
    /// </summary>
    /// <param name="book">Сущность книги</param>
    /// <returns>DTO книги</returns>
    public static BookDto ToDto(Book book)
    {
        if (book == null) return null;

        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            PublishedDate = book.PublishedDate
        };
    }

    /// <summary>
    /// Преобразует список книг в список DTO.
    /// </summary>
    /// <param name="books">Список сущностей книг</param>
    /// <returns>Список DTO книг</returns>
    public static List<BookDto> ToDtos(List<Book> books) =>
        books?.Select(ToDto).ToList();

    /// <summary>
    /// Преобразует DTO книги в доменную сущность.
    /// </summary>
    /// <param name="dto">DTO книги</param>
    /// <returns>Сущность книги</returns>
    public static Book ToDomain(BookDto dto)
    {
        if (dto == null) return null;

        return new Book(dto.Title, dto.Author, dto.PublishedDate);
    }

    /// <summary>
    /// Обновляет существующую сущность из DTO.
    /// </summary>
    /// <param name="dto">DTO книги</param>
    /// <param name="existingBook">Существующая сущность</param>
    public static void UpdateDomainFromDto(BookDto dto, Book existingBook)
    {
        if (dto == null || existingBook == null)
            return;

        // В данном случае обновление может быть ограничено только доступными полями
        var updatedBook = ToDomain(dto);
        // Пример простого копирования свойств
        existingBook.GetType().GetProperty("Title")?.SetValue(existingBook, updatedBook.Title);
        existingBook.GetType().GetProperty("Author")?.SetValue(existingBook, updatedBook.Author);
        existingBook.GetType().GetProperty("PublishedDate")?.SetValue(existingBook, updatedBook.PublishedDate);
    }
}