using DataBaseLayout.Models;
namespace Perfume.Repositories.Interfaces;

public interface IPerfumeCategoryRepository
{
    Task<List<PerfumeCategory>> GetPerfumeCategoriesAsync();
    Task<PerfumeCategory> GetPerfumeCategoryAsync(string name);
    Task CreatePerfumeCategoryAsync(PerfumeCategory model);
    Task DeletePerfumeCategoryAsync(string name);
}