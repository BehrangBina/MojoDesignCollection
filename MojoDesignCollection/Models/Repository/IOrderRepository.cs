using System.Linq;

namespace MojoDesignCollection.Models.Repository
{
    public interface IOrderRepository
    {
        IQueryable <Order> Orders { get;   }
        void SaveOrder(Order order);
    }
}
