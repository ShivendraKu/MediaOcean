using System;
using System.Collections.Generic;
using System.Linq;

namespace CheckoutCounter.Db
{
    public class ProductRepository : IRepository<Product>
    {
        private Dictionary<int, Product> inMemoryProductCollection = new Dictionary<int, Product>();

        public void Delete(Product prod)
        {
            if (!inMemoryProductCollection.ContainsKey(prod.Id))
                throw new Exception("101: Product Not Found in db");

            inMemoryProductCollection.Remove(prod.Id);
        }

        public List<Product> GetAll()
        {
            var productArray = inMemoryProductCollection.Values.ToList();
            return productArray;
        }

        public Product GetById(int id)
        {
            if (!inMemoryProductCollection.ContainsKey(id))
                throw new Exception("101: Product Not Found in db");

            var prod = inMemoryProductCollection[id];
            return prod;
        }

        public int Insert(Product prod)
        {
            var nextId = inMemoryProductCollection.Count + 1;
            inMemoryProductCollection.Add(nextId, prod);
            return nextId;
        }

        public int Update(Product prod)
        {
            if (!inMemoryProductCollection.ContainsKey(prod.Id))
                throw new Exception("101: Product Not Found in db");

            inMemoryProductCollection[prod.Id] = prod;
            return prod.Id;
        }
    }
}
