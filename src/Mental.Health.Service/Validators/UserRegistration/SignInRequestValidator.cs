using FluentValidation;
using Mental.Health.Model.Models.Error;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mental.Health.Service
{
    public class SignInRequestValidator: AbstractValidator<SignInRequest>
    {
        public SignInRequestValidator()
        {
            RuleFor(x => x.UserID)
            .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MissingField)
                .WithMessage(ErrorMessages.MissingField("UserID"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("UserID"));
            RuleFor(x => x.Password)
            .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MissingField)
                .WithMessage(ErrorMessages.MissingField("Password"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("Password"))
                .Must(x => x.Length >= 6)
                .WithErrorCode(FaultCodes.PasswordTooShort)
                .WithMessage(FaultMessages.PasswordTooShort); 
        }
    }
}
