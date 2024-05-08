

namespace Web_Repository.Context.Configuration
{
    public class CategoryConfig:IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");
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

            /*          builder.HasMany()
                          .WithOne(p => p.Category)
                          .HasForeignKey(p => p.ProductTypeId)
              .OnDelete(DeleteBehavior.Cascade);*/

        }
    }
}
