using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MojoDesignCollection.Models
{
    public class Product
    {
        [Key]
        public long ProductId { get; set; }

        public bool InStock { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; } = 1;
        [Column(TypeName="decimal(8,2)")]
        public decimal? Price { get; set; }
        public string Category { get; set; }

    }

  
}