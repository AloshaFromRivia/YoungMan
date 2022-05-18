using System.Linq;

namespace YoungMan.Models
{
    public class EfProducts : IProductRepository
    {
        private AppDbContext _context;

        public EfProducts(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Product> Products => _context.Products;
    }
}