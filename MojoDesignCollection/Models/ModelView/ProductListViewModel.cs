using System.Collections.Generic;

namespace MojoDesignCollection.Models.ModelView
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
        public string Category { get; set; }
    }
}
