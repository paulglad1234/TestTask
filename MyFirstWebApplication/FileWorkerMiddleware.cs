using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using MyFirstWebApplication.Services;

namespace MyFirstWebApplication
{
    public class FileWorkerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IFileWorker _fileWorker;

        public FileWorkerMiddleware(RequestDelegate next, IFileWorker fileWorker)
        {
            _next = next;
            _fileWorker = fileWorker;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            const string filename = "values.json";
            if (context.Request.Query.Count != 0)
            {
                if (context.Request.Method == "POST")
                    await PostHandler(context, filename);
                else
                    await GetHandler(context, filename);
            }
            else await _next.Invoke(context);
        }

        private async Task PostHandler(HttpContext context, string filename)
        {
            await Task.Run(() => { _fileWorker.AddToEnd(filename, int.Parse(context.Request.Query["value"])); });
        }

        private async Task GetHandler(HttpContext context, string filename)
        {
            await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(new {
                sum = _fileWorker.GetSum(filename, int.Parse(context.Request.Query["from"]),
                    int.Parse(context.Request.Query["till"]))}));
        }
    }
}
