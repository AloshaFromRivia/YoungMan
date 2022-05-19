using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public async Task<Product> FindByIdAsync(int id) => await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
    }
}