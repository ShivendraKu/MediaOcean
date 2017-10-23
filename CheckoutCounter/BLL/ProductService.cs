using System;
using System.Linq;
using CheckoutCounter.Db;

namespace CheckoutCounter.BLL
{
    public class ProductService : IProductService
    {
        private IRepository<Product> _productRepository;
        public ProductService(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        public Product GetProductByName(string name)
        {
            var product = _productRepository.GetAll().FirstOrDefault(t => t.Name == name);
            return product;
        }

        public void InitSampleProducts()
        {
            var prod1 = new Product()
            {
                Name = "Shampoo",
                Price = 100,
                TaxCategory = "TypeA",
                Category = "Body Care"
            };
            var prod2 = new Product()
            {
                Name = "Soap",
                Price = 9,
                TaxCategory = "TypeB",
                Category = "Body Care"
            };
            var prod3 = new Product()
            {
                Name = "ToothBrush Holder",
                Price = 12,
                TaxCategory = "TypeA",
                Category = "Home Furnishing"
            };
            var prod4 = new Product()
            {
                Name = "Lamp",
                Price = 220,
                TaxCategory = "TypeB",
                Category = "Home Furnishing"
            };
            var prod5 = new Product()
            {
                Name = "Rice",
                Price = 70,
                TaxCategory = "TypeA",
                Category = "Food"
            };

            _productRepository.Insert(prod1);
            _productRepository.Insert(prod2);
            _productRepository.Insert(prod3);
            _productRepository.Insert(prod4);
            _productRepository.Insert(prod5);
        }
    }
}
