using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Shop.Application.DTOs.Auth;
using Shop.Application.Interfaces.Auth;
using Shop.Domain.Entity.Users;
using Shop.Domain.Repository.User;

namespace Shop.Infrastructure.Services.Auth;

public class LoginService(IUserRepository userRepository, IConfiguration configuration) : ILoginService
{
    private readonly IUserRepository _userRepository = userRepository;
    private readonly IConfiguration _configuration = configuration;
    private readonly PasswordHasher<string> _passwordHasher = new();


    public string Login(LoginRequest request)
    {
        var user = _userRepository.GetUserByIdentifier(request.Identifier);
        if (user == null)
            throw new UnauthorizedAccessException("Invalid username, email or phone number");
        
        var passwordVerificationResult = _passwordHasher.VerifyHashedPassword(user.Id.ToString(), user.PasswordHash ?? throw new InvalidOperationException(), request.Password);
        if (passwordVerificationResult == PasswordVerificationResult.Failed)
        {
            throw new UnauthorizedAccessException("Invalid password");
        }
        
        return GenerateJwtToken(user);
    }

    private string GenerateJwtToken(User user)
    {
        
        var tokenLifetimeInMinutes = int.Parse(_configuration["Jwt:TokenLifetimeInMinutes"] ?? throw new InvalidOperationException(message: "token lifetime not set"));
        var secretKey = _configuration["Jwt:SecretKey"];
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey ?? throw new InvalidOperationException(message: "no jwt token has been set")));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.Username),
            new Claim(ClaimTypes.Email, user.Email),
        };
        
        var tokenDescriptor = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(tokenLifetimeInMinutes),
            signingCredentials: creds
        );
        
        return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);
    }

    
}