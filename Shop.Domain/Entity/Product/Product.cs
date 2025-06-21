using Shop.Domain.Entity.Common;

namespace Shop.Domain.Entity.Product;

public class Product : BaseModel
{
    public int CategoryId { get; set; }
    public required Category Category { get; set; }
    public required string Name { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public string? ShortDescription { get; set; } 
}