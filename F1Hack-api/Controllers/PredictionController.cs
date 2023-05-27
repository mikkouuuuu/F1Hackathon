using F1Hack_api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PredictionController : ControllerBase
{
    private F1Context _context { get; }

    public PredictionController(F1Context context)
    {
        _context = context;
    }

    [HttpGet(Name = "GetUserPredictions")]
    public IEnumerable<PredictionViewModel> Get(int userId)
    {
        return _context.Predictions.Where(x => x.UserId == userId).Select(x => x.ToViewModel());
    }

    [HttpPost(Name = "AddUserPrediction")]
    public void Post(PredictionEditModel prediction)
    {
        _context.Predictions.Add(prediction.ToEntity());
        _context.SaveChanges();
    }
}