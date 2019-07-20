using System;

namespace MyFirstWebApplication.Models
{
    public class JsonRecord
    {
        public int Value { get; }
        public int Time { get; }

        public JsonRecord(int value, int time = -1)
        {
            Value = value;
            Time = time == -1 ? DateTime.Now.Hour * 3600 + DateTime.Now.Minute * 60 + DateTime.Now.Second : time;
        }
    }
}
