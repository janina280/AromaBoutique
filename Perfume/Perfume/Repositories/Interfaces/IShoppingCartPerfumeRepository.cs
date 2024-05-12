using DataBaseLayout.Models;

namespace Perfume.Repositories.Interfaces;

public interface IShoppingCartPerfumeRepository
{
     Task<List<ShoppingCartPerfume>> GetShoppingCartPerfumesAsync();
     Task<List<ShoppingCartPerfume>> GetShoppingCartPerfumesByUserIdAsync(Guid userId);
    Task<ShoppingCartPerfume> GetShoppingCartPerfumeAsync(Guid id);
     Task CreateShoppingCartPerfumeAsync(ShoppingCartPerfume model);
     Task DeleteShoppingCartPerfumeAsync(Guid id);
}