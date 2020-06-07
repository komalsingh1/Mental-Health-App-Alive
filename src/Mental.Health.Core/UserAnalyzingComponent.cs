using System;
using System.Threading.Tasks;

namespace Mental.Health.Core
{
    public class UserAnalyzingComponent : IUserAnalyzingComponent
    {
        private readonly IUserAnalyzingAdapter _userAnalyzingAdapter;
        public UserAnalyzingComponent(IUserAnalyzingAdapter userAnalyzingAdapter)
        {
            _userAnalyzingAdapter = userAnalyzingAdapter;
        }
        public async Task<AnalyzingQuestion> GetQuestion(string questionId)
        {
            return await _userAnalyzingAdapter.GetQuestion(questionId);
        }

        public async Task<bool> SaveResponse(AnalyzingAnswer answer)
        {
            if (!await _userAnalyzingAdapter.IsValidUser(answer.UserId))
                throw ClientSideExceptions.InvalidUser();
            return await _userAnalyzingAdapter.SaveAnalyzation(answer.UserId, $"{answer.QuestionId}.{answer.ChosenOption}");
        }
    }
}
