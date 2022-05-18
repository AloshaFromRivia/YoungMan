using System.Collections.Generic;
using System.Linq;

namespace YoungMan.Models
{
    public class TestCategoriesRepository : ICategoryRepository
    {
        private List<Category> _categories;
        public IQueryable<Category> Categories => _categories.AsQueryable();

        public TestCategoriesRepository()
        {
            _categories = new List<Category>()
            {
                new Category()
                {
                    Id = 1,
                    Name = "Кроссовки"
                },
                new Category()
                {
                    Id = 2,
                    Name = "Футболки"
                },
                new Category()
                {
                    Id = 3,
                    Name = "Джинсы"
                },
                new Category()
                {
                    Id = 4,
                    Name = "Головные уборы"
                }
            };
        }
    }
}