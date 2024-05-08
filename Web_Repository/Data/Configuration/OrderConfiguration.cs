


using Api_Core.Models.Order_Aggregate;

namespace Web_Repository.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Api_Core.Models.Order_Aggregate.Order>
    {
        public void Configure(EntityTypeBuilder<Api_Core.Models.Order_Aggregate.Order> builder)
        {
            builder.OwnsOne(o => o.ShippingAddress, x => x.WithOwner());
            builder.Property(p => p.Status)
                .HasConversion(
                o => o.ToString(),
               o => (OrderStatus)Enum.Parse(typeof(OrderStatus), o)
                );
            builder.Property(p => p.Subtotal)
                .HasColumnType("decimal(18,2)");
        }

        
    }
}
