using System.Linq;

namespace YoungMan.Models
{
    public interface ICategoryRepository
    {
        IQueryable<Category> Categories { get;}
    }
}