using FluentValidation;
using Mental.Health.Model.Models.Error;

namespace Mental.Health.Service.Analyzer
{
    public class QuestionRequestValidator : AbstractValidator<Analyzer.QuestionRequest>
    {
        public QuestionRequestValidator()
        {
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
        }
        private bool IsValidQuestionId(string id)
        {
            return true;
        }
    }
}
