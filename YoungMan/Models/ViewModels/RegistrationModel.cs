using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace YoungMan.Models.ViewModels
{
    public class RegistrationModel
    {
        [Required(ErrorMessage = "Введите имя пользователя")]
        [DisplayName("Имя пользователя")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Введите почту")]
        [DisplayName("Почта")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Требуется пароль")]
        [DisplayName("Пароль")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Требуется номер телефона")]
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }
    }
}