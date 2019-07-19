using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using MyFirstWebApplication.Services;
using Microsoft.AspNetCore.Http.Internal;
using System.IO;
using Newtonsoft.Json.Linq;

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

            var request = ReadBodyAsString(context.Request);

            if (request != string.Empty)
            {
                var jsonRequest = JObject.Parse(request);
                if (context.Request.Method == "POST")
                    await PostHandler(jsonRequest, filename);
                else
                    await GetHandler(context, jsonRequest, filename);
            }
            else await _next.Invoke(context);
        }

        private async Task PostHandler(JObject request, string filename)
        {
            await Task.Run(() => { _fileWorker.AddToEnd(filename, (int)request["value"]); });
        }

        private async Task GetHandler(HttpContext context, JObject request, string filename)
        {
            await context.Response.WriteAsync(Newtonsoft.Json.JsonConvert.SerializeObject(new {
                sum = _fileWorker.GetSum(filename, (int)request["from"],
                    (int)request["till"])}));
        }
        private static string ReadBodyAsString(HttpRequest request)
        {
            var initialBody = request.Body; // Workaround

            try
            {
                request.EnableRewind();

                using (var reader = new StreamReader(request.Body))
                {
                    var text = reader.ReadToEnd();
                    return text;
                }
            }
            finally
            {
                // Workaround so MVC action will be able to read body as well
                request.Body = initialBody;
            }

            return string.Empty;
        }
    }
}
