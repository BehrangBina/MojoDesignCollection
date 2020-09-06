using System;
using Microsoft.AspNetCore.Mvc;
using MojoDesignCollection.Models.Repository;
using System.Linq;
using MojoDesignCollection.Models;
using MojoDesignCollection.Models.Helper;
using MojoDesignCollection.Models.ModelView;

namespace MojoDesignCollection.Controllers
{
    public class StoreController :Controller
    {
        private readonly IStoreRepository _repository;
        public int PageSize=3;
        public StoreController(IStoreRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index(string category ,int productPage = 1)
        {

            //PagingInfo pagingInfo = new PagingInfo
            //{
            //    CurrentPage = productPage,
            //    ItemsPerPage = PageSize,
            //    TotalItems = _repository.Products.Count()
            //};
            IQueryable<Product> products = _repository
                .Products;

         

            if (!string.Equals(category, CategoryEnum.All.ToString(), 
                StringComparison.OrdinalIgnoreCase) )
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
            products =  products.OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize);

            ProductListViewModel productListViewModel = new ProductListViewModel
            {
                PagingInfo = pagingInfo, Products = products, Category = Convertor.StringToCategoryEnum(category).ToString()
            };
            return View(productListViewModel);
 
            
        }

    }
}
