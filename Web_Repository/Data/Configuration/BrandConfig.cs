

namespace Web_Repository.Context.Configuration
{
    public class BrandConfig:IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.ToTable("Brands");
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Id)
             .ValueGeneratedOnAdd()
             .IsRequired()
             .UseIdentityColumn(1, 1);
            builder.Property(p => p.Name)
                .HasColumnType("varchar")
                .HasMaxLength(255)
                .HasDefaultValue("pp")
                .IsRequired();

            /*            builder.HasMany()
                            .WithOne(p => p.Brand)
                            .HasForeignKey(p => p.ProductBrandId)
                .OnDelete(DeleteBehavior.Cascade);*/
        }
    }
}
