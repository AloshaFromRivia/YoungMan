using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using YoungMan.Models;

namespace YoungMan.Controllers
{
    public class HomeController : Controller
    {
        private IProductRepository _productRepository;
        private ICategoryRepository _categoryRepository;
        private int productsPerPage=8;
        
        // GET
        public HomeController(IProductRepository productRepository,ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult Index() => View();
        public ViewResult About() => View();

        //GET
        //Paginated list
        public IActionResult Catalog([FromRoute]int id=0)
        {
            var paginatedList = new PaginatedList<Product>(_productRepository.Products)
            {
                ItemsPerPage = productsPerPage
            };
            
            ViewBag.Id = id+1;
            ViewBag.TotalPages = paginatedList.TotalPages;
            ViewBag.Categories = new SelectList(_categoryRepository.Categories, "Id", "Name");
            
            ViewBag.CategoryId = Request.Query["categoryId"];
            ViewBag.SearchString = Request.Query["searchString"];
            
            return View(paginatedList.GetItemsByPage(id));
        }

        //Search With paginated list
        [HttpGet]
        public IActionResult Catalog(string searchString, int categoryId=0, [FromRoute]int id = 0)
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
            
            ViewBag.Id = id+1; //page number
            ViewBag.TotalPages = paginatedList.TotalPages;
            ViewBag.Categories = new SelectList(_categoryRepository.Categories, "Id", "Name");
            
            ViewBag.CategoryId = Request.Query["categoryId"];
            ViewBag.SearchString = Request.Query["searchString"];
            
            return View(paginatedList.GetItemsByPage(id));
        }

        public RedirectResult Clear() => Redirect($"~/Home/Catalog/0");
    }
}