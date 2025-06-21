using Shop.Domain.Entity.Common;

namespace Shop.Domain.Entity.Product;

public class Category : BaseModel
{
    public required string Name { get; set; }
    public required string Title { get; set; }
    public int? ParentId { get; set; }
    public Category? Parent { get; set; }
    public ICollection<Category>? Children { get; set; }
    public ICollection<Product>? Products { get; set; }
}