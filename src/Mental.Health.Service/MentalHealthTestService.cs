using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Mental.Health.Service
{
    public class MentalHealthTestService : IMentalHealthTestService
    {
        private readonly IMentalHealthTestComponent _mentalHealthComponent;
        public MentalHealthTestService(IMentalHealthTestComponent mentalHealthComponent)
        {
            _mentalHealthComponent = mentalHealthComponent;
        }
        public async Task<QuestionResponse> GetQuestion(QuestionRequest request)
        {
            Validations.EnsureValid(request, new QuestionRequestValidator());
            var question = await _mentalHealthComponent.GetQuestion(request.ToQuestion());
            return question.ToQuestionResponse();
        }

        public async Task<ResultResponse> GetResult(ResultRequest request, string testId)
        {
            Validations.EnsureValid(request, new ResultRequestValidator());
            var result = await _mentalHealthComponent.GetResult(request.ToResult(testId));
            return result.ToResultResponse();
        }

        public async Task<AnswerResponse> SaveAnswer(AnswerRequest request, string testId)
        {
            Validations.EnsureValid(request, new AnswerRequestValidator());
            if (await _mentalHealthComponent.SaveResponse(request.ToAnswer(testId)))
                return new AnswerResponse() { IsSubmissionSuccessful = true };
            return new AnswerResponse() { IsSubmissionSuccessful = false };
        }
    }
}
