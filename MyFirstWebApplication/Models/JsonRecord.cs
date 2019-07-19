using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MyFirstWebApplication.Models
{
    public class JsonRecord
    {
        public List<int> Value { get; }
        public List<int> Time { get; }

        public JsonRecord(string filename)
        {
            dynamic jsonObject = JsonConvert.DeserializeObject(File.ReadAllText(filename));
            if (jsonObject == null)
            {
                Value = new List<int>();
                Time = new List<int>();
            }
            else
            {
                Value = JArrayToList((JArray) jsonObject.Value);
                Time = JArrayToList((JArray) jsonObject.Time);
            }
        }
        public void Add(int value)
        {
            Value.Add(value);
            var now = DateTime.Now;
            Time.Add(now.Hour * 3600 + now.Minute * 60 + now.Second);
        }

        private static List<int> JArrayToList(JArray arr)
        {
            var list = new List<int>();
            foreach (var item in arr)
            {
                list.Add((int)item);
            }

            return list;
        }
    }
}
