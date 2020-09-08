using System;
using System.Collections.Generic;
using System.Linq;

namespace MojoDesignCollection.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }=new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine line = Lines.FirstOrDefault(p => p.Product.ProductId == product.ProductId);
            if (line == null)
            {
                Lines.Add(new CartLine {Product = product, Quantity = quantity});
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product)
        {
            Lines.RemoveAll(p => p.Product.ProductId == product.ProductId);
        }

        public void ClearCart()
        {
            Lines.Clear();
        }

        public decimal ComputeTotalPrice()
        {
          var total = Lines.Sum(p => p.Quantity * p.Product.Price);
          return Convert.ToDecimal(total);
        }

    }

    public class CartLine
    {
        public int CartLineId { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
}
