using Microsoft.AspNetCore.Mvc;
using SWP_Project.Areas.Identity.Data;
using SWP_Project.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace SWP_Project.Controllers
{
    public class UpdateProfileController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;

        public UpdateProfileController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> UpdateProfile()
        {
            var currentUser = await _userManager.GetUserAsync(User);

            if (currentUser == null)
            {
                return RedirectToAction("Login", "Account");
            }

            var model = new Profile
            {
                Name = currentUser.FirstName + " " + currentUser.LastName,
                Email = currentUser.Email,
                PhoneNumber = currentUser.PhoneNumber
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(Profile model)
        {
            if (ModelState.IsValid)
            {
                var currentUser = await _userManager.GetUserAsync(User);

                if (currentUser == null)
                {
                    return RedirectToAction("Login", "Account");
                }

                var names = model.Name.Split(' ');
                currentUser.FirstName = names[0];
                currentUser.LastName = names.Length > 1 ? names[1] : "";

                currentUser.Email = model.Email;
                currentUser.PhoneNumber = model.PhoneNumber;

                var result = await _userManager.UpdateAsync(currentUser);

                if (result.Succeeded)
                {
                    return RedirectToAction("Profile", "Profile");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
            }

            return View(model);
        }
    }
}
