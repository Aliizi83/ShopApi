using Shop.Domain.Entity.Common;

namespace Shop.Domain.Entity.Product;

public class ProductCategory : BaseModel
{
    public required string Name { get; set; }
    public required string Title { get; set; }
    public int? ParentId { get; set; }
    public ProductCategory? Parent { get; set; }
    public ICollection<ProductCategory>? Children { get; set; }
}