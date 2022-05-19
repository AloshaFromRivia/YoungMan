using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace YoungMan.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Имя получателя")]
        public string Name { get; set; }
        [Required]
        [DisplayName("Город")]
        public string City { get; set; }
        [Required]
        [DisplayName("Страна")]
        public string Country { get; set; }
        [Required]
        [DisplayName("Адрес")]
        public string Line { get; set; }
        [Required]
        [DisplayName("Номер телефона")]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        [DisplayName("Почтовый индекс")]
        [DataType(DataType.PostalCode)]
        public int PostalCode { get; set; }
        [Required]
        [DisplayName("Номер карты")]
        [DataType(DataType.CreditCard)]
        public string Card { get; set; }
        [BindNever]
        public bool IsShipped { get; set; }
        public ICollection<CartItemModel> Items { get; set; }
    }
}