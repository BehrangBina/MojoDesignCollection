using Microsoft.AspNetCore.Mvc;

namespace MojoDesignCollection.Models.Components
{
    public class CartSummaryViewComponent:ViewComponent
    {
        private Cart cart;

        public CartSummaryViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
