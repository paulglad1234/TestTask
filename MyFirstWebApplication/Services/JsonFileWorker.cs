using System.IO;
using MyFirstWebApplication.Models;
using Newtonsoft.Json;

namespace MyFirstWebApplication.Services
{
    public class JsonFileWorker : IFileWorker
    {
        private JsonRecord _record;
        public void AddToEnd(string filename, int value)
        {
            if (_record == null)
                _record = new JsonRecord(filename);
            _record.Add(value);
            using (var streamWriter = new StreamWriter(filename))
            {
                streamWriter.Write(JsonConvert.SerializeObject(_record));
            }
        }

        public int GetSum(string filename, int from, int till)
        {
            if (_record == null)
                _record = new JsonRecord(filename);
            var fromIndex = FindFromIndex(from);
            var tillIndex = FindTillIndex(till);
            if (fromIndex == -1 || tillIndex == -1)
                return 0;
            var result = 0;
            for (var i = fromIndex; i <= tillIndex; i++)
            {
                result += _record.Value[i];
            }

            return result;
        }

        private int FindFromIndex(int from)
        {
            if (_record.Time[0] >= from)
                return 0;
            for (var i = 1; i < _record.Time.Count; i++)
            {
                if (_record.Time[i - 1] < from && from <= _record.Time[i])
                    return i;
            }

            return -1;
        }

        private int FindTillIndex(int till)
        {
            if (_record.Time.Count > 0)
                if (_record.Time[_record.Time.Count - 1] <= till)
                    return _record.Time.Count - 1;
            for (var i = 0; i < _record.Time.Count - 1; i++)
            {
                if (_record.Time[i] <= till && till < _record.Time[i + 1])
                    return i;
            }

            return -1;
        }
    }
}
