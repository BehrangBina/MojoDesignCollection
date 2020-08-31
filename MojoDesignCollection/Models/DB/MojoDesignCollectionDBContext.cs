using Microsoft.EntityFrameworkCore;

namespace MojoDesignCollection.Models.DB
{
    public class MojoDesignCollectionDbContext:DbContext
    {
        public MojoDesignCollectionDbContext
            (DbContextOptions<MojoDesignCollectionDbContext> options) : base(options)
        {
        }
        public DbSet<Product> ProductsDbSet { get; set; }
         
    }
}
