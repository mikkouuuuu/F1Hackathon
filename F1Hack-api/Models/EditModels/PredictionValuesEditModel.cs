using F1Hack_api.Entities;
using System.ComponentModel.DataAnnotations;

namespace F1Hack_api.Models
{
    public class PredictionValuesEditModel
    {
        public int PredictionId { get; set; }
        [Required]
        public string DescribingValue { get; set; }
        [Required]
        public string PredictionValue { get; set; }

        public PredictionValues ToEntity()
        {
            return new PredictionValues()
            {
                PredictionId = PredictionId,
                DescribingValue = DescribingValue,
                PredictionValue = PredictionValue
            };
        }
    }
}