using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TechLift.FinalProject.Models;
using TechLift.FinalProject.ViewModel;

namespace TechLift.FinalProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        protected readonly ApllicationDBContext _db;
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ApllicationDBContext db)
        {
            _db = db;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInVM signIn, string ReturnUrl)
        {
            User user = await _userManager.FindByEmailAsync(signIn.UsernameOrEmail);

            if (user == null)
            {
                ModelState.AddModelError("", "Please Enter Valid Email and Password");
                return View(signIn);
            }
            var result = await _signInManager.PasswordSignInAsync(user, signIn.Password, true, true);
            if (!result.Succeeded)
            {
                HttpContext.Session.SetString("UserId", "0");
                ModelState.AddModelError("", "Please Enter Valid Email and Password");
                return View(signIn);
            }
            if (ReturnUrl != null) return LocalRedirect(ReturnUrl);
            HttpContext.Session.SetString("UserId", user.Id);
            return RedirectToAction("Index", "Home");

        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM register)
        {
            if (!ModelState.IsValid) return View();
            User newUser = new User
            {
                Email = register.Email,
                UserName = register.Username,
                Firstname = register.Firstname,
                Lastname = register.Username,
                PhoneNumber = register.PhoneNumber,
                Deleted = false

            };
            IdentityResult result = await _userManager.CreateAsync(newUser, register.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            return RedirectToAction("SignIn");
        }
        //public async Task<IActionResult> SignOut()
        //{
        //    await _signInManager.SignOutAsync();
        //    return RedirectToAction(nameof(SignIn));
        //}
    }
}
