using System.Linq;
using MojoDesignCollection.Controllers;
using MojoDesignCollection.Models;
using MojoDesignCollection.Models.ModelView;
using MojoDesignCollection.Models.Repository;
using Moq;
using NUnit.Framework;

namespace MDCTest
{
    [TestFixture]
    class TestSendingPaginationToViewModel
    {
        [Test]
        public void SendPaginationToViewModel()
        {
            //  Arrange
            Mock <IStoreRepository> mock = new Mock<IStoreRepository>();
            mock.Setup(m => m.Products).Returns((new[]
            {
                new Product {Name = "P1", ProductId = 1},
                new Product {Name = "P2", ProductId = 2},
                new Product {Name = "P3", ProductId = 3},
                new Product {Name = "P4", ProductId = 4},
                new Product {Name = "P5", ProductId = 5},
                new Product {Name = "P6", ProductId = 6}
            }).AsQueryable());
            // Define Page Size 
            StoreController storeController = new StoreController(mock.Object){PageSize = 3};
            
            // Act
            ProductListViewModel result =
                storeController.Index(null,2).Model as ProductListViewModel;
            
            // Assert
            PagingInfo pagingInfo = result?.PagingInfo;
            Assert.AreEqual(pagingInfo.CurrentPage  , 2 , "Current Page");
            Assert.AreEqual(pagingInfo.ItemsPerPage , 3 , "Items Per Page");
            Assert.AreEqual(pagingInfo.TotalPages   , 2 , "Total Page");
            Assert.AreEqual(pagingInfo.TotalItems   , 6 , "Total Items");




        }
    }
}
