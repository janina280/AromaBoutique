using DataBaseLayout;
using DataBaseLayout.Models;
using Microsoft.EntityFrameworkCore;
using Perfume.Repositories.Interfaces;

namespace Perfume.Repositories;

public class RoleRepository : IRoleRepository
{
    private readonly IContext _context;

    public RoleRepository(IContext context)
    {
        _context = context;
    }
    public async Task<List<Role>> GetRolesAsync()
    {
        var role = await _context.Roles
            .Include(x=>x.Users)
            .Include(x=>x.Features)
            .ToListAsync();

        return role;
    }

    public async Task<Role> GetRoleAsync(string name)
    {
        var role = await _context.Roles
            .Include(x => x.Users)
            .Include(x => x.Features)
            .SingleAsync(r => r.Name == name);
        return role;
    }

    public async Task CreateRoleAsync(Role model)
    {
        await _context.Roles.AddAsync(model);

        await _context.SaveChangesAsync();
    }

    public async Task DeleteRoleAsync(string name)
    {
        var role = await _context.Roles.SingleAsync(scp => scp.Name == name);
        _context.Roles.Remove(role);

        await _context.SaveChangesAsync();
    }
}