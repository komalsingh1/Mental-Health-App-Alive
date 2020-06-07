using FluentValidation;
using Mental.Health.Model.Models.Error;

namespace Mental.Health.Service.Analyzer
{
    public class AnswerRequestValidator : AbstractValidator<Analyzer.AnswerRequest>
    {
        public AnswerRequestValidator()
        {
            RuleFor(x => x.UserId)
            .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MissingField)
                .WithMessage(ErrorMessages.MissingField("UserId"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("UserId"));


            RuleFor(x => x.QuestionId)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MissingField)
                .WithMessage(ErrorMessages.MissingField("QuestionId"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("QuestionId"))
                .Must(IsValidQuestionId)
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("QuestionId"));

            RuleFor(x => x.OptionNumber)
                .Must(IsValidOptionNumber)
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("OptionNumber"));
        }

        private bool IsValidOptionNumber(int number)
        {
            if (number <= 0)
                return false;
            return true;
        }
        private bool IsValidQuestionId(string id)
        {
            return true;
        }
    }
}
