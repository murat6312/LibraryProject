using System.ComponentModel.DataAnnotations;

namespace DataAcces.Entity
{
    public class Author
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "İsim Alanı zorunludur.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "En az 3 en fazla 50 karakter olmalıdır.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Açıklama Alanı zorunludur.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "En az 3 en fazla 50 karakter olmalıdır.")]
        public string About { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
