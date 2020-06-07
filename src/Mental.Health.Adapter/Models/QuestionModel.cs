using System.Collections.Generic;

namespace Mental.Health.Adapter
{
    public class QuestionModel
    {
        public int Number { get; set; }
        public string Question { get; set; }
        public List<Choice> Options { get; set; }
    }
}
