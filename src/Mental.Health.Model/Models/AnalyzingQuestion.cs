using System.Collections.Generic;

namespace Mental.Health
{
    public class AnalyzingQuestion
    {
        public string QuestionId { get; set; }
        public string Statement { get; set; }
        public List<Option> Options { get; set; }
    }
}
