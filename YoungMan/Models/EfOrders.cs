using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YoungMan.Models
{
    public class EfOrders : IOrderRepository
    {
        private AppDbContext _context;

        public EfOrders(AppDbContext context)
        {
            _context = context;
        }

        public IQueryable<Order> Orders => _context.Orders;

        public void AddOrder(Order order)
        {
            _context.AttachRange(order.Items.Select(l=>l.Product));
            
             _context.Add(order);
             _context.SaveChanges();
        }
    }
}