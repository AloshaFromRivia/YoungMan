using System.Collections.Generic;
using System.Linq;

namespace YoungMan.Models
{
    public class Cart
    {
        private List<CartItemModel> _cartItems = new();
        
        public List<CartItemModel> CartItems => _cartItems;

        public decimal Total => _cartItems.Sum(p => p.SubTotal);

        public virtual void AddItem(Product product)
        {
            var cartItem = _cartItems.FirstOrDefault(p => p.Product.Id == product.Id);
            
            if (cartItem==null)
            {
                _cartItems.Add(new CartItemModel()
                {
                    Product = product,
                    Count = 1
                });
            }
            else
            {
                cartItem.Count++;
            }
        }

        public virtual void RemoveItem(Product product)
        {
            _cartItems.RemoveAll(p => p.Product.Id == product.Id);
        }

        public virtual void Clear() => _cartItems.Clear();
    }
}