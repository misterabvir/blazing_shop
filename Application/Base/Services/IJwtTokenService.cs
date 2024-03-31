using Domain.Users;

namespace Application.Base.Services;

public interface IJwtTokenService
{
    string GetJwtToken(User user);
}
