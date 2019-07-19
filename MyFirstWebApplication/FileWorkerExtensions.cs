using Microsoft.AspNetCore.Builder;
using MyFirstWebApplication.Services;

namespace MyFirstWebApplication
{
    public static class FileWorkerExtensions
    {
        public static IApplicationBuilder UseFileWorker(this IApplicationBuilder builder, IFileWorker fileWorker)
        {
            return builder.UseMiddleware<FileWorkerMiddleware>(fileWorker);
        }
    }
}
