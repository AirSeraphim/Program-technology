using SortingAndAnalysis.Domain.Models;
using SortingAndAnalysis.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SortingAndAnalysis.Infrastructure.Repositories;

public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Book> GetAll() => _context.Books.ToList();

    public Book GetById(Guid id) => _context.Books.Find(id);

    public void Add(Book book) => _context.Books.Add(book);

    public void Update(Book book) => _context.Books.Update(book);

    public void Delete(Guid id)
    {
        var book = _context.Books.Find(id);
        if (book != null) _context.Books.Remove(book);
    }
}