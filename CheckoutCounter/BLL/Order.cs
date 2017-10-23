using System;
using System.Collections.Generic;

namespace CheckoutCounter
{
    public class Order
    {
        public int Id { get; set; }

        public List<OrderDetail> OrderDetails { get; set; }

        public DateTime OrderDate { get; set; }

        public decimal SumTotal { get; set; }
        public decimal TaxTotal { get; set; }
        public decimal Total { get; set; }

        public PaymentMode PayMode { get; set; }
    }

    public enum PaymentMode
    {
        CreditCard,DebitCard,Cash,DigitalWallet
    }
}
