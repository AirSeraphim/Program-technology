using Microsoft.AspNetCore.Mvc;
using SortingAndAnalysis.Application.Interfaces;

namespace SortingAndAnalysis.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ImageController : ControllerBase
{
    private readonly IApplicationImageService _imageService;

    public ImageController(IApplicationImageService imageService)
    {
        _imageService = imageService;
    }

    [HttpPost("analyze")]
    public IActionResult Analyze([FromBody] string imagePath)
    {
        try
        {
            var result = _imageService.AnalyzeImage(imagePath);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}