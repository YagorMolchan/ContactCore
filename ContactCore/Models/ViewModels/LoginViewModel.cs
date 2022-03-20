using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCore.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email должен быть введен!")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Некорректно введен пароль!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль должен быть введен!")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Запомнить меня?")]
        public bool RememberMe { get; set; }


    }
}
