using F1Hack_api.Interfaces;
using F1Hack_api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F1Hack_api.Entities
{
    public class PredictionValues : IEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int PredictionId { get; set; }
        public string DescribingValue { get; set; }
        public string PredictionValue { get; set; }
        public virtual Prediction Prediction { get; set; }

        public PredictionValuesViewModel ToViewModel()
        {
            return new PredictionValuesViewModel()
            {
                DescribingValue = DescribingValue,
                PredictionValue = PredictionValue
            };
        }
    }
}