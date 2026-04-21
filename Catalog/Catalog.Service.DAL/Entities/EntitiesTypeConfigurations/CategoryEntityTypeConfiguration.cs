using Catalog.Service.DAL.Enteties;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Service.DAL.Entities.EntitiesTypeConfigurations
{
    internal class CategoryEntityTypeConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Categories");

            builder.HasKey(c => c.Id)
                .HasName("PK_Categories")
                .IsClustered();

            builder.Property(e => e.PhotoUrl)
                .HasConversion(v => v.ToString(), v => new Uri(v));

            builder
                .HasOne(s => s.Parent)
                .WithMany(m => m.Childrens)
                .HasForeignKey(e => e.ParentId)
                .HasConstraintName("FK_Categories")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
