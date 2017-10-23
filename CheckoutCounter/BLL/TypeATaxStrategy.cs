using System;

namespace CheckoutCounter.BLL
{
    /// <summary>
    /// Type A Product levi 10% tax
    /// </summary>
    public class TypeATaxStrategy : TaxStrategy
    {
        public override decimal CalculateTax(Product product, int quantity)
        {
            if (product.TaxCategory != "TypeA")
                throw new Exception($"102: Product of type {product.TaxCategory} cannot be applied with TypeA Taxstrategy.");

            var price = product.Price * quantity;
            var tax = price * 10 / 100;
            return tax;
        }
    }
}
