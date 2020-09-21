using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MojoDesignCollection.Models;
using MojoDesignCollection.Models.Repository;

namespace MojoDesignCollection.Pages
{
    public class CartModel : PageModel
    {
        private readonly IStoreRepository _repository;
        public CartModel(IStoreRepository repository,Cart cartService)
        {
            _repository = repository;
            Cart = cartService;
        }
        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; }
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
          
             RedirectToPage(new { returnUrl = returnUrl });
        }
        public IActionResult OnPost(long productId, string returnUrl)
        {
            Product product = _repository.Products
                .FirstOrDefault(p => p.ProductId == productId);

            Cart.AddItem(product,1);
           
            return RedirectToPage( new {returnUrl = returnUrl});
        }

        public IActionResult OnPostRemove(long productId, string returnUrl)
        {
            Cart.RemoveLine(Cart.Lines.First(cl=>cl.Product.ProductId==productId).Product);
            return RedirectToPage(new {returnUrl = returnUrl});
        }
    }
}
