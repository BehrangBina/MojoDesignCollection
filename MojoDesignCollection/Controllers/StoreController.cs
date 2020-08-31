using Microsoft.AspNetCore.Mvc;
using MojoDesignCollection.Models.Repository;
using System.Linq;
using MojoDesignCollection.Models;
using MojoDesignCollection.Models.ModelView;

namespace MojoDesignCollection.Controllers
{
    public class StoreController :Controller
    {
        private readonly IStoreRepository _repository;
        public int PageSize=4;
        public StoreController(IStoreRepository repository)
        {
            _repository = repository;
        }

        public ViewResult Index(int productPage = 1, string category = null)

        {

            PagingInfo pagingInfo = new PagingInfo
            {
                CurrentPage = productPage,
                ItemsPerPage = PageSize,
                TotalItems = _repository.Products.Count()
            };
            IQueryable<Product> products = _repository
                .Products
                .OrderBy(p => p.ProductId)
                .Skip((productPage - 1) * PageSize)
                .Take(PageSize);

            ProductListViewModel productListViewModel = new ProductListViewModel
            {
                PagingInfo = pagingInfo,
                Products = products
            };
            return View(productListViewModel);
            //var categoryEnum = Convertor.StringToCategoryEnum(category);
            //if ( categoryEnum != CategoryEnum.All)
            //{
                
            //    return View(
            //        _repository
            //            .Products
            //            .OrderBy(p => p.ProductId)
            //            .Where(p=>p.Category.ToLower().Contains(categoryEnum.ToString().ToLower()))
            //            .Skip((productPage - 1) * PageSize)
            //        .Take(PageSize));
            //}

            //return  View(
            //    _repository
            //        .Products
            //        .OrderBy(p => p.ProductId)
            //        .Skip((productPage - 1) * PageSize)re
            //        .Take(PageSize)
            //);
            
        }

    }
}
