using Microsoft.AspNetCore.Mvc;

namespace MojoDesignCollection.Models.Components
{
    public class SideCartViewComponent : ViewComponent
    {
        private Cart cart;

        public SideCartViewComponent(Cart cartService)
        {
            cart = cartService;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }
    }
}
