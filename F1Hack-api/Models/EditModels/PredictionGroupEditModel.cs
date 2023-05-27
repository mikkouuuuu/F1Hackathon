using F1Hack_api.Entities;
using System.ComponentModel.DataAnnotations;

namespace F1Hack_api.Models
{
    public class PredictionGroupEditModel
    {
        [Required]
        public string GroupName { get; set; }
        public PredictionGroup ToEntity()
        {
            return new PredictionGroup()
            {
                GroupName = GroupName
            };
        }
    }
}
