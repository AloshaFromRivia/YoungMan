using System.Linq;

namespace YoungMan.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}