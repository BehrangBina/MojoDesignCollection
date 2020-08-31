using System.Linq;

namespace MojoDesignCollection.Models.Repository
{
   public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
        
    }
}
