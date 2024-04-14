using DataBaseLayout.Models;
namespace Perfume.Repositories.Interfaces;

public interface IPerfumeCategoryRepository
{
    Task<List<PerfumeCategory>> GetPerfumeCategoriesAsync();
    Task CreatePerfumeCategoryAsync(PerfumeCategory model);
    Task DeletePerfumeCategoryAsync(string name);
}