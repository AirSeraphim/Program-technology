using SortingAndAnalysis.Domain.Models;

namespace SortingAndAnalysis.Application.Interfaces;

public interface ISortService
{
    List<Book> SortByTitle(List<Book> books);
    List<Book> SortByDate(List<Book> books);
}