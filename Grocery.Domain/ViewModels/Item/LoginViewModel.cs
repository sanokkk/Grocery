using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grocery.Domain.ViewModels.Item
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Ввведите имя")]
        [MaxLength(30, ErrorMessage ="Слишком длинное имя")]
        [MinLength(5, ErrorMessage ="Слишком короткое имя")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Ввведите пароль")]
        [DataType(DataType.Password)]
        [Display(Name="Пароль")]
        public string Password { get; set; }
    }
}
