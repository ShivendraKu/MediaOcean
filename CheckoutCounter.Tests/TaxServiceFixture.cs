using Microsoft.VisualStudio.TestTools.UnitTesting;
using CheckoutCounter.BLL;
using Unity;

namespace CheckoutCounter.Tests
{
    [TestClass]
    public class TaxServiceFixture
    {
        private ITaxService _taxService;
        private IProductService _productService;

        [TestInitialize]
        public void Setup()
        {
            BusinessApp.Init();
            _taxService = BusinessApp.Container.Resolve<ITaxService>();
            _productService = BusinessApp.Container.Resolve<IProductService>();
        }

        [TestCleanup]
        public void CleanUp()
        {
            _taxService = null;
            _productService = null;
        }

        [TestMethod]
        public void ShouldCalculateTaxUsingCorrectStrategy()
        {
            _productService.InitSampleProducts();
            var productSoap = _productService.GetProductByName("Soap");
            var quantity = 5;
            var taxCalculatedByService = _taxService.CalculateTaxOnProduct(productSoap, quantity);

            var taxCalculatedManually = (productSoap.Price * quantity) * 20 / 100;

            Assert.AreEqual(taxCalculatedByService, taxCalculatedManually);
        }

    }
}
