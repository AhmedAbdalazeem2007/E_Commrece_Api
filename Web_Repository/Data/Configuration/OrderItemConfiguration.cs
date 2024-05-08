

using Api_Core.Models.Order_Aggregate;

namespace Web_Repository.Data.Configuration
{
    public class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.OwnsOne(o => o.Product, x => x.WithOwner());
            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)");

        }
    }
}
