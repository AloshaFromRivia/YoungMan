using System.Linq;

namespace YoungMan.Models
{
    public class EfCategories : ICategoryRepository
    {
        private AppDbContext _context;

        public EfCategories(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Category> Categories => _context.Categories;
    }
}