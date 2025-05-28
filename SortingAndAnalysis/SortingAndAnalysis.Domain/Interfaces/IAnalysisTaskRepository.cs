using System.Collections.Generic;
using SortingAndAnalysis.Domain.Models;

namespace SortingAndAnalysis.Domain.Interfaces;

public interface IAnalysisTaskRepository
{
    IEnumerable<AnalysisTask> GetAll();
    AnalysisTask GetById(Guid id);
    void Add(AnalysisTask task);
    void Update(AnalysisTask task);
}