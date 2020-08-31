using System.Collections.Generic;
using System.Linq;

namespace MojoDesignCollection.Models.ModelView
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}
