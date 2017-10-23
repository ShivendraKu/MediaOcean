using CheckoutCounter.Db;
using System;
using System.Collections.Generic;

namespace CheckoutCounter.BLL
{
    public class OrderService: IOrderService
    {
        private IRepository<Order> _orderRepository;
        private ITaxService _taxService;
        public OrderService(ITaxService taxService,IRepository<Order> orderRepository)
        {
            _taxService = taxService;
            _orderRepository = orderRepository;
        }
        public Order CreateNewOrder()
        {
            var order = new Order();
            order.OrderDetails = new List<OrderDetail>();
            order.OrderDate = DateTime.Now;
            return order;
        }

        public Order GetOrderById(int id)
        {
            var order = _orderRepository.GetById(id);
            return order;
        }

        public void SaveOrder(Order order)
        {
            if (order.Id == 0)
                order.Id = _orderRepository.Insert(order);
            else
                _orderRepository.Update(order);
        }

        //TODO: Improve the logic to update the quantity of existing product.
        public void AddProductToOrder(Order order, Product product, int quantity)
        {
            var orderDetail = new OrderDetail()
            {
                ItemId = product.Id,
                OrderId = order.Id,
                Quantity = quantity,
                UnitPrice = product.Price,
                Item = product,
                Order = order,
                Total = quantity * product.Price
            };

            var tax = _taxService.CalculateTaxOnProduct(product, quantity);
            orderDetail.Tax = tax;
            order.SumTotal += (product.Price * quantity);
            order.TaxTotal += tax;
            order.Total = (order.SumTotal - order.TaxTotal);
            order.OrderDetails.Add(orderDetail);
        }

        public void RemoveProductFromOrder(Order order, Product product, int quantity)
        {
            // Left for future. Was not needed for this test trial.
        }
    }
}
