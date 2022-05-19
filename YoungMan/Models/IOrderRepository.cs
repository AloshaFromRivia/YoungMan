using System.Linq;
using System.Threading.Tasks;

namespace YoungMan.Models
{
    public interface IOrderRepository
    {
        IQueryable<Order> Orders { get;}
        void AddOrder(Order order);
    }
}