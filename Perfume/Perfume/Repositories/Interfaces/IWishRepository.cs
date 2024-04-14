using DataBaseLayout.Models;

namespace Perfume.Repositories.Interfaces;

public interface IWishRepository
{
    Task<List<Wish>> GetWishListAsync();
    Task CreateWishAsync(Wish model);
    Task DeleteWishAsync(Guid id);
}