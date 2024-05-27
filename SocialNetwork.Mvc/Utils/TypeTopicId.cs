using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Mvc.Utils
{
    public enum TypeTopicId
    {
        [Display(Name = "Oficina")]
        Office = 1,
        [Display(Name = "Libros")]
        Books = 2,
        [Display(Name = "eLearning")]
        eLearning = 3,
        [Display(Name = "Innovación")]
        Innovation = 4,
        [Display(Name = "Otros")]
        Others = 5
    }
}
