using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Entity
{
    public class Book
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "İsim Alanı zorunludur.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "En az 3 en fazla 50 karakter olmalıdır.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Açıklama Alanı zorunludur.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "En az 3 en fazla 50 karakter olmalıdır.")]
        public string Description { get; set; }
        public string Isbn { get; set; }
        [ForeignKey("PublisherId")]
        public virtual Publisher Publisher { get; set; }
        public long PublisherId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
        public long AuthorId { get; set; }
    }
}
