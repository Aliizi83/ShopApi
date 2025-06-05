using Shop.Domain.Repository.User;
using userModel = Shop.Domain.Entity.Users;

namespace Shop.Infrastructure.Repository.Postgres.User;

public class PostgresUserRepository(ShopDbContext shopDbContext) : IUserRepository
{
    private readonly ShopDbContext _shopDbContext = shopDbContext;

    public userModel.User? GetUserByIdentifier(string identifier)
    {
        return _shopDbContext.Users
            .FirstOrDefault(u =>
                u.Email == identifier ||
                u.Username == identifier ||
                u.PhoneNumber == identifier
            );
    }
}