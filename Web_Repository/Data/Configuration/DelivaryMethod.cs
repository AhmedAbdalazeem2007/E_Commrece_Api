
using Api_Core.Models.Order_Aggregate;

namespace Web_Repository.Data.Configuration
{
    public class DelivaryMethodConfig : IEntityTypeConfiguration<DelivaryMathod>
    {
        public void Configure(EntityTypeBuilder<DelivaryMathod> builder)
        {
            builder.Property(p => p.Cost)
                .HasColumnType("decimal(18,2)");

        }
    }
}
