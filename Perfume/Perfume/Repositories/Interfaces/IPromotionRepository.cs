using DataBaseLayout.Models;

namespace Perfume.Repositories.Interfaces;

public interface IPromotionRepository
{
    Task<List<Promotion>> GetPromotionsAsync();
    Task<Promotion> GetPromotionAsync(Guid id);
    Task CreatePromotionAsync(Promotion model);
    Task DeletePromotionAsync(Guid id);
}