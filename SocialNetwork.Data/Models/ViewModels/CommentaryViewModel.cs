using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Data.Models.ViewModels
{
    public class CommentaryViewModel
    {
        public int Id { get; set; }

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

        public int UserId { get; set; }
        public virtual UserViewModel User { get; set; }
        public int ArticleId { get; set; }
        public virtual ArticleViewModel Article { get; set;}
    }
}
