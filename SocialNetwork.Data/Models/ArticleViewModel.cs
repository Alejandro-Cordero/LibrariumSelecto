using SocialNetwork.Core.Models;
using SocialNetwork.Data.Models.ViewModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialNetwork.Data.Models
{
    public class ArticleViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Título")]
        [Required(ErrorMessage = "Introduce un título para el artículo")]
        public string Title { get; set; }
        [Display(Name = "Contenido")]
        [Required(ErrorMessage = "Introduce contenido para el artículo")]
        public string Content { get; set; }
        [Display(Name = "Fecha de creación")]
        public DateTime CreationDate { get; set; }

        public int TypeTopicId { get; set; }
        [ForeignKey("TypeTopicId")]
        public TypeTopic TypeTopic { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public UserViewModel User { get; set; }


        public ICollection<CommentaryViewModel> Commentaries { get; set; }
        public int CommentaryCount { get; set; }

        public ICollection<RecommendationViewModel> Recommendations { get; set; }
        public int RecommendationCount { get; set; }
    }
}
