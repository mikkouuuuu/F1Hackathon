using F1Hack_api.Entities.Identiy;
using F1Hack_api.Interfaces;
using F1Hack_api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F1Hack_api.Entities
{
    public class Prediction : IEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int UserId { get; set; }
        public int PredictionGroupId { get; set; }
        public virtual User User { get; set; }
        public virtual PredictionGroup PredictionGroup { get; set; }
        public virtual IEnumerable<PredictionValues> PredictionValues { get; set; }

        public PredictionViewModel ToViewModel()
        {
            return new PredictionViewModel()
            {
                PredictionValues = PredictionValues.Select(x => x.ToViewModel()).ToList(),
            };
        }
    }
}