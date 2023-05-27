using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace F1Hack_api.Entities.Identity
{
    public class User : IdentityUser<int>
    {
        public virtual IEnumerable<Prediction> Predictions { get; set; }
        public User(string userName)
        {
            UserName = userName;
            Predictions = new List<Prediction>();
        }
    }
}
