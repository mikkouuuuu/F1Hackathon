using F1Hack_api;
using F1Hack_api.Controllers;
using F1Hack_api.Entities.Identiy;
using F1Hack_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity;
using System.Security.Claims;

[ApiController]
[Route("[controller]")]
public class PredictionController : F1Controller
{
    private UserManager<User> _userManager { get; }
    public PredictionController(F1Context context, UserManager<User> userManager) : base(context)
    {
        _userManager = userManager;
    }

    [HttpPost]
    [Route("AddNew")]
    public IActionResult PostPrediction(PredictionEditModel prediction)
    {
        if (ModelState.IsValid)
        {
            var entity = prediction.ToEntity();
            entity.UserId = Int32.Parse(_userManager.GetUserId(this.User));
            _context.Predictions.Add(entity);
            _context.SaveChanges();
            return Ok();
        }
        return BadRequest();
    }

    [HttpGet]
    [Route("GetAllByUserId")]
    public IEnumerable<PredictionViewModel> Get(int userId)
    {
        return _context.Predictions.Where(x => x.UserId == userId).Select(x => x.ToViewModel());
    }
}