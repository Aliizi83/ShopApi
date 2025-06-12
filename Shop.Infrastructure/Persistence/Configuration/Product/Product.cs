using Shop.Domain.Entity.Common;

namespace Shop.Infrastructure.Persistence.Configuration.Product;

public class Product : BaseModel
{
    public required string Name { get; set; }
    public required string Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
}