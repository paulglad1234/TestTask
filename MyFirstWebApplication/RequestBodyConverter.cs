using System.IO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace MyFirstWebApplication
{
    internal static class RequestBodyConverter
    {
        public static string BodyToString(HttpRequest request)
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
        }
    }
}