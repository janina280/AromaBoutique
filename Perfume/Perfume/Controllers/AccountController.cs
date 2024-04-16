﻿using Microsoft.AspNetCore.Mvc;
using Perfume.Models;

namespace Perfume.Controllers;

public class AccountController : Controller
{
    private readonly ILogger<AccountController> _logger;

    public AccountController(ILogger<AccountController> logger)
    {
        _logger = logger;
    }

    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Login(LoginModel login)
    {
        if (!ModelState.IsValid)
        {
            return View(login);
        }

        //get token
        //save token

        return RedirectToAction("Index", "Home");
    }
    public IActionResult Logout()
    {
        //todo: logout
        return RedirectToAction("Login", "Account");
    }

    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Register(RegisterModel register)
    {
        if (!ModelState.IsValid)
        {
            return View(register);
        }

        //save account

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