using System.Collections.Generic;
using MojoDesignCollection.Models;
using MojoDesignCollection.Models.Repository;
using Moq;
using NUnit.Framework;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using MojoDesignCollection.Controllers;
using MojoDesignCollection.Models.ModelView;

namespace MDCTest
{
    [TestFixture]
    public class TestStoreController
    {
        [Test]
        public void CanUseRepository()
        {
            Mock<IStoreRepository> mock = new Mock<IStoreRepository>();
 


            mock.Setup(m => m.Products).Returns((
                new Product[]
                {
                    new Product {Name = "Test1",Description = "Desc for Test1",Category = CategoryEnum.Tutu.ToString()},
                    new Product {Name = "Test2",Description = "Desc for Test2", Category = CategoryEnum.Fairy.ToString()}
                }
            ).AsQueryable<Product>());

            //  Act
            StoreController storeController = new StoreController(mock.Object);
            ProductListViewModel productListViewModels = storeController.Index(null)
                .ViewData.Model as ProductListViewModel;

            // assert 
            Product[] productArray = productListViewModels?.Products?.ToArray();
            Assert.AreEqual(productArray?.Length, 2);
            Assert.AreEqual(productArray[0]?.Category, CategoryEnum.Tutu.ToString());
            Assert.AreEqual(productArray[1]?.Name, "Test2");


        }

        [Test]
        public void TestPagination()
        {
            // ACT
            Mock<IStoreRepository> storeRepoMock = new Mock<IStoreRepository>();

            storeRepoMock.Setup(m => m.Products)
                .Returns((new Product[]
                {
                    new Product {Name = "Test1", Price = 99.90m},
                    new Product {Name = "Test2", Price = 98.90m},
                    new Product {Name = "Test3", Price = 97.90m},
                    new Product {Name = "Test4", Price = 96.90m},
                    new Product {Name = "Test5", Price = 95.90m},
                    new Product {Name = "Test6", Price = 94.90m}
                }).AsQueryable<Product>());

            StoreController storeController = new StoreController(storeRepoMock.Object);
            storeController.PageSize = 4;
            
            // ARRANGE
            ProductListViewModel productListView =
                ((ViewResult) storeController.Index(null,2))
                .ViewData.Model as ProductListViewModel;

            // Assert 
            Product[] products = productListView.Products.ToArray();
            Assert.That(products.Length==2);
            Assert.AreEqual(products[0].Name, "Test5");
            Assert.AreEqual(products[0].Price, 95.90m);
            Assert.AreEqual(products[1].Name, "Test6");
            Assert.AreEqual(products[1].Price, 94.90m);
        }
    }
}
