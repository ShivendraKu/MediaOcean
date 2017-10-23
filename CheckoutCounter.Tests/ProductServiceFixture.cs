using Microsoft.VisualStudio.TestTools.UnitTesting;
using Unity;
using CheckoutCounter.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutCounter.Tests
{
    [TestClass]
    public class ProductServiceFixture
    {
        private IProductService _productService;
        [TestInitialize]
        public void Setup()
        {
            BusinessApp.Init();
            _productService = BusinessApp.Container.Resolve<IProductService>();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _productService = null;
        }

        [TestMethod]
        public void ShouldReturnProductByName()
        {
            _productService.InitSampleProducts();

            var product = _productService.GetProductByName("Soap");

            Assert.AreEqual("Soap", product.Name);
        }
    }
}
