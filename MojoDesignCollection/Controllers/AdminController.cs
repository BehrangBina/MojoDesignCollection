using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MojoDesignCollection.Models;
using MojoDesignCollection.Models.Repository;

namespace MojoDesignCollection.Controllers
{
    public class AdminController : Controller
    {
        private readonly IStoreRepository _repository;
        public AdminController(IStoreRepository repository)
        {
            _repository = repository;
        }
       
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Products()
        {
            IQueryable<Product> products = _repository
                .Products;
            return View(products);
        }

        public IActionResult Orders(string TableTitle)
        {

            return View();
        }
    }
}
