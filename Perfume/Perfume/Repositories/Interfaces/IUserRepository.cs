using DataBaseLayout.Models;

namespace Perfume.Repositories.Interfaces;

public interface IUserRepository
{
    Task SignInAsync(User user);
    Task SignInAsync(string userName, string password);
    Task SignOutAsync();
    Task<List<User>> GetUsersAsync();
    Task<User> GetUserAsync(Guid id);
    Task CreateUserAsync(User model);
    Task DeleteUserAsync(Guid id);
}