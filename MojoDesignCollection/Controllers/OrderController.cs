

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MojoDesignCollection.Models;
using MojoDesignCollection.Models.Repository;

namespace MojoDesignCollection.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository _repository;
        private readonly Cart _cart;

        public OrderController(IOrderRepository repository, Cart cart)
        {
            _repository = repository;
            _cart = cart;
        }

        public ViewResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (!_cart.Lines.Any())
            {
                ModelState.AddModelError("", "Sorry Your Cart Is Empty");
            }

            if (ModelState.IsValid)
            {
                order.Lines = _cart.Lines.ToArray();
                _repository.SaveOrder(order);
                _cart.ClearCart();
                return RedirectToPage("/Completed", new {orderId = order.OrderID});
            }
            else
            {
                return View();
            }

        }
    }

}
