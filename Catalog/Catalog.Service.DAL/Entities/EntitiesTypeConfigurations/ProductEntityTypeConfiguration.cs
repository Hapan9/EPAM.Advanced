using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Web;

namespace Catalog.Service.DAL.Entities.EntitiesTypeConfigurations
{
    internal class ProductEntityTypeConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");

            builder.HasKey(e => e.Id)
                .HasName("PK_Products")
                .IsClustered();

            builder.Property(e => e.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(e => e.Description)
                .HasConversion(v => HttpUtility.HtmlEncode(v), v => HttpUtility.HtmlDecode(v))
                .IsRequired(false);

            builder.Property(e => e.PhotoUrl)
                .HasConversion(v => v.ToString(), v => new Uri(v))
                .IsRequired(false);

            builder.Property(e => e.Price)
                .HasColumnType("money")
                .IsRequired();

            builder.Property(e => e.Amount)
                .IsRequired();

            builder.HasOne(e => e.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(e => e.CategoryId)
                .HasConstraintName("FK_Products_Categories");
        }
    }
}
