using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MojoDesignCollection.Models
{
    public class Order
    {
        [BindNever] public int OrderID { get; set; }
        [BindNever] public ICollection<CartLine> Lines { get; set; }
        
        [Required(ErrorMessage = "Please Enter The Name")]
        public string Name{ get; set; }

        [Required(ErrorMessage = "Please Enter The First Address line")]
        public string Line1 { get; set; }

        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please Enter City Name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter State")]
        public string State { get; set; }

        public string Zip { get; set; }
        [Required(ErrorMessage = "Please Enter Country")]
        public string Country { get; set; }
        public bool GiftWrap { get; set; }
    }
}
