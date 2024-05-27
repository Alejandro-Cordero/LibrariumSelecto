using SocialNetwork.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Core.Models
{
    public class Article : Entity
    {
        [Display(Name = "Título")]
        [Required(ErrorMessage = "Introduce un título para el artículo")]
        public string Title { get; set; }

        [Display(Name = "Contenido")]
        [Required(ErrorMessage = "Introduce contenido para el artículo")]
        public string Content { get; set; }
        public DateTime CreationDate { get; set; }
        public int TypeTopicId { get; set; }
        public int UserId { get; set; }
        public ICollection<Commentary> Commentaries { get; set; }
        public ICollection<Recommendation> Recommendations { get; set; }
        public virtual User User { get; set; }
        public virtual TypeTopic TypeTopic { get; set; }

    }
}
