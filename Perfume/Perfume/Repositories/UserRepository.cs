using DataBaseLayout.Models;
using DataBaseLayout;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Perfume.Repositories.Interfaces;

namespace Perfume.Repositories;

public class UserRepository: IUserRepository
{
    private readonly SignInManager<User> _signInManager;
    private readonly UserManager<User> _userManager;

    public UserRepository(
        SignInManager<User> signInManager,
            UserManager<User> userManager)
    {
        _signInManager=signInManager;
        _userManager=userManager;
    }

    public async Task SignInAsync(User user)
    {
        await _signInManager.SignInAsync(user, false);
    }

    public async Task SignInAsync(string userName, string password)
    {
        await _signInManager.PasswordSignInAsync(userName, password, false, false);
    }

    public async Task SignOutAsync()
    {
        await _signInManager.SignOutAsync();
    }

    public async Task<List<User>> GetUsersAsync()
    {
        var users = await _userManager.Users.ToListAsync();
        return users;
    }

    public async Task<User> GetUserAsync(Guid id)
    {
        var users = await _userManager.Users.FirstAsync(s => s.Id == id);
        return users;
    }

    public async Task CreateUserAsync(User model)
    {
        await _userManager.CreateAsync(model);
    }

    public async Task DeleteUserAsync(Guid id)
    {
        var user = await _userManager.Users.FirstAsync(s => s.Id == id);
        await _userManager.DeleteAsync(user);
    }
}