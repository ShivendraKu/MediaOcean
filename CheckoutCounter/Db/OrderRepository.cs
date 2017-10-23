using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutCounter.Db
{
    public class OrderRepository : IRepository<Order>
    {
        private Dictionary<int, Order> inMemoryOrderCollection = new Dictionary<int, Order>();

        public void Delete(Order order)
        {
            if (!inMemoryOrderCollection.ContainsKey(order.Id))
                throw new Exception("101: Order Not Found in db");

            inMemoryOrderCollection.Remove(order.Id);
        }

        public List<Order> GetAll()
        {
            var orderArray = inMemoryOrderCollection.Values.ToList();
            return orderArray;
        }

        public Order GetById(int id)
        {
            if (!inMemoryOrderCollection.ContainsKey(id))
                throw new Exception("101: Order Not Found in db");

            var order = inMemoryOrderCollection[id];
            return order;
        }

        public int Insert(Order order)
        {
            var nextId = inMemoryOrderCollection.Count + 1;
            inMemoryOrderCollection.Add(nextId, order);
            return nextId;
        }

        public int Update(Order order)
        {
            if (!inMemoryOrderCollection.ContainsKey(order.Id))
                throw new Exception("101: Order Not Found in db");

            inMemoryOrderCollection[order.Id] = order;
            return order.Id;
        }
    }
}
