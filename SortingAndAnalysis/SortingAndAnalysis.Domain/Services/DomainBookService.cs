using SortingAndAnalysis.Domain.Models;
using SortingAndAnalysis.Domain.Interfaces;
using System.Linq;

namespace SortingAndAnalysis.Domain.Services;

public class DomainBookService
{
    private readonly IBookRepository _bookRepository;

    public DomainBookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public List<Book> SortByTitle()
    {
        return _bookRepository.GetAll().OrderBy(b => b.Title).ToList();
    }

    public List<Book> SortByDate()
    {
        return _bookRepository.GetAll().OrderBy(b => b.PublishedDate).ToList();
    }

    public Book GetBookById(Guid id)
    {
        return _bookRepository.GetById(id);
    }
}