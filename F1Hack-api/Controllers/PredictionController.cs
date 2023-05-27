using F1Hack_api.Controllers;
using F1Hack_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity;

[ApiController]
[Route("[controller]")]
public class PredictionController : F1Controller
{
    public PredictionController(F1Context context) : base(context)
    {
    }

    [HttpPost]
    [Route("AddNew")]
    public void PostPrediction(PredictionEditModel prediction)
    {
        _context.Predictions.Add(prediction.ToEntity());
        _context.SaveChanges();
    }

    [HttpGet]
    [Route("GetAllByUserId")]
    public IEnumerable<PredictionViewModel> Get(int userId)
    {
        return _context.Predictions.Where(x => x.UserId == userId).Select(x => x.ToViewModel());
    }
}