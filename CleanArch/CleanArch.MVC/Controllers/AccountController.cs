using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CleanArch.Application.Interface;
using CleanArch.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using CleanArch.Domain.Models;
using CleanArch.Application.Security;
namespace CleanArch.MVC.Controllers
{
    public class AccountController : Controller
    {
        private IUserService _userService;
        public AccountController(IUserService userService)
        {
            _userService = userService;
        }
        
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [Route("Register")]
        public IActionResult Register(RegisterViewModel register)
        {

            if (!ModelState.IsValid)
            {
                return View(register);
            }
            CheckUser checkUser = _userService.checkUser(register.UserName, register.Email);
            if (checkUser != CheckUser.OK)
            {
                ViewBag.Check = checkUser;
                return View(register);
            }

            Domain.Models.User user = new User()
            {
                Email = register.Email.Trim().ToLower(),
                UserName = register.UserName,
                Password =PasswordHelper.EncodePasswordMd5(register.Password)
            };
            _userService.RegisterUser(user);
            return View("SuccessRegister",register);
        }
    }
}