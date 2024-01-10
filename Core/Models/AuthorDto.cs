using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class AuthorDto
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "FullName Alanı zorunludur.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "En az 3 en fazla 50 karakter olmalıdır.")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "About Alanı zorunludur.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "En az 3 en fazla 50 karakter olmalıdır.")]
        public string About { get; set; }
    }
}
