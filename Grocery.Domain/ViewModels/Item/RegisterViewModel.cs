using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Domain.ViewModels.Item
{
    public class RegisterViewModel
    {
        [MaxLength(30, ErrorMessage ="Слишком длинное имя")]
        [MinLength(5, ErrorMessage ="Слишком короткое имя")]
        [Required]
        public string Name { get; set; }


        [MaxLength(30, ErrorMessage ="Длинный пароль")]
        [MinLength(5, ErrorMessage ="Слишком короткий пароль")]
        [Required]
        public string Password { get; set; }


        
        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string PasswordConfirm { get; set; }
    }
}
