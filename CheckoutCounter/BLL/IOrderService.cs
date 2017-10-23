namespace CheckoutCounter.BLL
{
    public interface IOrderService
    {
        Order CreateNewOrder();
        Order GetOrderById(int id);
        void SaveOrder(Order order);
        void AddProductToOrder(Order order, Product product, int quantity);
        void RemoveProductFromOrder(Order order, Product product, int quantity);
    }
}
