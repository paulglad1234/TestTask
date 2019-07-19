using System;

namespace MyFirstWebApplication.Models
{
    public class JsonRecord
    {
        public int Value { get; }
        public int Time { get; }

        public JsonRecord(int value)
        {
            Value = value;
            var now = DateTime.Now;
            Time = now.Hour * 3600 + now.Minute * 60 + now.Second;
        }
    }
}
