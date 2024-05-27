using SocialNetwork.Core.Models;
using SocialNetwork.Data.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Data.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El login es obligatorio")]
        public string Login { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string FirstName { get; set; }

        public string LastName { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "El teléfono debe tener 9 números.")]
        public string Phone { get; set; }

        public DateTime? Birthdate { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
        public string Email { get; set; }

        [Required]
        public TypeGenderViewModel TypeGender { get; set; }
        
        public int TypeGenderId { get; set; }
    }
}
