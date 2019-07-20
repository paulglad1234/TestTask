using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using MyFirstWebApplication.Services;
using Newtonsoft.Json;

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
            var request = RequestBodyConverter.BodyToString(context.Request);

            if (!string.IsNullOrEmpty(request))
            {
                dynamic jsonRequest = JsonConvert.DeserializeObject(request);
                if (context.Request.Method == "POST")
                    await PostHandler(jsonRequest);
                else
                    await GetHandler(context, jsonRequest);
            }
            else await _next.Invoke(context);
        }

        private async Task PostHandler(dynamic request)
        {
            await Task.Run(() => { _fileWorker.AddToEnd((int)request.value); });
        }

        private async Task GetHandler(HttpContext context, dynamic request)
        {
            await context.Response.WriteAsync(JsonConvert.SerializeObject(new {
                sum = _fileWorker.GetSum((int)request.from, (int)request.till)}));
        }
    }
}
