using F1Hack_api.Entities;

namespace F1Hack_api.Models
{
    public class PredictionGroupEditModel
    {
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
