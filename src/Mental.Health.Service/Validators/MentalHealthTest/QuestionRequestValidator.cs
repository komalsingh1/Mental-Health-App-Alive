using System;
using FluentValidation;
using Mental.Health.Model.Models.Error;

namespace Mental.Health.Service
{
    public class QuestionRequestValidator : AbstractValidator<QuestionRequest>
    {
        public QuestionRequestValidator()
        {
            RuleFor(x => x.TestType)
            .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(FaultCodes.MissingField)
                .WithMessage(ErrorMessages.MissingField("TestType"))
                .NotEmpty()
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("TestType"));
            RuleFor(x => x.QuestionNumber)
                .Must(IsValidQuestionNumber)
                .WithErrorCode(FaultCodes.InvalidField)
                .WithMessage(ErrorMessages.InvalidField("QuestionNumber"));
        }

        private bool IsValidQuestionNumber(int questionNumber)
        {
            if (questionNumber <= 0)
                return false;
            return true;
        }
    }
}
