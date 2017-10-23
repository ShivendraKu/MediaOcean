using CheckoutCounter.BLL;
using CheckoutCounter.Db;
using Unity;

namespace CheckoutCounter
{
    public class BusinessApp
    {
        private static UnityContainer _container;
        public static UnityContainer Container { get { return _container; } }

        static BusinessApp()
        {
            Setup();
        }
        public static void Init() { }

        private static void Setup()
        {
            var container = new UnityContainer();

            container.RegisterType<ITaxService, TaxService>();
            container.RegisterType<IRepository<Order>, OrderRepository>();
            container.RegisterType<IRepository<Product>, ProductRepository>();
            container.RegisterType<IOrderService, OrderService>();
            container.RegisterType<IProductService, ProductService>();
            
            _container = container;
        }

        
    }
}
