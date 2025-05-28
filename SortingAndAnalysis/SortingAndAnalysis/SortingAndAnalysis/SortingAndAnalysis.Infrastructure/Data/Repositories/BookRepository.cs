// SortingAndAnalysis.Infrastructure/Repositories/BookRepository.cs

using SortingAndAnalysis.Domain.Models;
using SortingAndAnalysis.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace SortingAndAnalysis.Infrastructure.Repositories;

/// <summary>
/// Реализация репозитория для работы с книгами.
/// Используется Entity Framework Core.
/// </summary>
public class BookRepository : IBookRepository
{
    private readonly AppDbContext _context;

    public BookRepository(AppDbContext context) => 
        _context = context;

    public IEnumerable<Book> GetAll() => 
        _context.Books.ToList();

    public Book GetById(Guid id) => 
        _context.Books.Find(id);

    public void Add(Book book) => 
        _context.Books.Add(book);

    public void Update(Book book) => 
        _context.Books.Update(book);

    public void Delete(Guid id)
    {
        var existing = _context.Books.Find(id);
        if (existing != null)
            _context.Books.Remove(existing);
    }
}