using SortingAndAnalysis.Domain.Models;
using SortingAndAnalysis.Application.Interfaces;

namespace SortingAndAnalysis.Application.Services;

public class SortService : ISortService
{
    public List<Book> SortByTitle(List<Book> books)
    {
        return books.OrderBy(b => b.Title).ToList();
    }

    public List<Book> SortByDate(List<Book> books)
    {
        return books.OrderBy(b => b.PublishedDate).ToList();
    }
}