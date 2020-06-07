using System.Threading.Tasks;
namespace Mental.Health.Service
{
    public interface IUserAnalyzingService
    {
        Task<QuestionResponse> GetQuestion(Analyzer.QuestionRequest request);
        Task<AnswerResponse> SaveAnswer(Analyzer.AnswerRequest request);
    }
}
