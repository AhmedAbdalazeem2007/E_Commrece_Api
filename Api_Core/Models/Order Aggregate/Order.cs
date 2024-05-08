
namespace Api_Core.Models.Order_Aggregate
{
    public class Order : BaseEntity
    {
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; } = DateTimeOffset.Now;
        public OrderStatus Status { get; set; } = OrderStatus.Pending;
        public Address ShippingAddress { get; set; }
        public DelivaryMathod DelivaryMathod { get; set; }
        public ICollection<OrderItem> Items { get; set; } = new HashSet<OrderItem>();
        public decimal Subtotal { get; set; }
        [NotMapped]
        public decimal Total => Subtotal + DelivaryMathod.Cost;
        public decimal GetTotal() => Subtotal + DelivaryMathod.Cost;
        public string PaymentIntentId { get; set; } = string.Empty;
        public Order()
        {
            

        }
        public Order(string buyerEmail, Address shippingAddress, DelivaryMathod delivaryMathod, ICollection<OrderItem> items, decimal subtotal)
        {
            BuyerEmail = buyerEmail;
            ShippingAddress = shippingAddress;
            DelivaryMathod = delivaryMathod;
            Items = items;
            Subtotal = subtotal;
        }
    }
}
