using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojoDesignCollection.Models;
using MojoDesignCollection.Models.Infrastructure;
using MojoDesignCollection.Models.Repository;

namespace MojoDesignCollection.Pages
{
    public class CartModel : PageModel
    {
        private readonly IStoreRepository _repository;
        public CartModel(IStoreRepository repository)
        {
            _repository = repository;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }
        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product product = _repository.Products
                .FirstOrDefault(p => p.ProductId == productId);
            Cart = HttpContext.Session.GetJson<Cart>("cart")
                   ?? new Cart();
            Cart.AddItem(product,1);
             HttpContext.Session.SetJson("cart", Cart);
            return RedirectToPage( new {returnUrl = returnUrl});
        }
    }
}