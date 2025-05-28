using SortingAndAnalysis.Domain.Models;
using SortingAndAnalysis.Application.DTOs;

namespace SortingAndAnalysis.Application.Mappers;

public static class BookMapper
{
    public static BookDto ToDto(Book book)
    {
        return new BookDto
        {
            Id = book.Id,
            Title = book.Title,
            Author = book.Author,
            PublishedDate = book.PublishedDate
        };
    }

    public static List<BookDto> ToDtos(List<Book> books)
    {
        return books.Select(ToDto).ToList();
    }
}