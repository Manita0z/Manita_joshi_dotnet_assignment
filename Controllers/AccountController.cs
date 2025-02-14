using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using manita_dotnet_assignment.Data;
using Microsoft.AspNetCore.Authorization;

namespace manita_dotnet_assignment.Controllers
{
    [AllowAnonymous]  // Allow anonymous access for login
    public class AccountController : Controller
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(SignInManager<ApplicationUser> signInManager, UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        // GET: Account/Login
        public IActionResult Login()
        {
            return View();
        }

        // POST: Account/Login
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Attempt to sign in the user
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    // Redirect to the orders page after successful login
                    return RedirectToAction("Index", "Orders");
                }
                else
                {
                    // If login fails, show error message
                    ModelState.AddModelError("", "Invalid login attempt.");
                }
            }

            // Return the login view with validation errors if needed
            return View(model);
        }
    }
}
