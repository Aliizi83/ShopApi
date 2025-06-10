using Microsoft.AspNetCore.Identity;
using Shop.Domain.Entity.Users;
using Shop.Infrastructure.Persistence.Interface;

namespace Shop.Infrastructure.Persistence;

public class UserSeeder : ISeeder<ShopDbContext>
{
    private readonly PasswordHasher<User> _passwordHasher = new PasswordHasher<User>();

    public void Seed(ShopDbContext dbContext)
    {
        if (!dbContext.Users.Any(u => u.Email == "aliizi1383@gmail.com"))
        {
            var user = new User
            {
                FirstName = "Ali",
                LastName = "Izi",
                Email = "aliizi1383@gmail.com",
                Username = "Aliizi",
                PhoneNumber = "09193264200",
                IsActive = true,
                PasswordHash = null,
            };
            user.PasswordHash = _passwordHasher.HashPassword(user, "Ali@123456");

            dbContext.Users.AddRange(
                user
            );
        }
    }
}