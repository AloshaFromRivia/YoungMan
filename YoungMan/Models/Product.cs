using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YoungMan.Models
{
    public record Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [DisplayName("Название")]
        public string Name { get; set; }
        [DisplayName("Описание")]
        public string Description { get; set; }
        [Required]
        [DisplayName("В наличии")]
        public bool? InStock { get; set; }
        [Required]
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        [Required]
        [DisplayName("Id Категории")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public Category Category { get; set; }
        [Required]
        [Range(0,5)]
        public byte Mark { get; set; }
    }
}