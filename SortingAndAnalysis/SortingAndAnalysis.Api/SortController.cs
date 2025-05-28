using Microsoft.AspNetCore.Mvc;
using SortingAndAnalysis.Application.Interfaces;
using SortingAndAnalysis.Domain.Models;

namespace SortingAndAnalysis.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class SortController : ControllerBase
{
    private readonly ISortService _sortService;

    public SortController(ISortService sortService)
    {
        _sortService = sortService;
    }

    [HttpPost("by-title")]
    public IActionResult SortByTitle([FromBody] List<Book> books)
    {
        var sortedBooks = _sortService.SortByTitle(books);
        return Ok(sortedBooks);
    }

    [HttpPost("by-date")]
    public IActionResult SortByDate([FromBody] List<Book> books)
    {
        var sortedBooks = _sortService.SortByDate(books);
        return Ok(sortedBooks);
    }
}