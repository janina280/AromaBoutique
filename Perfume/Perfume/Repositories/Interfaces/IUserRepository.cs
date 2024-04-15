using DataBaseLayout.Models;

namespace Perfume.Repositories.Interfaces;

public interface IUserRepository
{
    Task<List<User>> GetUsersAsync();
    Task<User> GetUserAsync(Guid id);
    Task CreateUserAsync(User model);
    Task DeleteUserAsync(Guid id);
}