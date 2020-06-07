using FluentValidation;
using Mental.Health.Model.Models.Error;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Mental.Health.Service
{
    public class SignupRequestValidator : AbstractValidator<SignUpRequest>
    {
        private Regex pinCodePattern = new Regex(@"^[1-9][0-9]{5}$");
        private Regex mobileNoPattern = new Regex(@"^[6-9]\d{9}$");
        private Regex emailPattern = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

        public SignupRequestValidator()
        {
            RuleFor(x => x.Name)
           .Cascade(CascadeMode.StopOnFirstFailure)
               .NotNull()
               .WithErrorCode(FaultCodes.MissingField)
               .WithMessage(ErrorMessages.MissingField("Name"))
               .NotEmpty()
               .WithErrorCode(FaultCodes.InvalidField)
               .WithMessage(ErrorMessages.InvalidField("Name"));

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


            RuleFor(x => x.EmailID)
           .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MissingField)
                .WithMessage(ErrorMessages.MissingField("EmailID"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("EmailID"))
                .Must(IsValidEmailId)
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("EmailID"));

            RuleFor(x => x.Age)
            .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(x => x > 0)
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("Age"));

            RuleFor(x => x.Gender)
            .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MissingField)
                .WithMessage(ErrorMessages.MissingField("Gender"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("Gender"));

            RuleFor(x => x.Country)
            .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MissingField)
                .WithMessage(ErrorMessages.MissingField("Country"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("Country"));

            RuleFor(x => x.Pincode.ToString())
                .Must(IsValidPincode)
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("Pincode"));

            RuleFor(x => x.PhoneNumber.ToString())
                .Must(IsValidMobileNumber)
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("PhoneNumber"));

        }
        private bool IsValidPincode(string pincode)
        {
            return pinCodePattern.IsMatch(pincode) && (pincode.Length == 6);
        }
        private bool IsValidMobileNumber(string PhoneNum)
        {
            return mobileNoPattern.IsMatch(PhoneNum) && (PhoneNum.Length==10);
        }
        private bool IsValidEmailId(string Email)
        {
            return emailPattern.IsMatch(Email);
        }
    }
}
