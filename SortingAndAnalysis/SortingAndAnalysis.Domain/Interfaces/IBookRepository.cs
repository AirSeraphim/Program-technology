using System.Collections.Generic;
using SortingAndAnalysis.Domain.Models;

namespace SortingAndAnalysis.Domain.Interfaces;

public interface IBookRepository
{
    IEnumerable<Book> GetAll();
    Book GetById(Guid id);
    void Add(Book book);
    void Update(Book book);
    void Delete(Guid id);
}