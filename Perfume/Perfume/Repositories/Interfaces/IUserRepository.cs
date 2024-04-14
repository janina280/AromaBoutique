using DataBaseLayout.Models;

namespace Perfume.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetUsersAsync();
    Task CreateUserAsync(User model);
    Task DeleteUserAsync(Guid id);
}