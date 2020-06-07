using System;
using System.Collections.Generic;
using System.Text;

namespace Mental.Health
{
    public class Question
    {
        public string TestType { get; set; }
        public int QuestionId { get; set; }
        public string Statement { get; set; }
        public List<Option> Options { get; set; }
    }
}
