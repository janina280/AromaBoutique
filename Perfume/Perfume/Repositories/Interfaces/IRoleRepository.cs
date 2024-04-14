using DataBaseLayout.Models;

namespace Perfume.Repositories.Interfaces;

public interface IRoleRepository
{
    Task<List<Role>> GetRolesAsync();
    Task CreateRoleAsync(Role model);
    Task DeleteRoleAsync(string name);
}