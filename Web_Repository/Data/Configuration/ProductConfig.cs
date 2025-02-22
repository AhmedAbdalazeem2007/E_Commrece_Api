﻿

namespace Web_Repository.Context.Configuration
{
    public class ProductConfig:IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
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
            builder.Property(p => p.Description)
    .HasColumnType("varchar")
    .HasMaxLength(255)
    .HasDefaultValue("pp")
    .IsRequired();
            builder.Property(p => p.Price)
                .HasColumnType("decimal(18,2)")
                .IsRequired();
            builder.Property(p => p.PictureUrl)
                  .HasColumnType("varchar")
    .HasMaxLength(255)
    .HasDefaultValue("pp")
    .IsRequired();

            builder.HasOne(p => p.Category)
                .WithMany()
                .HasForeignKey(p => p.ProductTypeId)
    .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(p => p.Brand)
                .WithMany()
                .HasForeignKey(p => p.ProductBrandId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
