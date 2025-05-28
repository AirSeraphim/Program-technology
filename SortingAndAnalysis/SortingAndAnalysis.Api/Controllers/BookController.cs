using Microsoft.AspNetCore.Mvc;
using SortingAndAnalysis.Application.Interfaces;
using SortingAndAnalysis.Application.DTOs;

namespace SortingAndAnalysis.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly IApplicationBookService _bookService;

    public BookController(IApplicationBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpGet("sorted-by-title")]
    public IActionResult GetSortedByTitle()
    {
        var result = _bookService.SortBooksByTitle();
        return Ok(result);
    }

    [HttpGet("sorted-by-date")]
    public IActionResult GetSortedByDate()
    {
        var result = _bookService.SortBooksByDate();
        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetById(Guid id)
    {
        var result = _bookService.GetBookById(id);
        return Ok(result);
    }
}