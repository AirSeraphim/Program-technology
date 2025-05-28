using Xunit;
using SortingAndAnalysis.Application.Interfaces;
using SortingAndAnalysis.Application.Services;
using SortingAndAnalysis.Domain.Models;
using FluentAssertions;

public class SortServiceTests
{
    private readonly IApplicationBookService _bookService;

    public SortServiceTests()
    {
        var bookRepository = new FakeBookRepository();
        var domainBookService = new DomainBookService(bookRepository);
        _bookService = new ApplicationBookService(domainBookService);
    }

    [Fact]
    public void Should_Sort_Books_By_Title()
    {
        // Arrange
        var books = new List<Book>
        {
            new Book("Zoo", "A", DateTime.Now),
            new Book("Alpha", "B", DateTime.Now),
            new Book("Beta", "C", DateTime.Now)
        };

        // Act
        var sorted = _bookService.SortBooksByTitle();

        // Assert
        sorted.First().Title.Should().Be("Alpha");
    }
}

// Простой фейковый репозиторий для тестирования
internal class FakeBookRepository : IBookRepository
{
    private readonly List<Book> _books = new()
    {
        new Book("Zoo", "A", DateTime.Now),
        new Book("Alpha", "B", DateTime.Now),
        new Book("Beta", "C", DateTime.Now)
    };

    public IEnumerable<Book> GetAll() => _books;
    public Book GetById(Guid id) => _books.FirstOrDefault(x => x.Id == id);
    public void Add(Book book) => _books.Add(book);
    public void Update(Book book) {}
    public void Delete(Guid id) => _books.RemoveAll(x => x.Id == id);
}