using Microsoft.AspNetCore.Identity;
using Perfume.Models;

namespace Perfume.Services.Interfaces;

public interface IUserService
{
    Task<IdentityResult> RegisterAsync(RegisterModel register);

    Task<IdentityResult> UpdateUserAsync(UpdateUserModel model);

    Task<UpdateUserModel> GetUserDetailAsync(string name);
}