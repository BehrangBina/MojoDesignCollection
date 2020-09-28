using Microsoft.AspNetCore.Mvc;
using MojoDesignCollection.Models;

namespace MojoDesignCollection.Controllers
{
    public class OrderController : Controller
    {
        public ViewResult Checkout()
        {
            return View(new Order());
        }
    }
}
