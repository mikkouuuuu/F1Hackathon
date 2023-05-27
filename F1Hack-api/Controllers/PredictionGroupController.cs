using F1Hack_api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace F1Hack_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PredictionGroupController : F1Controller
    {
        public PredictionGroupController(F1Context context) : base(context)
        {
        }

        [HttpPost]
        [Route("AddNew")]
        public IActionResult PostPredictionGroup(PredictionGroupEditModel predictionGroup)
        {
            var entity = predictionGroup.ToEntity();
            _context.PredictionGroups.Add(entity);
            _context.SaveChanges();
            return Ok($"Added new Prediction Group with ID {entity.Id}.");
        }

        [HttpGet]
        [Route("GetAll")]
        public IEnumerable<PredictionGroupViewModel> GetPredictionGroups()
        {
            return _context.PredictionGroups.Select(x => x.ToViewModel());
        }
    }
}
