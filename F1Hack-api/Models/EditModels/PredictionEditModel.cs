using F1Hack_api.Entities;
using System.ComponentModel.DataAnnotations;

namespace F1Hack_api.Models
{
    public class PredictionEditModel
    {
        [Required]
        public int PredictionGroupId { get; set; }
        public IEnumerable<PredictionValuesEditModel> PredictionValues { get; set; }

        public Prediction ToEntity()
        {
            return new Prediction()
            {
                PredictionGroupId = PredictionGroupId,
                PredictionValues = PredictionValues.Select(x => x.ToEntity())
            };
        }
    }
}