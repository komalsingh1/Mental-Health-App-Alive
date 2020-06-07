using System.Collections.Generic;

namespace Mental.Health.Adapter
{
    public class AnalyzingQuestion
    {
        public string QuestionId { get; set; }
        public string Question { get; set; }
        public List<Choice> Options { get; set; }
    }
}
