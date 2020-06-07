using System.Collections.Generic;

namespace Mental.Health.Adapter
{
    public static class RunningTestsCache
    {
        internal static Dictionary<TestType, Dictionary<(string UserId, string TestId), Dictionary<int, int>>> TestType_UserTest_Choices = null; 
        public static void SetUp()
        {
            if (TestType_UserTest_Choices != null)
                return;
            TestType_UserTest_Choices = new Dictionary<TestType, Dictionary<(string UserId, string TestId), Dictionary<int, int>>>();
            TestType_UserTest_Choices.Add(TestType.Anxiety, new Dictionary<(string UserId, string TestId), Dictionary<int, int>>());
            TestType_UserTest_Choices.Add(TestType.Depression, new Dictionary<(string UserId, string TestId), Dictionary<int, int>>());
            TestType_UserTest_Choices.Add(TestType.Stress, new Dictionary<(string UserId, string TestId), Dictionary<int, int>>());
        }
    }
}
