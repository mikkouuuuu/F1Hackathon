using F1Hack_api.Entities;

namespace F1Hack_api.Models
{
    public class PredictionEditModel
    {
        public int UserId { get; set; }
        public int PredictionGroupId { get; set; }
        public IEnumerable<PredictionValuesEditModel> PredictionValues { get; set; }

        public Prediction ToEntity()
        {
            return new Prediction()
            {
                PredictionValues = PredictionValues.Select(x => x.ToEntity());
            }
        }
    }
}