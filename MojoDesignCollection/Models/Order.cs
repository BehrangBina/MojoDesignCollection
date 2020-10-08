using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MojoDesignCollection.Models
{
    public class Order
    {
        [BindNever] public int OrderID { get; set; }
        [BindNever] public ICollection<CartLine> Lines { get; set; }
        
        [Required(ErrorMessage = "Please Enter The First Name")]
        public string FirstName{ get; set; }

        [Required(ErrorMessage = "Please Enter The Last Name")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Please Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please Enter The First Address line")]
        public string Line1 { get; set; }

        public string Line2 { get; set; }
        public string Line3 { get; set; }

        [Required(ErrorMessage = "Please Enter City Name")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please Enter State")]
        public string State { get; set; }

        [Required(ErrorMessage = "Please Provide Zip/PostCode")]
        public string Zip { get; set; }

        public string Phone { get; set; }
        [Required(ErrorMessage = "Please Enter Country")]
        public string Country { get; set; }

        public bool GiftWrap { get; set; }
        public string NoteToSeller { get; set; }
        [BindNever] public  bool Shipped { get; set; }
    }
}
