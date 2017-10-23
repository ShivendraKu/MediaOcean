using CheckoutCounter.BLL;
using CheckoutCounter.UI;
using System;
using Unity;

namespace CheckoutCounter
{
    class Program
    {
        // The main function here is acting as UI Layer
        static void Main(string[] args)
        {
            var productService = BusinessApp.Container.Resolve<IProductService>();
            var orderService = BusinessApp.Container.Resolve<IOrderService>();
            productService.InitSampleProducts();
            
            
            var order = orderService.CreateNewOrder();
            orderService.AddProductToOrder(order, productService.GetProductByName("Shampoo"), 1);
            orderService.AddProductToOrder(order, productService.GetProductByName("Rice"), 5);
            orderService.AddProductToOrder(order, productService.GetProductByName("Soap"), 4);
            orderService.SaveOrder(order);

            order.PrintOrderDetailsToConsole();
            Console.ReadLine();
        }
    }
}
