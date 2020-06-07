using Mental.Health.Service.Analyze;
using System.Threading.Tasks;

namespace Mental.Health.Service
{
    public class UserAnalyzingService : IUserAnalyzingService
    {
        private readonly IUserAnalyzingComponent _userAnalyzingComponent;
        public UserAnalyzingService(IUserAnalyzingComponent userAnalyzingComponent)
        {
            _userAnalyzingComponent = userAnalyzingComponent;
        }
        public async Task<QuestionResponse> GetQuestion(Analyzer.QuestionRequest request)
        {
            Validations.EnsureValid(request, new Analyzer.QuestionRequestValidator());
            var question = await _userAnalyzingComponent.GetQuestion(request.QuestionId);
            return question.ToQuestionResponse();
        }

        public async Task<AnswerResponse> SaveAnswer(Analyzer.AnswerRequest request)
        {
            Validations.EnsureValid(request, new Analyzer.AnswerRequestValidator());
            if (await _userAnalyzingComponent.SaveResponse(request.ToAnswer()))
                return new AnswerResponse() { IsSubmissionSuccessful = true };
            return new AnswerResponse() { IsSubmissionSuccessful = false };
        }
    }
}
