using System;
using System.Threading.Tasks;

namespace Mental.Health.Adapter
{
    public class UserAnalyzingAdapter : IUserAnalyzingAdapter
    {
        private IUsersManager _usersManager;
        private IQuestionsManager _questionsManager;
        public UserAnalyzingAdapter(IUsersManager usersManager,IQuestionsManager questionsManager)
        {
            _questionsManager = questionsManager;
            _usersManager = usersManager;
        }
        public Task<Health.AnalyzingQuestion> GetQuestion(string questionId)
        {
            var question = _questionsManager.GetQuestionById(questionId);
            return Task.FromResult(question.ToAnalyzingQuestionCore());
        }

        public Task<bool> IsValidUser(string userId)
        {
            return Task.FromResult(_usersManager.IsValidUserId(userId));
        }

        public Task<bool> SaveAnalyzation(string userId, string analyzedValue)
        {
            return Task.FromResult(_usersManager.SaveAnalyzedValue(userId, analyzedValue)); 
        }
    }
}
