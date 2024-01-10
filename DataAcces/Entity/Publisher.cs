using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Entity
{
    public class Publisher
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "İsim Alanı zorunludur.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "En az 3 en fazla 50 karakter olmalıdır.")]
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
    }
}
