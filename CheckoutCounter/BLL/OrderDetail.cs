namespace CheckoutCounter
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Tax { get; set; }
        public decimal Total { get; set; }

        public virtual Product Item { get; set; }
        public virtual Order Order { get; set; }
    }
}
