using F1Hack_api.Entities.Identiy;
using F1Hack_api.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace F1Hack_api.Controllers
{
    public class UserController : F1Controller
    {
        private SignInManager<User> _signInManager { get; }
        private UserManager<User> _userManager { get; }

        public UserController(F1Context context) : base(context)
        {
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync(UserLoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(loginModel.UserName);
                if (user != null)
                {
                    var loginResult = await _signInManager.PasswordSignInAsync(user, loginModel.Password, true, false);
                    if (loginResult.Succeeded)
                    {
                        return Ok("Login succeeded!");
                    }
                }
            }
            return BadRequest("Invalid login attempt.");
        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            await _signInManager.SignOutAsync();
            return Ok();
        }
    }
}
