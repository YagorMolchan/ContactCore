using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ContactCore.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Display(Name = "Имя")]
        [Required(ErrorMessage = "Имя должно быть введено!")]
        public string Firstname { get; set; }

        [Display(Name = "Фамилия")]
        [Required(ErrorMessage = "Фамилия должна быть введена!")]
        public string Lastname { get; set; }        

        [Required(ErrorMessage = "Email должен быть введен!")]
        [Display(Name = "Email")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Некорректно введен пароль!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Пароль должен быть введен!")]
        [Display(Name = "Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Пароль должен быть подтвержден!")]
        [Display(Name = "Подтвердите пароль")]        
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают!")]
        public string ConfirmPassword { get; set; }
    }
}
