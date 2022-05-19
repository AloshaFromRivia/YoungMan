using System.Linq;
using System.Threading.Tasks;

namespace YoungMan.Models
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        Task<Product> FindByIdAsync(int id);
    }
}