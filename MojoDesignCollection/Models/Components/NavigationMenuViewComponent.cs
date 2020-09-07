using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;
using MojoDesignCollection.Models.Repository;

namespace MojoDesignCollection.Models.Components
{
    public class NavigationMenuViewComponent:ViewComponent
    {
        private IStoreRepository _repository;
        public NavigationMenuViewComponent(IStoreRepository storeRepository)
        {
            _repository = storeRepository;
        }

        public IViewComponentResult Invoke()
        {
            // Show only available categories
            //var categories =
            //    _repository
            //        .Products
            //        .Select(x => x.Category)
            //        .Distinct().OrderBy(x => x);

            List<string> categoryList =
                Enum.GetValues(typeof(CategoryEnum))
                    .Cast<CategoryEnum>()
                    .Select(c => c.ToString())
                    .ToList();
            return View("NavigationMenu", categoryList);
        }
    }
}
