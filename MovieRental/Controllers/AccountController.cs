using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieRental.Data;
using MovieRental.Models;
using System.Threading.Tasks;

namespace MovieRental.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("index", "home");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");
            }

            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Copy data from RegisterViewModel to IdentityUser
                var user = new ApplicationUser
                {
                    UserName = model.Email,
                    Email = model.Email,
                    AuctionKey = "eyJhbGciOiJSUzI1NiIsInR5cCI6IkpXVCJ9.eyJzY3AiOiIiLCJ1aWQiOiJvcG5pZ2h0IiwiaWF0IjoxNjAzNTg0OTQ0LCJleHAiOjE2MDM1ODg1NDR9.Y9AIb3855aYCYvk_WnX5IbRM1xkZAhZMByb7WlCQJoKgG1dMNberNvwBr53AKdrc-3S9Ptv8UCIND4ISRGS3WwkLBvJhwduKHn6xJvMVPwDTicx286M19-zRCWppE7QHP91n49JwbmZp694jnuP9TbOPubPBNSlNhsYJMa1jo2w9stND1p3PgNHZeleaQihFq7ksG90ZS8hRVNRffdnM1GRrZ3rSy75nNXjVvpshWe5tj9GlYn4Vz-FqvST2-ivNfp4Hk2ut8vzTcmNN3X1WvQt3WlMoyQp4tjL9XQN7vf2VmOXriYi6RotNFB-szrwNkHeDLUhyQ3Nr37CbBzwzkw"
                };

                // Store user data in AspNetUsers database table
                var result = await userManager.CreateAsync(user, model.Password);

                // If user is successfully created, sign-in the user using
                // SignInManager and redirect to index action of HomeController
                if (result.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("index", "home");
                }

                // If there are any errors, add them to the ModelState object
                // which will be displayed by the validation summary tag helper
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View(model);
        }
    }
}
