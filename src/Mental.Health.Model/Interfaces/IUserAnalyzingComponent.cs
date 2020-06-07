using System.Threading.Tasks;

namespace Mental.Health
{
    public interface IUserAnalyzingComponent
    {
        Task<AnalyzingQuestion> GetQuestion(string questionId);
        Task<bool> SaveResponse(AnalyzingAnswer answer);
    }
}
