using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using MojoDesignCollection.Models;
using MojoDesignCollection.Models.Components;
using MojoDesignCollection.Models.Repository;
using Moq;
using NUnit.Framework;

namespace MDCTest
{
    [TestFixture]
    class CanSelectCategory
    {
        [Test]
        public void CanSelectCategories()
        {
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns(
                (new[]
                {
                    new Product{ProductId = 1,Name = "P1",Category = CategoryEnum.Tutu.ToString()},
                    new Product{ProductId = 2,Name = "P2",Category = CategoryEnum.Fairy.ToString()},
                    new Product{ProductId = 3,Name = "P3",Category = CategoryEnum.Nixie.ToString()},
                    new Product{ProductId = 4,Name = "P4",Category = CategoryEnum.Tutu.ToString()}
                }).AsQueryable());

            NavigationMenuViewComponent nav = new NavigationMenuViewComponent(mock.Object);

            // Get Categories
            string[] result = ((IEnumerable<string>) ((ViewViewComponentResult) nav.Invoke()).ViewData.Model)
                .ToArray();

            Assert.IsTrue(result.SequenceEqual(new[] { "Tutu" ,"Fairy", "Nixie", "All"}));

        }
    }
}
