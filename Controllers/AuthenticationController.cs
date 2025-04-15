using Hackathon_2025_Filipino_Homes.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Hackathon_2025_Filipino_Homes.Data.Services;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Hackathon_2025_Filipino_Homes.Controllers
{
    public class AuthenticationController : Controller
    {
        private readonly IAuthService _authenticationService;
        public AuthenticationController(IAuthService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public IActionResult Home()
        {
            return View();
        }
        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Home", "Bounty"); 
            }
            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> LoginProcess([Bind("Username, Password")] Account account, string ReturnUrl)
        {

            account.Password = _authenticationService.HashPassword(account.Password);
            bool valid = await _authenticationService.UserAccount(account.Username, account.Password);

            if (valid)
            {
                account = await _authenticationService.GetAccount(account.Username, account.Password);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, account.Username),
                    new Claim("AccountId", account.Id) // Important: Add the AccountId claim
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);
                return Redirect(ReturnUrl == null ? "/Home/Index" : ReturnUrl);
            }
            else
            {
                account.Password = string.Empty;
                ModelState.Remove("Password");
                ModelState.AddModelError("Password", "The password is incorrect");
                return View("Login", account);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Authentication");
        }
        public IActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Home", "Bounty");
            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> RegisterProcess(Account account)
        {

            if (ModelState.IsValid)
            {
                account.Password = _authenticationService.HashPassword(account.Password);
                await _authenticationService.Add(account);
                return RedirectToAction("Login", "Authentication");
            }
            return View("Register", account);
        }
    }
}
