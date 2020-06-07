using System;
using System.Collections.Generic;
using System.Linq;

namespace Mental.Health.Adapter
{
    public class ResultContentsManager : IResultContentsManager
    {
        private static object _lockObj;
        private static List<ResultContent> _anxietyResults;
        private static List<ResultContent> _depressionResults;
        private static List<ResultContent> _stressResults;
        public ResultContentsManager()
        {
            _anxietyResults = GetResultsFromFile(GetPath(TestType.Anxiety));
            _depressionResults = GetResultsFromFile(GetPath(TestType.Depression));
            _stressResults = GetResultsFromFile(GetPath(TestType.Stress));
            _lockObj = new object();
        }

        public bool AddResultContent(TestType test, ResultContent result)
        {
            if (result?.Score == null || result?.Summary == null)
                return false;
            var results = GetAllResultContents(test);
            var filePath = GetPath(test);
            var existingResult = results.Where(r => r.Score == result.Score).FirstOrDefault();
            if (existingResult != null)
                return false;
            lock (_lockObj)
            {
                results.Add(result);
            }
            return JsonFileHandler.WriteInFile(results, filePath);
        }

        private string GetPath(TestType test)
        {
            var path = default(string);
            switch (test)
            {
                case TestType.Anxiety:
                    path = KeyStore.FilePaths.Results.Anxiety;
                    break;
                case TestType.Depression:
                    path = KeyStore.FilePaths.Results.Depression;
                    break;
                case TestType.Stress:
                    path = KeyStore.FilePaths.Results.Stress;
                    break;
            }
            return path;
        }

        public bool DeleteResultContent(TestType test, ResultContent result)
        {
            if (result?.Score == null || result?.Summary == null)
                return false;
            var results = GetAllResultContents(test);
            var filePath = GetPath(test);
            var existingResult = results.Where(r => r.Score == result.Score).FirstOrDefault();
            if (existingResult == null)
                return true;
            lock (_lockObj)
            {
                try
                {
                    results.Remove(existingResult);
                }
                catch { }
            }
            return JsonFileHandler.WriteInFile(results, filePath);
        }

        public bool DeleteResultContentByScore(TestType test, int score)
        {
            var results = GetAllResultContents(test);
            var filePath = GetPath(test);
            var existingResult = results.Where(r => r.Score == score).FirstOrDefault();
            if (existingResult == null)
                return true;
            lock (_lockObj)
            {
                try
                {
                    results.Remove(existingResult);
                }
                catch { }
            }
            return JsonFileHandler.WriteInFile(results, filePath);
        }

        public List<ResultContent> GetAllResultContents(TestType test)
        {
            var results = new List<ResultContent>();
            switch (test)
            {
                case TestType.Anxiety:
                    results = _anxietyResults;
                    break;
                case TestType.Depression:
                    results = _depressionResults;
                    break;
                case TestType.Stress:
                    results = _stressResults;
                    break;
            }
            return results;
        }

        public ResultContent GetResultContentByScore(TestType test, int score)
        {
            var results = GetAllResultContents(test);
            var filePath = GetPath(test);
            var existingResult = results.Where(r => r.Score == score).FirstOrDefault();
            return existingResult;
        }

        public bool UpdateResultContent(TestType test, ResultContent result)
        {
            if (result?.Score == null || result?.Summary == null)
                return false;
            var results = GetAllResultContents(test);
            var filePath = GetPath(test);
            lock (_lockObj)
            {
                var existingResult = results.Where(r => r.Score == result.Score).FirstOrDefault();
                if (existingResult == null)
                    return AddResultContent(test, result);
                else
                {
                    existingResult.ImageUrl = result.ImageUrl;
                    existingResult.Description = result.Description;
                    existingResult.Summary = result.Summary;
                    return JsonFileHandler.WriteInFile(results, filePath);
                }
            }
        }

        private List<ResultContent> GetResultsFromFile(string path)
        {
            try
            {
                return JsonFileHandler.ReadFile<ResultContent>(path) ?? new List<ResultContent>();
            }
            catch
            {
                return new List<ResultContent>();
            }
        }

       
    }
}
