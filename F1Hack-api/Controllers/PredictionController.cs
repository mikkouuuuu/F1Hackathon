using F1Hack_api;
using F1Hack_api.Controllers;
using F1Hack_api.Entities.Identity;
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
            return Ok($"Added new Prediction with ID {entity.Id}.");
        }
        return BadRequest($"Invalid Prediction model.");
    }

    [HttpGet]
    [Route("GetAll/ByUserId/{userId}")]
    public IEnumerable<PredictionViewModel> GetAllByUserId(int userId)
    {
        return _context.Predictions.Where(x => x.UserId == userId).Select(x => x.ToViewModel());
    }

    [HttpGet]
    [Route("GetAll/ByUserId/{userId}/{groupId}")]
    public IEnumerable<PredictionViewModel> GetAllByUserId(int userId, int groupId)
    {
        return _context.Predictions.Where(x => x.UserId == userId && x.PredictionGroupId == groupId).Select(x => x.ToViewModel());
    }

    [HttpGet]
    [Route("GetAll/ByDescribingValue/{describingValue}")]
    public IEnumerable<PredictionViewModel> GetAllByDescribingValue(string describingValue)
    {
        return _context.Predictions.Where(x => x.PredictionValues.Any(x => x.DescribingValue == describingValue)).Select(x => x.ToViewModel());
    }

    [HttpGet]
    [Route("GetAll/ByGroupId/{groupId}")]
    public IEnumerable<PredictionViewModel> GetAllByGroupId(int groupId)
    {
        return _context.Predictions.Where(x => x.PredictionGroupId == groupId).Select(x => x.ToViewModel());
    }

    [HttpGet]
    [Route("GetAll/ByGroupId/{groupId}/{describingValue}")]
    public IEnumerable<PredictionViewModel> GetAllByGroupId(int groupId, string describingValue)
    {
        return _context.Predictions.Where(x => x.PredictionGroupId == groupId && x.PredictionValues.Any(x => x.DescribingValue == describingValue)).Select(x => x.ToViewModel());
    }
}