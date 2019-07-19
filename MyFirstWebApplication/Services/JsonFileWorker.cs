using System.IO;
using MyFirstWebApplication.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyFirstWebApplication.Services
{
    public class JsonFileWorker : IFileWorker
    {
        public void AddToEnd(string filename, int value)
        {
            using (var streamWriter = new StreamWriter(filename, true))
            {
                streamWriter.WriteLine(JsonConvert.SerializeObject(new JsonRecord(value))+",");
            }
        }

        public int GetSum(string filename, int from, int till)
        {
            var json = JObject.Parse("{\"objects\":["+File.ReadAllText(filename)+"]}");
            var fromIndex = FindFromIndex(from, json);
            var tillIndex = FindTillIndex(till, json);
            if (fromIndex == -1 || tillIndex == -1)
                return 0;
            var result = 0;
            for (var i = fromIndex; i <= tillIndex; i++)
            {
                result += (int)json["objects"][i]["Value"];
            }

            return result;
        }

        private static int FindFromIndex(int from, JObject json)
        {
            if ((int)json["objects"][0]["Time"] >= from)
                return 0;
            for (var i = 1; i < ((JArray)json["objects"]).Count; i++)
            {
                if ((int)json["objects"][i - 1]["Time"] < from && from <= (int)json["objects"][i]["Time"])
                    return i;
            }

            return -1;
        }

        private static int FindTillIndex(int till, JObject json)
        {
            var lastIndex = ((JArray) json["objects"]).Count - 1;
            if (lastIndex != 0)
                if ((int)json["objects"][lastIndex]["Time"] <= till)
                    return lastIndex;
            for (var i = 0; i < lastIndex; i++)
            {
                if ((int)json["objects"][i]["Time"] <= till && till < (int)json["objects"][i + 1]["Time"])
                    return i;
            }

            return -1;
        }
    }
}
