using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mental.Health
{
    public interface IMentalHealthTestAdapter
    {
        Task<Question> GetQuestion(string testType, int questionId);
        Task<int> GetScoreOfOption(string testType, int questionNumber, int chosenOption);
        Task<bool> AddScoreToCache(string testType, string userId, string testId, int questionNumber, int score);
        Task<Report> GetReport(string userId, string testType, string testId);
        Task<bool> IsValidUser(string userId);
        Task<Dictionary<int,int>> GetScoresFromCache(string userId, string testType, string testId);
        Task<bool> SaveResult(Report result);
        Task RemoveScoresFromCache(string userId, string testType, string testId);
        Task<Report> MapScoreWithDescription(Report report);
    }
}
