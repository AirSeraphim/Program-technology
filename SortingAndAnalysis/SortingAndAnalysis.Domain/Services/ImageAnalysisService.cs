namespace SortingAndAnalysis.Domain.Services;

public class ImageAnalysisService : IImageAnalysisService
{
    public string Analyze(string imagePath)
    {
        if (!File.Exists(imagePath))
            throw new FileNotFoundException("Файл не найден", imagePath);

        // Имитация анализа
        return $"Анализ файла '{imagePath}' завершён.";
    }
}