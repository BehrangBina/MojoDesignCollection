using System.Linq;
using Microsoft.EntityFrameworkCore;
using MojoDesignCollection.Models.Repository;

namespace MojoDesignCollection.Models.DB
{
    public class EFOrderRepository:IOrderRepository
    {
        private MojoDesignCollectionDbContext _context;

        public EFOrderRepository(MojoDesignCollectionDbContext context)
        {
            _context = context;
        }

        public IQueryable<Order> Orders => _context.Orders
            .Include(o => o.Lines)
            .ThenInclude(l => l.Product);

        public void SaveOrder(Order order)
        {
            // avoid writing objects that already in db 
            _context.AttachRange(order.Lines.Select(l=>l.Product));
            if (order.OrderID == 0)
            {
                _context.Orders.Add(order);
            }

            _context.SaveChanges();
        }
    }
}
