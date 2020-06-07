using FluentValidation;
using Mental.Health.Model.Models.Error;

namespace Mental.Health.Service
{
    public class ResultRequestValidator : AbstractValidator<ResultRequest>
    {
        public ResultRequestValidator()
        {
            RuleFor(x => x.UserId)
            .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MissingField)
                .WithMessage(ErrorMessages.MissingField("UserId"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("UserId"));

            RuleFor(x => x.TestType)
            .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MissingField)
                .WithMessage(ErrorMessages.MissingField("TestType"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("TestType"));
        }
    }
}
