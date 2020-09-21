using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MojoDesignCollection.Models.Repository;
using System.Linq;
using MojoDesignCollection.Models;
using MojoDesignCollection.Models.Helper;
using MojoDesignCollection.Models.Infrastructure;
using MojoDesignCollection.Models.ModelView;

namespace MojoDesignCollection.Controllers
{
    public class StoreController : Controller
    {
        private readonly IStoreRepository _repository;
        public int PageSize = 3;
        public Cart Cart { get; set; }

        public StoreController(IStoreRepository repository, Cart cartService)
        {
            _repository = repository;
            Cart = cartService;
        }

        public ViewResult Index(string category, int productPage = 1)
        {
            if (HttpContext != null)
            {
                ViewBag.cart = HttpContext.Session.GetJson<Cart>("cart");
            }

            IQueryable<Product> products = _repository
                .Products;



            if (!string.Equals(category, CategoryEnum.All.ToString(),
                StringComparison.OrdinalIgnoreCase))
            {
                products = products.Where(p =>
                    p.Category.ToLower() == Convertor.StringToCategoryEnum(category).ToString().ToLower());
            }

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = products.Count()
            };
            products = products.OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize);

            ProductListViewModel productListViewModel = new ProductListViewModel
            {
                PagingInfo = pagingInfo,
                Products = products,
                Category = Convertor.StringToCategoryEnum(category).ToString()
            };
            return View(productListViewModel);
        }

        [HttpPost]
        public void Index(long productId,string returnUrl)
        {
            int productPage = QueryString.GetPageNumber(returnUrl);
            var category = QueryString.GetCategory(returnUrl);
            Product product = _repository.Products
                .FirstOrDefault(p => p.ProductId == productId);
            var cart = HttpContext.Session.GetJson<Cart>("cart")
                   ?? new Cart();

            cart.AddItem(product, 1);
            
            HttpContext.Session.SetJson("cart", cart);
            ViewBag.cart = HttpContext.Session.GetJson<Cart>("cart");
            
            Response.Redirect($"/Store?productPage={productPage}&category={category}");
        }

        [HttpPost]
        public void Remove(long productId, string returnUrl)
        { 
            Cart.RemoveLine(Cart.Lines.First(cl => cl.Product.ProductId == productId).Product);
            Response.Redirect($"/Store"+returnUrl);
        }
 

    }
}
