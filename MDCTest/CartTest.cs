using System.Linq;
using MojoDesignCollection.Models;
using NUnit.Framework;

namespace MDCTest
{
    [TestFixture]
    class CartTest
    {
        private Product p1, p2;
        [SetUp]
        public void Setup()
        {
             p1 = new Product { ProductId = 1, Name = "1" };
             p2 = new Product { ProductId = 2, Name = "2" };
        }
        [Test]
        public void Can_Add_Line()
        {
            //  arrange
            Cart cartTarget = new Cart();

            //  act
            cartTarget.AddItem(p1,1);
            cartTarget.AddItem(p2,1);

            //  assert
            CartLine[] result = cartTarget.Lines.ToArray();
            Assert.IsTrue(result.Length==2);
            Assert.AreEqual(p1,result[0].Product);
            Assert.AreEqual(p2, result[1].Product);
        }
        [Test]
        public void Add_Quantity_For_Existing()
        {
            Cart cart= new Cart();

            //  act
            cart.AddItem(p1,1);
            cart.AddItem(p2, 1);
            cart.AddItem(p1, 10);

            //  Assert
            CartLine[] result = cart.Lines.OrderBy(p=>p.Product.ProductId).ToArray();
            Assert.AreEqual(result.Length,2);
            Assert.AreEqual(cart.Lines[0].Quantity,11);
            Assert.AreEqual(cart.Lines[1].Quantity, 1);
        }

        [Test]
        public void RemoveProduct()
        {
            var cart = new Cart();
            // Arrange 
            cart.AddItem(p1,1);
            cart.AddItem(p2,1);
            cart.AddItem(p1, 9);

            // Act
            cart.RemoveLine(p2);

            // assert
            Assert.AreEqual(cart.Lines.Count,1);
            Assert.IsEmpty(cart.Lines.Where(p=>p.Product== p2));

        }

        [Test]
        public void CanCalculateTheTotalPrice()
        {
            var cart = new Cart();
            p1.Price = 99.99m;
            p2.Price = 45.95m;
            cart.AddItem(p1,1);
            cart.AddItem(p2,1);
            var total = cart.ComputeTotalPrice();
            // Assert
            Assert.AreEqual(total, 145.94m);
        }

        [Test]
        public void ClearCart()
        {
            Cart cart = new Cart();
            cart.AddItem(p1,1);cart.AddItem(p2,100);
            cart.ClearCart();
            
            //  assert
            Assert.True(!cart.Lines.Any());
        }
    }
}
