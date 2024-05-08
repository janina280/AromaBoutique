using Perfume.Models;

namespace Perfume.Services.Interfaces
{
    public interface IPromotionService
    {
        Task<List<PromotionModel>> GetPromotionsAsync();
        Task AddPromotionAsync(AddPromotionModel model);
    }
}
