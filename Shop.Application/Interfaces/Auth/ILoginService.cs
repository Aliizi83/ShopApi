using Shop.Application.DTOs.Auth;

namespace Shop.Application.Interfaces.Auth;

public interface ILoginService
{
    string Login(LoginRequest request);
}