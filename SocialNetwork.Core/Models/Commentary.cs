using SocialNetwork.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Core.Models
{
    public class Commentary : Entity
    {
        [Required(ErrorMessage = "El titulo es obligatorio")]
        [Display(Name = "Titulo: ")]
        public string Title { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [Display(Name = "Descripción: ")]
        public string Description { get; set; }

        [Display(Name = "Fecha: ")]
        public DateTime Date { get; set; }

        [Required(ErrorMessage = "La valoración es obligatoria")]
        [Display(Name = "Valoración: ")]
        [Range(1, 5, ErrorMessage = "El valor debe estar entre 1 y 5.")]
        public int Rating { get; set; }

        public virtual User User { get; set; }
        public int UserId { get; set; }
        public virtual Article Article { get; set; }
        public int ArticleId { get; set; }

    }
}
