using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YoungMan.Models.ViewModels
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Введите почту")]
        [DisplayName("Почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Требуется пароль")]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}