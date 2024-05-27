using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Data.Models.ViewModels
{
    public class TypeTopicViewModel
    {
        [Key]
        public int Id { get; set; }
        [Display(Name = "Tópico")]
        public string Description { get; set; }
    }
}
