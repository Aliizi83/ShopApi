using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Shop.Domain.Entity.Product;

namespace Shop.Infrastructure.Persistence.Configuration.Product;

public class ProductCategoryConfiguration : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
        builder.HasOne(c => c.Parent).
            WithMany(c => c.Children).
            HasForeignKey(c => c.ParentId).
            OnDelete(DeleteBehavior.Restrict);
    }
}