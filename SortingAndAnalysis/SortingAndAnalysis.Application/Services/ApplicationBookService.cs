using SortingAndAnalysis.Domain.Services;
using SortingAndAnalysis.Application.DTOs;
using SortingAndAnalysis.Application.Mappers;

namespace SortingAndAnalysis.Application.Services;

public class ApplicationBookService : IApplicationBookService
{
    private readonly DomainBookService _domainBookService;

    public ApplicationBookService(DomainBookService domainBookService)
    {
        _domainBookService = domainBookService;
    }

    public List<BookDto> SortBooksByTitle()
    {
        return BookMapper.ToDtos(_domainBookService.SortByTitle());
    }

    public List<BookDto> SortBooksByDate()
    {
        return BookMapper.ToDtos(_domainBookService.SortByDate());
    }

    public BookDto GetBookById(Guid id)
    {
        return BookMapper.ToDto(_domainBookService.GetBookById(id));
    }
}