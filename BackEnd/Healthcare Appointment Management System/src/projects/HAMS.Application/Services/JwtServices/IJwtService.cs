using HAMS.Domain.Models;

namespace HAMS.Application.Services.JwtServices;

public interface IJwtService
{
    Task<AccessTokenDto> CreateTokenAsync(User user);
}