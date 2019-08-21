using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Animax.Models;
using Animax.ViewModels;
using Microsoft.AspNetCore.Identity;

namespace Animax.Controllers
{
    public class AccountController : Controller
    {
        private SignInManager<Membro> _signInManager;
        private UserManager<Membro> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public AccountController(SignInManager<Membro> signInManager, UserManager<Membro> userManager, RoleManager<IdentityRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public IActionResult Login()
        {
            if (this.User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Mensagens");
            }
            return View();
        }

        [HttpPost, ActionName("Login")]
        public async Task<IActionResult> LoginPost(LoginViewModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(loginModel.UserName, loginModel.Password, loginModel.RememberMe, false);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Mensagens");
                }
            }
            ModelState.AddModelError("", "Faild to Login");
            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Mensagens");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost, ActionName("Register")]
        public async Task<IActionResult> RegisterPost(RegisterViewModel registerModel)
        {
            if (ModelState.IsValid)
            {
                Membro membro = new Membro
                {
                    Nome = registerModel.FirstName,
                    NomeUsuario = registerModel.UserName,
                    Email = registerModel.Email,
                    UserName = registerModel.UserName
                };

                var result = await _userManager.CreateAsync(membro, registerModel.Password);
                if (result.Succeeded)
                {
                    bool roleExists = await _roleManager.RoleExistsAsync(registerModel.RoleName);
                    if (!roleExists)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(registerModel.RoleName));
                    }

                    if (!await _userManager.IsInRoleAsync(membro, registerModel.RoleName))
                    {
                        await _userManager.AddToRoleAsync(membro, registerModel.RoleName);
                    }

                    var resultSignIn = await _signInManager.PasswordSignInAsync(registerModel.UserName, registerModel.Password, registerModel.RememberMe, false);
                    if (resultSignIn.Succeeded)
                    {
                        return RedirectToAction("Index", "Mensagens");
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }
            return View();
        }
    }
}