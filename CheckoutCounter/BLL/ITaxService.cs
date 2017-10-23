namespace CheckoutCounter.BLL
{
    public interface ITaxService
    {
        decimal CalculateTaxOnProduct(Product product, int quantity);
    }
}
