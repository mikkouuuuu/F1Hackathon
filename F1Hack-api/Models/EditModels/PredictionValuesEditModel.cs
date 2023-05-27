using F1Hack_api.Entities;

namespace F1Hack_api.Models
{
    public class PredictionValuesEditModel
    {
        public int PredictionId { get; set; }
        public string DescribingValue { get; set; }
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