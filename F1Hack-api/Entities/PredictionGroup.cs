using F1Hack_api.Interfaces;
using F1Hack_api.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F1Hack_api.Entities
{
    public class PredictionGroup : IEntity
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string GroupName { get; set; }
        public virtual IEnumerable<Prediction> Predictions { get; set; }

        public PredictionGroupViewModel ToViewModel()
        {
            return new PredictionGroupViewModel()
            {
                Id = Id,
                GroupName = GroupName
            };
        }
    }
}