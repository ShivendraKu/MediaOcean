using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutCounter.BLL;
using Unity;

namespace CheckoutCounter.Tests
{
    [TestClass]
    public class OrderServiceFixture
    {
        private IOrderService _orderService;

        [TestInitialize]
        public void Setup()
        {
            BusinessApp.Init();
            _orderService = BusinessApp.Container.Resolve<IOrderService>();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _orderService = null;
        }

        [TestMethod]
        public void ShouldInitOrderWithDate()
        {
            var order = _orderService.CreateNewOrder();
            Assert.IsNotNull(order);
            Assert.AreEqual(order.OrderDate.Date, DateTime.Now.Date);
        }

        [TestMethod]
        public void ShouldAddItemsIntoOrder()
        {
            var order = _orderService.CreateNewOrder();
            Assert.AreEqual(order.OrderDetails.Count, 0);
            var mockProduct = new Product()
            {
                Id = 1,
                Name = "Pen",
                Category = "Stationary",
                TaxCategory = "TypeA",
                Price = 20
            };
            _orderService.AddProductToOrder(order, mockProduct, 5);

            Assert.AreEqual(order.OrderDetails.Count, 1);
            Assert.AreSame(order.OrderDetails[0].Item, mockProduct);
        }

        [TestMethod]
        public void ShouldSaveOrderToDb()
        {
            var order = _orderService.CreateNewOrder();
            var mockProduct = new Product()
            {
                Id = 1,
                Name = "Pen",
                Category = "Stationary",
                TaxCategory = "TypeA",
                Price = 20
            };
            _orderService.AddProductToOrder(order, mockProduct, 5);
            _orderService.SaveOrder(order);

            var orderNew = _orderService.GetOrderById(order.Id);
            Assert.AreEqual(order, orderNew);
        }

        [TestMethod]
        public void ShouldReturnOrderWithId()
        {
            var order = _orderService.CreateNewOrder();
            var mockProduct = new Product()
            {
                Id = 1,
                Name = "Pen",
                Category = "Stationary",
                TaxCategory = "TypeA",
                Price = 20
            };
            _orderService.AddProductToOrder(order, mockProduct, 5);
            _orderService.SaveOrder(order);

            var order1 = _orderService.CreateNewOrder();
            var mockProduct1 = new Product()
            {
                Id = 2,
                Name = "Pen",
                Category = "Stationary",
                TaxCategory = "TypeA",
                Price = 20
            };
            _orderService.AddProductToOrder(order1, mockProduct1, 10);
            _orderService.SaveOrder(order1);

            var orderFetch = _orderService.GetOrderById(order1.Id);

            Assert.AreEqual(order1, orderFetch);

        }
    }
}
