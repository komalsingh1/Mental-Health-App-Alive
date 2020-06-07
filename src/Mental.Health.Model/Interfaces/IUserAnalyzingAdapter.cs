using System.Threading.Tasks;

namespace Mental.Health
{
    public interface IUserAnalyzingAdapter
    {
        Task<AnalyzingQuestion> GetQuestion(string questionId);
        Task<bool> IsValidUser(string userId);
        Task<bool> SaveAnalyzation(string userId, string analyzedValue);
    }
}
