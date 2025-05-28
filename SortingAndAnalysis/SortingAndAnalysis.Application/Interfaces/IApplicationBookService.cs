using SortingAndAnalysis.Application.DTOs;
using System.Collections.Generic;

namespace SortingAndAnalysis.Application.Interfaces;

public interface IApplicationBookService
{
    List<BookDto> SortBooksByTitle();
    List<BookDto> SortBooksByDate();
    BookDto GetBookById(Guid id);
}