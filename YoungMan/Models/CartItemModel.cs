namespace YoungMan.Models
{
    public class CartItemModel
    {
        public int Id { get; set; }
        public Product Product { get; set; }
        public int Count { get; set; }
        public decimal SubTotal => Product.Price * Count;
    }
}