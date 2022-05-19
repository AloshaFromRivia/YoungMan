using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using YoungMan.Models;

namespace YoungMan.Controllers
{
    [Authorize]
    public class CartController : Controller
    {
        public IProductRepository _repository;
        public Cart _cart;
        
        
        public CartController(IProductRepository repository, Cart cart)
        {
            _repository = repository;
            _cart = cart;
        }
        
        // GET
        public IActionResult Index()
        {
            return View(_cart);
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int productId)
        {
            var item = await _repository.FindByIdAsync(productId);
            if(item!=null)
            {
                _cart.AddItem(item);
                return RedirectToAction("Index");
            }
            else
            {
               return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int productId)
        {
            var item = await _repository.FindByIdAsync(productId);
            if (item != null)
            {
                _cart.RemoveItem(item);
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }
    }
}