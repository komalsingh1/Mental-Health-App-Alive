using System;
using System.IO;

namespace Mental.Health
{
    public static class KeyStore
    {
        public static class FilePaths
        {
            //to be used while deploying
            //public static readonly string FolderPath = Path.Combine(System.Reflection.Assembly.GetEntryAssembly().Location ,@"..");
            public static readonly string FolderPath = Path.Combine(Environment.CurrentDirectory,@"..", "Mental.Health.Adapter");
            public static class Questions
            {
                public static readonly string Anxiety = FolderPath + "\\DATA\\Questions\\Anxiety.json";
                public static readonly string Depression = FolderPath + "\\DATA\\Questions\\Depression.json";
                public static readonly string Stress = FolderPath + "\\DATA\\Questions\\Stress.json";
                public static readonly string Analyze = FolderPath + "\\DATA\\Questions\\Analyze.json";
            }
            public static class Results
            {
                public static readonly string Anxiety = FolderPath + "\\DATA\\Results\\Anxiety.json";
                public static readonly string Depression = FolderPath + "\\DATA\\Results\\Depression.json";
                public static readonly string Stress = FolderPath + "\\DATA\\Results\\Stress.json";
            }
            public static readonly string Users = FolderPath + "\\DATA\\Users.json";
            public static readonly string UserReports = FolderPath + "\\DATA\\UserReports.json";
        }
    }
}
