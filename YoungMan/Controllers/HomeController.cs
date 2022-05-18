using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using YoungMan.Models;

namespace YoungMan.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _productRepository;
        private int productsPerPage=8;
        
        // GET
        public HomeController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IActionResult Index() => View();
        public ViewResult About() => View();

        //GET
        //Paginated list
        public IActionResult Catalog(int id=0)
        {
            var paginatedList = new PaginatedList<Product>(_productRepository.Products)
            {
                ItemsPerPage = productsPerPage
            };
            return View(paginatedList.GetItemsByPage(id));
        }

        //Search With paginated list
        [HttpGet]
        public IActionResult Catalog(string searchString, int categoryId=0, int id = 0)
        {
            var products = _productRepository.Products;
            //search by name
            if (!string.IsNullOrEmpty(searchString))
                products= products.Where(p => 
                    p.Name
                    .ToLower()
                    .Contains(searchString.ToLower()));
            //search by category
            if (categoryId != 0) products = products.Where(p => p.CategoryId == categoryId);
            
            //pagination
            var paginatedList = new PaginatedList<Product>(products)
            {
                ItemsPerPage = productsPerPage
            };
            return View(paginatedList.GetItemsByPage(id));
        }
    }
}