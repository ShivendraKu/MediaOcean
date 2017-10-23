namespace CheckoutCounter.BLL
{
    public interface IProductService
    {
        void InitSampleProducts();
        Product GetProductByName(string name);

        // More functions are required in real app. I ommited `em as they are not needed for this test.
    }

    
}
