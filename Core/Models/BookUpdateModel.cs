using System.ComponentModel.DataAnnotations;

namespace Core.Models
{
    public class BookUpdateModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name Alanı zorunludur.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "En az 3 en fazla 50 karakter olmalıdır.")]

        public string Name { get; set; }

        [Required(ErrorMessage = "Isbn alanı zorunludur.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "En az 3 en fazla 50 karakter olmalıdır.")]

        public string Isbn { get; set; }
        [Required(ErrorMessage = "Description alanı zorunludur.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "En az 3 en fazla 50 karakter olmalıdır.")]
        public string Description { get; set; }
        public int PublisherId { get; set; }
        public int AuthorId { get; set; }
    }
}
