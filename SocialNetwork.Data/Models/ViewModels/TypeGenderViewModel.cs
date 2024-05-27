using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Data.Models.ViewModels;

public class TypeGenderViewModel
{
    [Required(ErrorMessage = "El id es obligatorio")]
    public int Id { get; set; }
    [Required(ErrorMessage = "El description es obligatorio")]
    public string Description { get; set; }
}
