using Xunit;
using SortingAndAnalysis.Application.Services;
using SortingAndAnalysis.Application.Interfaces;
using SortingAndAnalysis.Domain.Models;
using System.Linq;

public class SortServiceTests
{
    private readonly ISortService _sortService = new SortService();

    [Fact]
    public void SortByTitle_ShouldReturnSortedBooks()
    {
        var books = new List<Book>
        {
            new Book { Title = "B Title" },
            new Book { Title = "A Title" },
            new Book { Title = "C Title" }
        };

        var result = _sortService.SortByTitle(books);
        Assert.Equal("A Title", result.First().Title);
    }
}