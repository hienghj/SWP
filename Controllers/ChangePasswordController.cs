using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SWP_Project.Areas.Identity.Data;
using System.Threading.Tasks;
using SWP_Project.Models;

namespace SWP_Project.Controllers
{
    public class ChangePasswordController : Controller
    {
        private readonly UserManager<User> _userManager;

        public ChangePasswordController(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        // Hiển thị trang đổi mật khẩu
        [HttpGet]
        public IActionResult ChangePassword()
        {
            return View();
        }

        // Xác thực mật khẩu hiện tại
        [HttpPost]
        public async Task<IActionResult> VerifyCurrentPassword([FromBody] VerifyPasswordView model)
        {
            var user = await _userManager.GetUserAsync(User);
            var isPasswordValid = await _userManager.CheckPasswordAsync(user, model.CurrentPassword);

            if (isPasswordValid)
            {
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        // Thay đổi mật khẩu
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordView model)
        {
            if (!ModelState.IsValid) return View(model);

            var user = await _userManager.GetUserAsync(User);
            var result = await _userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

            if (result.Succeeded)
            {
                return RedirectToAction("Profile", "User"); // Điều hướng đến trang hồ sơ sau khi đổi mật khẩu thành công
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(model);

        }

    }


}
