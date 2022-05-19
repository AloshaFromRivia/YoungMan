using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using YoungMan.Models.ViewModels;

namespace YoungMan.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private SignInManager<IdentityUser> _signInManager;
        private UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        public IActionResult Login() => View(new LoginModel());

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(loginModel.Email);
                if (user != null)
                {
                    var result = await _signInManager.PasswordSignInAsync(user,loginModel.Password,false,false);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("","Неверный логин/пароль");
                }
            }
            return View(loginModel);
        }

        public IActionResult Registration() => View();

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Registration(RegistrationModel registrationModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(registrationModel.Email);
                if (user == null)
                {
                    user = new IdentityUser()
                    {
                        UserName = registrationModel.Name,
                        Email = registrationModel.Email,
                        PhoneNumber = registrationModel.PhoneNumber
                    };
                    var result = await _userManager.CreateAsync(user, registrationModel.Password);
                    if (result.Succeeded)
                    {
                        await _signInManager.SignInAsync(user, false);
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        AddErrorsFromModel(result);
                    }
                }
                else
                {
                    ModelState.AddModelError("","Пользователь с данным E-mail уже зарагестрирован");
                }
            }

            return View(registrationModel);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        private void AddErrorsFromModel(IdentityResult result)
        {
            foreach (IdentityError identityError in result.Errors)
            {
                ModelState.AddModelError("",identityError.Description);
            }
        }
    }
}