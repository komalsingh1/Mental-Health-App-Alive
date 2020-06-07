using System.Collections.Generic;

namespace Mental.Health.Adapter
{
    public class UserReport
    {
        public string UserId { get; set; }
        public List<TestResult> AnxietyReport { get; set; }
        public List<TestResult> StressReport { get; set; }
        public List<TestResult> DepressionReport { get; set; }
    }
}
