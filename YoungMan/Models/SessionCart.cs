using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using YoungMan.Infrastructure;

namespace YoungMan.Models
{
    public class SessionCart : Cart
    {
        [JsonIgnore]
        public ISession Session { get; set; }
        
        /// <summary>
        /// Get cart from session
        /// </summary>
        /// <param name="serviceProvider"></param>
        /// <returns>Cart from session if exist</returns>
        public static Cart GetCart(IServiceProvider serviceProvider)
        {
            var session = serviceProvider
                .GetRequiredService<IHttpContextAccessor>()
                .HttpContext.Session;
            var cart = session?.GetJson<SessionCart>("Cart") ?? new SessionCart();
            cart.Session = session;
            return cart;
        }

        public override void AddItem(Product product)
        {
            base.AddItem(product);
            Session.SetJson("Cart",this);
        }

        public override void RemoveItem(Product product)
        {
            base.RemoveItem(product);
            Session.SetJson("Cart",this);
        }

        public override void Clear()
        {
            base.Clear();
            Session.Remove("Cart");
        }
    }
}