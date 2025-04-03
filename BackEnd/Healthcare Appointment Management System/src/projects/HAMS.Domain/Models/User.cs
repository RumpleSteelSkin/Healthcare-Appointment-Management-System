using Microsoft.AspNetCore.Identity;

namespace HAMS.Domain.Models;

public class User : IdentityUser<Guid>
{
    public required string? FirstName { get; set; }
    public required string? LastName { get; set; }
}