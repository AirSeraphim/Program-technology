namespace SortingAndAnalysis.Application.Interfaces;

public interface IImageTaskProducer
{
    void SendImageAnalysisTask(string imagePath);
}