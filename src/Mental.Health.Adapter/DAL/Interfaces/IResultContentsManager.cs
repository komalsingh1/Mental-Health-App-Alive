using System.Collections.Generic;

namespace Mental.Health.Adapter
{
    public interface IResultContentsManager
    {
        List<ResultContent> GetAllResultContents(TestType test);
        ResultContent GetResultContentByScore(TestType test, int score);
        bool AddResultContent(TestType test, ResultContent result);
        bool DeleteResultContent(TestType test, ResultContent result);
        bool DeleteResultContentByScore(TestType test, int score);
        bool UpdateResultContent(TestType test, ResultContent result);
    }
}
