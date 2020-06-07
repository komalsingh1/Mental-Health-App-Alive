using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Newtonsoft.Json;
namespace Mental.Health.Adapter
{
    internal class JsonFileHandler
    {
        internal static List<T> ReadFile<T>(string path)
        {
            List<T> ts = new List<T>();
            try
            {
                var json = ReadAllText(path);
                ts = JsonConvert.DeserializeObject<List<T>>(json);
            }
            catch(Exception ex)
            {
                throw ServerSideExceptions.JsonReadingFailure();
            }
            return ts;
        }
        internal static bool WriteInFile<T>(List<T> ts,string path)
        {
            try
            {
                var json = JsonConvert.SerializeObject(ts,Formatting.Indented);
                return Write(path, json);
            }
            catch { return false; }
        }
        private static string ReadAllText(string path)
        {
            using (StreamReader r = new StreamReader(path))
            {
                var content = r.ReadToEnd();
                return content;
            }
        }
        private static bool Write(string path, string content)
        {
            File.WriteAllText(path, content);
            return true;
        }
    }
}
