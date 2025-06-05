namespace Shop.Domain.Repository.User;

using Entity.Users;

public interface IUserRepository
{
    User? GetUserByIdentifier(string identifier);
}