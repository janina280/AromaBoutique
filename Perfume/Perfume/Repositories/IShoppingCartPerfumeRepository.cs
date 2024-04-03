using DataBaseLayout;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using Perfume.Models;

namespace Perfume.Repositories;

public interface IShoppingCartPerfumeRepository
{
     Task<List<ShoppingCartPerfume>> GetShoppingCartPerfumesAsync();

     Task CreateShoppingCartPerfumeAsync(ShoppingCartPerfume model);

     Task DeleteShoppingCartPerfumeAsync(Guid id);
}