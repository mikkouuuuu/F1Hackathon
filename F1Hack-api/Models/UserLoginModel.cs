using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace F1Hack_api.Models
{
    public class UserLoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
