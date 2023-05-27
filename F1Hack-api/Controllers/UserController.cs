using F1Hack_api.Entities.Identiy;
using F1Hack_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace F1Hack_api.Controllers
{
    [AllowAnonymous]
    public class UserController : F1Controller
    {
        private SignInManager<User> _signInManager { get; }
        private UserManager<User> _userManager { get; }

        public UserController(F1Context context) : base(context)
        {
        }

        [HttpPost]
        [Route("SignIn")]
        public async Task<IActionResult> SignInAsync(UserLoginModel signInModel)
        {
            if (ModelState.IsValid)
            {
                var signInResult = await _userManager.CreateAsync(new User(signInModel.UserName), signInModel.Password);
                if (!signInResult.Succeeded)
                {
                    signInResult.Errors.ToList().ForEach(x => Console.WriteLine($"Error {x.Code}: {x.Description}."));
                }
            }
            return Ok();
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
