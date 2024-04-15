using DataBaseLayout.Models;

namespace Perfume.Repositories.Interfaces;

public interface IRoleRepository
{
    Task<List<Role>> GetRolesAsync();
    Task<Role> GetRoleAsync(string name);
    Task CreateRoleAsync(Role model);
    Task DeleteRoleAsync(string name);
}