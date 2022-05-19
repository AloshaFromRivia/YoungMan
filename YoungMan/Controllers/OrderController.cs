using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YoungMan.Models;

namespace YoungMan.Controllers
{
    public class OrderController : Controller
    {
        private IOrderRepository _repository;
        private Cart _cart;

        public OrderController(IOrderRepository repository,Cart cart)
        {
            _repository = repository;
            _cart = cart;
        }
        // GET
        public IActionResult Index()
        {
            return View(new Order());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(Order order)
        {
            if (!_cart.CartItems.Any()) 
            {
                ModelState.AddModelError("", "Ваша корзина пуста!");
            }
            if (ModelState.IsValid)
            {
                order.Items = _cart.CartItems.ToArray();
                _repository.AddOrder(order);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View(order);
            }
        }
    }
}