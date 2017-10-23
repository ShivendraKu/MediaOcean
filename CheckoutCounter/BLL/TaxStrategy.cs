namespace CheckoutCounter.BLL
{
    public abstract class TaxStrategy
    {
        public abstract decimal CalculateTax(Product product, int quantity);
    }
}
