using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoungMan.Models
{
    public class TestProductRepository : IProductRepository
    {
        private List<Product> _products;

        public IQueryable<Product> Products => _products.AsQueryable();
        public Task<Product> FindByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public TestProductRepository()
        {
            _products = new List<Product>();
            _products.AddRange(new []
            {
                new Product()
                {
                    Name = "TetName",
                    CategoryId = 1,
                    Category = new Category()
                    {
                        Name = "test cat"
                    },
                    Price = 1000,
                    Mark = 4
                },
                new Product()
                {
                    Name = "TetName1",
                    CategoryId = 2,
                    Category = new Category()
                    {
                        Name = "test cat2"
                    },
                    Price = 2000,
                    Mark = 2
                },
                new Product()
                {
                    Name = "TetName3",
                    CategoryId = 3,
                    Category = new Category()
                    {
                        Name = "test cat3"
                    },
                    Price = 10000,
                    Mark = 1
                },
                new Product()
                {
                    Name = "TetName5",
                    CategoryId = 4,
                    Category = new Category()
                    {
                        Name = "test cat5"
                    },
                    Price = 10005,
                    Mark = 5
                },
                new Product()
                {
                    Name = "TetName3",
                    CategoryId = 1,
                    Category = new Category()
                    {
                        Name = "test cat"
                    },
                    Price = 1000,
                    Mark = 4
                }
            });
        }
    }
}