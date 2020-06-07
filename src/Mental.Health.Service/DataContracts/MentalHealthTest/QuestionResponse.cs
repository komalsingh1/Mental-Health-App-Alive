using System.Collections.Generic;

namespace Mental.Health.Service
{
    public class QuestionResponse
	{
		public string Question { get; set; }
		public List<Option> Options { get; set; }
	}
}
