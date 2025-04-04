﻿using FluentValidation;
using HAMS.Application.Constants;

namespace HAMS.Application.Features.Authentication.Commands.Login;

public class LoginValidator : AbstractValidator<LoginCommand>
{
    public LoginValidator()
    {
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password field cannot be empty.")
            .MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
            .MaximumLength(512).WithMessage("Password can be a maximum of 512 characters.")
            .Matches(RegexPatterns.Password)
            .WithMessage(
                "Password must contain at least one uppercase letter, one lowercase letter, one digit, and one special character (including '.'), and must be at least 8 characters long.");
    }
}