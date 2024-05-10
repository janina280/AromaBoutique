﻿using DataBaseLayout.Models;
using Microsoft.AspNetCore.Identity;
using Perfume.Constants;
using Perfume.Models;
using Perfume.Repositories.Interfaces;
using Perfume.Services.Interfaces;

namespace Perfume.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly UserManager<User> _userManager;
    private readonly IImageConvertorService _imageConvertorService;

    public UserService(
        IUserRepository userRepository,
        IImageConvertorService imageConvertorService,
        UserManager<User> userManager)
    {
        _userRepository = userRepository;
        _imageConvertorService = imageConvertorService;
        _userManager = userManager;
    }

    public async Task<IdentityResult> RegisterAsync(RegisterModel register)
    {
        var user = new User()
        {
            Id = Guid.NewGuid(),
            ProfileImage = await _imageConvertorService.ConvertFileFormToByteArrayAsync(register.ProfileImage),
            LastName = register.LastName,
            Email = register.Email,
            FirstName = register.FirstName,
            PhoneNumber = register.PhoneNumber,
            TwoFactorEnabled = false,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            ImageName = register.ProfileImage.Name,
            FileName = register.ProfileImage.FileName,
            UserName = register.Email
        };
        var result = await _userRepository.CreateUserAsync(user, register.Password);
        if (!result.Succeeded)
        {
            return result;
        }

        result = await _userManager.AddToRoleAsync(user, Roles.User);

        return result;
    }

    public async Task<IdentityResult> UpdateUserAsync(UpdateUserModel model)
    {
        var result = new IdentityResult();
        var currentUser = await _userRepository.GetUserAsync(model.Id);
        if (currentUser.Email != model.Email)
        {
            result = await _userRepository.UpdateUserEmailAsync(currentUser, model.Email, "TODO");
        }
        if (currentUser.PhoneNumber != model.PhoneNumber && result.Succeeded)
        {
            result = await _userRepository.UpdateUserPhoneNumberAsync(currentUser, model.PhoneNumber, "TODO");
        }

        if (!result.Succeeded)
        {
            return result;
        }

        var user = new User()
        {
            Id = Guid.NewGuid(),
            ProfileImage = await _imageConvertorService.ConvertFileFormToByteArrayAsync(model.ProfileImage),
            LastName = model.LastName,
            Email = model.Email,
            FirstName = model.FirstName,
            PhoneNumber = model.PhoneNumber,
            TwoFactorEnabled = false,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            ImageName = model.ProfileImage.Name,
            FileName = model.ProfileImage.FileName,
            UserName = model.Email
        };

        result = await _userRepository.UpdateUserAsync(user);
        return result;
    }

    public async Task<UpdateUserModel> GetUserDetailAsync(string name)
    {
        var user = await _userRepository.GetUserAsync(name);

        var profileImageFileForm = await _imageConvertorService.ConvertByteArrayToFileFormAsync(new ImageDto()
        {
            Image = user.ProfileImage,
            FileName = user.FileName,
            ImageName = user.ImageName
        });

        var userDto = new UpdateUserModel()
        {
            Email = user.Email,
            FirstName = user.FirstName,
            PhoneNumber = user.PhoneNumber,
            Id = user.Id,
            ProfileImage = profileImageFileForm,
            LastName = user.LastName,
            ProfileImageDisplay = await _imageConvertorService.ConvertFormFileToImageAsync(profileImageFileForm)
        };

        return userDto;
    }
}