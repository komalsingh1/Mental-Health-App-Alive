using System.Threading.Tasks;

namespace Mental.Health.Service
{
    public interface IMentalHealthTestService
    {
        Task<QuestionResponse> GetQuestion(QuestionRequest request);
        Task<AnswerResponse> SaveAnswer(AnswerRequest request,string testid);
        Task<ResultResponse> GetResult(ResultRequest request,string testId);
    }
}
