using System.Linq;
using MojoDesignCollection.Models.Repository;

namespace MojoDesignCollection.Models.DB
{
    public class EfMdcRepository :IStoreRepository
    {
        private readonly MojoDesignCollectionDbContext _context;

        public EfMdcRepository(MojoDesignCollectionDbContext context)
        {
            this._context = context;
        }

        public IQueryable<Product> Products => _context.ProductsDbSet;
        
    }
}
