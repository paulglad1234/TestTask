using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFirstWebApplication.Services
{
    public interface IFileWorker
    {
        void AddToEnd(string filename, int value);
        int GetSum(string filename, int from, int till);
    }
}
