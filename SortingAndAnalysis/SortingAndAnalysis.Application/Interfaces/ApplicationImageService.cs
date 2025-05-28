using SortingAndAnalysis.Domain.Services;

namespace SortingAndAnalysis.Application.Services;

public class ApplicationImageService : IApplicationImageService
{
    private readonly IImageAnalysisService _analysisService;

    public ApplicationImageService(IImageAnalysisService analysisService)
    {
        _analysisService = analysisService;
    }

    public string AnalyzeImage(string path)
    {
        return _analysisService.Analyze(path);
    }
}