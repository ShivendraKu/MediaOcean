using System;

namespace CheckoutCounter.BLL
{
    /// <summary>
    /// Type B Product levi 20% tax
    /// </summary>
    public class TypeBTaxStrategy : TaxStrategy
    {
        public override decimal CalculateTax(Product product, int quantity)
        {
            if (product.TaxCategory != "TypeB")
                throw new Exception($"102: Product of type {product.TaxCategory} cannot be applied with TypeB Taxstrategy.");

            var price = product.Price * quantity;
            var tax = price * 20 / 100;
            return tax;
        }
    }
}
