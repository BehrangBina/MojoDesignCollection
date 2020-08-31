using Microsoft.AspNetCore.Mvc;

namespace MojoDesignCollection.Controllers
{
    public class HomeController : Microsoft.AspNetCore.Mvc.Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
