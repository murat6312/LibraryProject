using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAcces.Entity
{
    public class User
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "İsim Alanı zorunludur.")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "En az 3 en fazla 50 karakter olmalıdır.")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Kimlik numarası Alanı zorunludur.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Kimlik numarası 11 karakter olmalıdır.")]
        public string IdentificationNumber {  get; set; }
        
    }
}
