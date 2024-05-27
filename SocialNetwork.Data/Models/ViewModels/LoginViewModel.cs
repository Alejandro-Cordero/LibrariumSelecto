using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Data.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        public string User { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
