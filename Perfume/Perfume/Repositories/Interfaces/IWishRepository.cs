using DataBaseLayout.Models;

namespace Perfume.Repositories.Interfaces;

public interface IWishRepository
{
    Task<List<Wish>> GetWishListAsync();
    Task<List<Wish>> GetWishListByUserIdAsync(Guid userId);
    Task<Wish> GetWishAsync(Guid id);
    Task CreateWishAsync(Wish model);
    Task DeleteWishAsync(Guid id);
}