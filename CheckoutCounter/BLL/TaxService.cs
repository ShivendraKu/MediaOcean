using System;

namespace CheckoutCounter.BLL
{
    public class TaxService : ITaxService
    {
        private TaxStrategy getStrategy(Product product)
        {
            TaxStrategy taxStrategy = null;
            switch (product.TaxCategory)
            {
                case "TypeA":
                    taxStrategy = new TypeATaxStrategy();
                    break;
                case "TypeB":
                    taxStrategy = new TypeBTaxStrategy();
                    break;
                default:
                    break;
            }

            if (taxStrategy == null)
                throw new Exception("103: Product has been assigned with invalid tax category");

            return taxStrategy;
        }

        public decimal CalculateTaxOnProduct(Product product, int quantity)
        {
            var strategy = getStrategy(product);
            var tax = strategy.CalculateTax(product, quantity);

            return tax;
        }
    }
}
