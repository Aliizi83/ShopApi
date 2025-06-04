using Microsoft.EntityFrameworkCore;

namespace Shop.Infrastructure.Persistence.Interface;

public interface ISeeder<in TContext> where TContext : DbContext
{
    public abstract void Seed(TContext dbContext);
}