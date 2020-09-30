using System;
using System.Collections.Generic;
using System.Text;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using Microsoft.AspNetCore.Mvc;
using MojoDesignCollection.Controllers;
using MojoDesignCollection.Models;
using MojoDesignCollection.Models.Repository;
using Moq;
using NUnit.Framework;

namespace MDCTest
{
    [TestFixture]
    class OrderControllerTests
    {
        [Test]
        public void Cannot_Checkout_Empty_Cart()
        {
            // Arrange
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            Cart cart = new Cart();
            Order order = new Order();
            OrderController orderController = new OrderController(mock.Object,cart);

            // Act
            ViewResult checkoutView = orderController.Checkout(order) as ViewResult;

            // assert
            mock.Verify(m=>m.SaveOrder(order),Times.Never);
            Assert.True(string.IsNullOrEmpty(checkoutView.ViewName));
            Assert.False(checkoutView.ViewData.ModelState.IsValid);
        }

        [Test]
        public void Can_Checkout_And_Submit_Order()
        {

            // arrange - mock order repo
            Mock<IOrderRepository> mock = new Mock<IOrderRepository>();
            Cart cart = new Cart();
            cart.AddItem(new Product(), 1);
            OrderController target = new OrderController(mock.Object, cart);

            // Act
            RedirectToPageResult result= target.Checkout(new Order()) as RedirectToPageResult;
            
            // Assert
            mock.Verify(m=>m.SaveOrder(It.IsAny<Order>()),Times.Once);
            Assert.AreEqual("/Completed",result?.PageName);

        }

    
    }
}
