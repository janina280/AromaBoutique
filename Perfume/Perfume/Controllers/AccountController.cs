using DataBaseLayout.Models;
using Microsoft.AspNetCore.Mvc;
using Perfume.Models;
using Perfume.Repositories.Interfaces;
using Perfume.Services.Interfaces;

namespace Perfume.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;
    private readonly IUserRepository _userRepository;
    private readonly IImageConvertorService _imageConvertorService;

    public AccountController(ILogger<AccountController> logger,
        IUserRepository userRepository,
        IImageConvertorService imageConvertorService
    )
    {
        _logger = logger;
        _imageConvertorService= imageConvertorService;
        _userRepository= userRepository;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task <IActionResult> LoginAsync(LoginModel login)
    {
        if (!ModelState.IsValid)
        {
            return View(login);
        }
        await _userRepository.SignInAsync(login.Email, login.Password);

        return RedirectToAction("Index", "Home");
    }
    public async Task<IActionResult> LogoutAsync()
    {
        await _userRepository.SignOutAsync();
        
        return RedirectToAction("Login", "Account");
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public async Task< IActionResult> RegisterAsync(RegisterModel register)
    {
        if (!ModelState.IsValid)
        {
            return View(register);
        }

        await _userRepository.CreateUserAsync(new User()
        {
            Id = Guid.NewGuid(),
            ProfileImage = await _imageConvertorService.ConvertFileFormToByteArrayAsync(register.ProfileImage),
            LastName = register.LastName,
            Email = register.Email,
            FileName = register.ProfileImage.FileName,
            PhoneNumber = register.PhoneNumber,
            TwoFactorEnabled = false,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true,
            ImageName = register.ProfileImage.Name,
            FirstName = register.FirstName,
        });

        return RedirectToAction("Login", "Account");
    }

    public IActionResult Details()
    {
        //get user details

        var user = new UpdateUserModel()
        {
            Email = "janina@yahoo.com",
            PhoneNumber = "0765956330",
            FirstName = "Janina",
            LastName = "Cocei"
        };

        return View(user);
    }

    [HttpPost]
    public IActionResult Details(UpdateUserModel model)
    {
        //HttpPostedFileBase file = Request.Files["ImageData"];
        if (!ModelState.IsValid)
        {
            return View(model);
        }

        //todo: save
        return View(model);
    }

    public IActionResult DeleteAccount(UpdateUserModel model)
    {
        //todo: delete user
        return RedirectToAction("Logout", "Account");
    }
}