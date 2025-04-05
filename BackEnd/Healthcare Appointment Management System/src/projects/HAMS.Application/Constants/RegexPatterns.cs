namespace HAMS.Application.Constants;

public static class RegexPatterns
{
    public const string NameWithSpaces = @"^[a-zA-ZğüÜöÖşŞİıçÇ]+(?: [a-zA-ZğüÜöÖşŞİıçÇ]+)*$";
    public const string Password = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*\.])[A-Za-z\d!@#$%^&*\.]{8,}$";
    public const string UserName = "^[a-zA-Z0-9]*$";
}