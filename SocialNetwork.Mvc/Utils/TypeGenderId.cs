using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Mvc.Utils
{
    public enum TypeGenderId
    {
        [Display(Name = "Hombre")]
        Male = 1,
        [Display(Name = "Mujer")]
        Female = 2,
        [Display(Name = "Otro")]
        Other = 3
    }
}
