using SocialNetwork.Core.Models.Base;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Core.Models
{
    public class User : Entity
    {
        public User()
        {
            Articles = new Collection<Article>();
        }

        [Required(ErrorMessage = "El login es obligatorio")]
        public string Login { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatoria")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio.")]
        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [RegularExpression(@"^\d{9}$", ErrorMessage = "El teléfono debe tener 9 números.")]
        public string? Phone { get; set; }

        public DateTime? Birthdate { get; set; }

        [Required(ErrorMessage = "El correo electrónico es obligatorio")]
        [EmailAddress(ErrorMessage = "El correo electrónico no tiene un formato válido.")]
        public string Email { get; set; }

        public int? TypeGenderId { get; set; }

        public virtual TypeGender? TypeGender { get; set; }
        public ICollection<Article> Articles { get; set; }
    }
}
