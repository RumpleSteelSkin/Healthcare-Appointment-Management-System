namespace HAMS.Application.Services.JwtServices;

public class AccessTokenDto
{
    public string? Token { get; set; }
    public DateTime TokenExpiration { get; set; }
}