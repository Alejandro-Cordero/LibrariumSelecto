using System;
using System.ComponentModel.DataAnnotations;
using SocialNetwork.Core.Models.Base;
using System.ComponentModel.DataAnnotations;

namespace SocialNetwork.Core.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El título es obligatorio")]
        [StringLength(100, ErrorMessage = "El título no puede tener más de 100 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "El autor es obligatorio")]
        [StringLength(100, ErrorMessage = "El autor no puede tener más de 100 caracteres")]
        public string Author { get; set; }

        [Required(ErrorMessage = "El género es obligatorio")]
        public string Genre { get; set; }

        [Required(ErrorMessage = "La fecha de publicación es obligatoria")]
        public DateTime PublicationDate { get; set; }

        [StringLength(1000, ErrorMessage = "La descripción no puede tener más de 1000 caracteres")]
        public string Description { get; set; }

        [Url(ErrorMessage = "El enlace de compra debe ser una URL válida")]
        public string PurchaseLink { get; set; }
    }
}
